using EPOS.BlazorClient.Shared.Models;
using EPOS.BlazorClient.Shared.ViewModels;
using EPOS.BlazorClient.Shared.ViewModels.Input;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EPOS.BlazorClient.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly EPOSDbContext db;
        public OrdersController(EPOSDbContext db)
        {
            this.db = db;
        }
        //[HttpGet("POS/{code}")]
        //public async Task<ActionResult<ItemViewModel>> GetPosItem(string code)
        //{
        //    var sp = await db.SelfedProducts.FirstAsync(x=> x.SelfCode == code);
        //    var inv = await db.Inventories.FirstAsync(i => i.InventoryCode == sp.InventoryCode);
        //    var p = await db.Products.FirstAsync(x=> x.ProductId == sp.ProductId);
        //    var item = new ItemViewModel { ProductName = p.ProductName, UnitPrice = inv.SelfPrice };
        //    var sun = db.SellUnits.First(su => su.SellUnitId == p.SellUnitId).SellUnitName;
        //    List<string> list = new List<string>();
        //    if (!string.IsNullOrEmpty(p.Size)) list.Add(p.Size);
        //    if (!string.IsNullOrEmpty(p.Color)) list.Add(p.Color);
        //    if (p.Weight.HasValue) list.Add(p.Weight.Value.ToString() + sun);
        //    if (p.Quantity.HasValue) list.Add(p.Quantity.Value.ToString() + sun);
        //    item.ProductName +=" " + string.Join(",", list);
        //    return item;
        //}
        //[HttpPost("VM")]
        //public async Task<ActionResult<Order>> PostOrderInputModel(OrderInputModel model)
        //{
        //    var order = new Order
        //    {
        //        CustomerName = model.CustomerName,
        //        Phone = model.Phone,
        //        PaymentVia = model.PaymentVia,
        //        OrderDate = DateTime.Now


        //    };
        //    decimal value = 0;
        //    foreach (var x in model.OrderItems)
        //    {
        //        var p = db.SelfedProducts.First(sp => sp.SelfCode == x.SelfCode);
        //        var inv = db.Inventories.First(i => i.InventoryCode == p.InventoryCode);
        //        order.OrderItems.Add(new OrderItem { ProductId = p.ProductId, Quantity = x.Quantity });
        //        value += inv.SelfPrice * x.Quantity;
        //    }
        //    order.OrderAmount = value;
        //    await db.Orders.AddAsync(order);
        //    return order;
        //}
    }
}