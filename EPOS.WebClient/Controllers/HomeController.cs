using EPOS.BlazorClient.Shared.Models;
using EPOS.BlazorClient.Shared.Models.Identity;
using EPOS.BlazorClient.Shared.ViewModels;
using EPOS.BlazorClient.Shared.ViewModels.Input;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch.Adapters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EPOS.WebClient.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        EPOSDbContext db;
        
        private readonly UserManager<AppUser> userManager;
        public HomeController(EPOSDbContext db, UserManager<AppUser> userManager)
        {
            this.db = db;
            
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> FindProduct(string code)
        {
            var data = await db.SelfedProducts.Include(x=> x.Inventory).ThenInclude(y=> y.Product).FirstOrDefaultAsync(x => x.SelfCode == code);
            if (data == null) return NotFound();
            var sun = db.SellUnits.First(su => su.SellUnitId == data.Inventory.Product.SellUnitId).SellUnitName;
            List<string> list = new List<string>();
            if (!string.IsNullOrEmpty(data.Inventory.Product.Size)) list.Add(data.Inventory.Product.Size);
            if (!string.IsNullOrEmpty(data.Inventory.Product.Color)) list.Add(data.Inventory.Product.Color);
            if (data.Inventory.Product.Weight.HasValue) list.Add(data.Inventory.Product.Weight.Value.ToString() + sun);
            if (data.Inventory.Product.Quantity.HasValue) list.Add(data.Inventory.Product.Quantity.Value.ToString() + sun);
            var oi = new POSOrderItemViewModel{ SelfCode=code,Quantity=1, SelfedProductId=data.SelfedProductId, SelfPrice=data.Inventory.SelfPrice };
            oi.ProductName = data.Inventory.Product.ProductName + "-" + string.Join(",", list);
            return Json(oi);
        }
        [HttpPost]
        public async Task<ActionResult> SaveOrder(OrderInputModel model)
        {
           
            
           
            if (ModelState.IsValid)
            {
                var user = await this.userManager.GetUserAsync(HttpContext.User);
                int c = 0;
                if(user != null) { c=user.CounterId.HasValue ? user.CounterId.Value : 0; }
                var order = new Order { CounterId=c, CustomerName = model.CustomerName, OrderAmount=0, OrderDate=DateTime.Now, Phone=model.Phone, PaymentVia=model.PaymentVia };
                model.OrderItems.ToList()
                    .ForEach(x =>
                    {
                        var p = db.SelfedProducts.Include(sp=> sp.Inventory).First(x => x.SelfCode == x.SelfCode);
                        var oi = new OrderItem { ProductId = p.Inventory.ProductId, Quantity = x.Quantity };
                        order.OrderItems.Add(oi);
                        order.OrderAmount += p.Inventory.SelfPrice * x.Quantity * (1 - .015M);
                        
                        p.Sold += x.Quantity;
                    });
                await db.Orders.AddAsync(order);

                await db.SaveChangesAsync();
                return Json(model);
            }
            return Json(model);
        }
        public async Task<ActionResult> OrderReport(DateTime? date)
        {
            List<OrderViewModel> vm = new List<OrderViewModel>();
            DateTime dt = date.HasValue ? date.Value : DateTime.Now;
            var user = await this.userManager.GetUserAsync(HttpContext.User);
            int c = 0;
            if (user != null) { c = user.CounterId.HasValue ? user.CounterId.Value : 0; }
            var data = await db.Orders.Include(x=> x.OrderItems).Where(o=> o.OrderDate.Date == dt.Date && o.CounterId==c).ToListAsync();
            data.ForEach(x =>
            {
                var od = new OrderViewModel
                {
                    OrderId = x.OrderId,
                    OrderDate = x.OrderDate,
                    OrderAmount = x.OrderAmount,
                    CounterId = x.CounterId,
                    CustomerName = x.CustomerName,
                    Phone = x.Phone,
                    PaymentVia = x.PaymentVia
                };
                od.ItemCount = x.OrderItems.Sum(oi => oi.Quantity);
                vm.Add(od);
            });
            ViewBag.Date = dt;
            return View(vm);
        }
    }
}
