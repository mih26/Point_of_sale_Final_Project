using EPOS.BlazorClient.Shared.Models;
using EPOS.BlazorClient.Shared.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Imaging;
using System.Drawing;
using ZXing.Windows.Compatibility;
using ZXing;

using Microsoft.EntityFrameworkCore;
using EPOS.BlazorClient.Shared.ViewModels.Input;

namespace EPOS.BlazorClient.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelfedProductsController : ControllerBase
    {
        private readonly EPOSDbContext db;
        private readonly IWebHostEnvironment env;
        public SelfedProductsController(EPOSDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        [HttpGet]
        public async Task<IEnumerable<SelfedProduct>> GetSelfProducts()
        {
            return await db.SelfedProducts.ToListAsync();
        }
        [HttpGet("VM")]
        public async Task<IEnumerable<SelfedProductViewModel>> GetSelfProductViewModels()
        {
            var data = await db.SelfedProducts.Include(x => x.Inventory).ThenInclude(y => y.SelfedProducts).ToListAsync();
            List<SelfedProductViewModel> list = new List<SelfedProductViewModel>();
            data.ForEach(x =>
            {
                var vm = new SelfedProductViewModel
                {
                    
                    InventoryCode = x.Inventory.InventoryCode,

                    RackId = x.RackId,
                    SelfQuantity = x.SelfQuantity,
                    BarcodeImage = x.BarcodeImage,
                    SelfCode = x.SelfCode,
                    ProductId = x.Inventory.ProductId,
                    ProductName = db.Products.First(p => p.ProductId == x.Inventory.ProductId).ProductName,
                    RackName = db.Racks.First(r => r.RackId == x.RackId).RackName
                };
                vm.Sold = x.Inventory.SelfedProducts.Sum(o => o.Sold);
                vm.Remaining = vm.SelfQuantity - vm.Sold;
                list.Add(vm);
            });
            return list;
        }
        [HttpPost("VM")]
        public async Task<ActionResult<SelfedProductViewModel>> PostSelfedProductInputModel(SelfedProductInputModel model)
        {
            var x = new SelfedProduct
            {
                
                RackId = model.RackId,
                SelfQuantity = model.SelfQuantity,
                Sold = 0,
                InventoryId=model.InventoryId

            };
            var inv = await db.Inventories.FirstAsync(x => x.InventoryCode == model.InventoryCode);
            inv.OnSelf += model.SelfQuantity;
            //x.InventoryCode=inv.InventoryCode;
            x.SelfCode = GetSelfCode(model.ProductId, inv.SupplierId);
            x.BarcodeImage = GenerateBarcode(x.SelfCode);
           
             x.InventoryId = inv.InventoryId;
            await db.SelfedProducts.AddAsync(x);
            await db.SaveChangesAsync();
            return new SelfedProductViewModel
            {
                SelfedProductId = x.SelfedProductId,
                InventoryCode=inv.InventoryCode,
                
                RackId = x.RackId,
                SelfQuantity = x.SelfQuantity,
                BarcodeImage = x.BarcodeImage,
                SelfCode = x.SelfCode,
                ProductName = db.Products.First(p => p.ProductId == inv.ProductId).ProductName,
                RackName = db.Racks.First(r => r.RackId == x.RackId).RackName
            };
        }
        private string GenerateBarcode(string code)
        {
            var writer = new BarcodeWriter
            {
                Renderer = new AlternateBitmapRenderer(),
                Format = BarcodeFormat.CODE_93
            };
            Bitmap bitmap = writer.Write(code);
            string f = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".png";
            var fs = new FileStream(Path.Combine(this.env.WebRootPath, "barcodes", f), FileMode.Create);
            bitmap.Save(fs, ImageFormat.Png);
            fs.Close();
            return f;
        }
        private string GetSelfCode(int productId, int supplierid)
        {
            Random rand = new Random();
            return $"{productId:000}-{rand.Next(100000):000000}-{supplierid:000}";

        }


    }
}
