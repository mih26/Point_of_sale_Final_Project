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
    public class InventoriesController : ControllerBase
    {
        private readonly EPOSDbContext db;
        public InventoriesController(EPOSDbContext db)
        {
            this.db = db;
        }
        [HttpGet("VM")]
        public async Task<ActionResult<IEnumerable<InventoryViewModel>>> GetInventoryViewModels()
        {
            var data = await db.Inventories.Include(x=> x.SelfedProducts).ToListAsync();
            List<InventoryViewModel> vm = new List<InventoryViewModel>();
            data
                .ForEach(x =>
                {
                    var inv = new InventoryViewModel
                    {
                        InventoryId = x.InventoryId,
                        InventoryCode = x.InventoryCode,
                        InDate = x.InDate,
                        Quantity = x.Quantity,
                        UnitPrice = x.UnitPrice,
                        SelfPrice = x.SelfPrice,
                        SupplierId = x.SupplierId,
                        SupplierName = db.Suppliers.First(s => s.SupplierId == x.SupplierId).CompanyName,
                        ProductId = x.ProductId,
                        ProductName = db.Products.First(p => p.ProductId == x.ProductId).ProductName
                    };
                    inv.OnSelf = x.SelfedProducts.Sum(o => o.SelfQuantity);
                    inv.Sold = x.SelfedProducts.Sum(o => o.Sold);
                    inv.Stock = inv.Quantity - inv.OnSelf;
                    vm.Add(inv);
                });
            return vm;

        }
        [HttpGet("VM/Edit/{id}")]
        public async Task<ActionResult<InventoryInputModel>> GetInventoryEdidModel(int id)
        {
            var x = await db.Inventories.FirstOrDefaultAsync(i=> i.InventoryId == id);
            if (x == null) return NotFound();
            return new InventoryInputModel
            {
                InventoryId = x.InventoryId,
                InventoryCode = x.InventoryCode,
                InDate = x.InDate,
                Quantity = x.Quantity,
                UnitPrice = x.UnitPrice,
                SelfPrice = x.SelfPrice,
                SupplierId = x.SupplierId,

                ProductId = x.ProductId

            };
        }
        [HttpPost("VM")]
        public async Task<ActionResult<Inventory>> PostInventoryInputModel(InventoryInputModel model)
        {
            var inventory = new Inventory
            {
                InDate = model.InDate,
                SupplierId = model.SupplierId,
                ProductId = model.ProductId,
                Quantity = model.Quantity,
                UnitPrice = model.UnitPrice,
                SelfPrice = model.SelfPrice,
                InventoryCode = GetInventoryCode(model.ProductId, model.SupplierId)
            };
            //inventory.StockEntries.Add(new StockEntry { Stock = model.Quantity });
            await db.Inventories.AddAsync(inventory);
            await db.SaveChangesAsync();
            return inventory;
        }
        [HttpGet("Options/{id}")]
        public async Task<IEnumerable<InventoryOption>> GetInventoryOptions(int id)
        {
            var options = await db.Inventories
                .Include(x => x.Supplier)
                .Include(x => x.Product)
                .Where(x => x.ProductId == id)
                .ToListAsync();
            return options.Select(x =>  new InventoryOption { 
                Code = x.InventoryCode, 
                Name = x.Supplier.CompanyName + "-" + x.Product.ProductName
            }
            ).ToList();
        }
        [HttpGet("Value/{code}")]
        public async Task<ActionResult<int>> GetQuantity(string code)
        {
            var data = await db.Inventories.Include(x => x.SelfedProducts).FirstOrDefaultAsync(x => x.InventoryCode == code);
            if (data == null) return NotFound();



            return data.Quantity - data.SelfedProducts.Sum(x => x.SelfQuantity);
        }
        [HttpGet("Products")]
        public async Task<IEnumerable<ProductOption>> GetProductOptions()
        {
            var options = await db.Inventories
                .Include(x => x.Product)
                .Where(x => x.Quantity - x.OnSelf > 0)
                .ToListAsync();
            List<ProductOption> products = new List<ProductOption>();
            options.ForEach(x =>
            {
                var vm = new ProductOption { ProductId = x.ProductId };
                var pd = db.Products.First(p => p.ProductId == x.ProductId);
                vm.ProductName = pd.ProductName;
                var sun = db.SellUnits.First(su => su.SellUnitId == pd.SellUnitId).SellUnitName;
                List<string> list = new List<string>();
                if (!string.IsNullOrEmpty(pd.Size)) list.Add(pd.Size);
                if (!string.IsNullOrEmpty(pd.Color)) list.Add(pd.Color);
                if (pd.Weight.HasValue) list.Add(pd.Weight.Value.ToString() + sun);
                if (pd.Quantity.HasValue) list.Add(pd.Quantity.Value.ToString() + sun);
                vm.ProductName += " " + string.Join(",", list);
                products.Add(vm);
            });
            return products;

        }
        [HttpPut("VM/{id}")]
        public async Task<ActionResult<Inventory>> PutInventoryInputModel(int id, InventoryInputModel model)
        {
            if (id != model.InventoryId) return Problem("'Inventorid' mismatch");
            var x = await db.Inventories.Include(i => i.SelfedProducts).FirstOrDefaultAsync(i => i.InventoryId == id);
            if (x == null) return NotFound();
            x.InDate = model.InDate;
            x.SupplierId = model.SupplierId;
            x.ProductId = model.ProductId;
            x.Quantity = model.Quantity;
            x.UnitPrice = model.UnitPrice;
            x.SelfPrice = model.SelfPrice;
            x.OnSelf = x.OnSelf;
           
            
            await db.SaveChangesAsync();
            return x;
        }
        private string GetInventoryCode(int productId, int supplierid)
        {
            Random rand = new Random();
            return $"{productId:000}-{rand.Next(100000):000000}-{supplierid:000}";

        }

    }
    
}
