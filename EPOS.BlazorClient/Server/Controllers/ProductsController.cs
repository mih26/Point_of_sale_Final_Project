using EPOS.BlazorClient.Shared.Models;
using EPOS.BlazorClient.Shared.ViewModels;
using EPOS.BlazorClient.Shared.ViewModels.Edit;
using EPOS.BlazorClient.Shared.ViewModels.Input;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EPOS.BlazorClient.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly EPOSDbContext db;
        private readonly IWebHostEnvironment env;
        public ProductsController(EPOSDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await db.Products.ToListAsync();
        }
        [HttpGet("VM")]
        public async Task<IEnumerable<ProductViewModel>> GetProductInputNodels()
        {
            var data = await db.Products
                .Include(x => x.Category)

                .Include(x => x.ProductMeasurement)

                .ToListAsync();
            List<ProductViewModel> products = new List<ProductViewModel>();
            foreach (var x in data)
            {
                var vm = new ProductViewModel
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    CategoryId = x.CategoryId,
                    ProductMeasurementId = x.ProductMeasurementId,
                    SellUnitId = x.SellUnitId,
                    PerItemUnitValue = x.PerItemUnitValue,
                    UnitPrice = x.UnitPrice,
                    Picture = x.Picture,
                    BarCodeImage = x.BarCodeImage,

                    CategoryName = x.Category.CategoryName,

                    IsOffering = x.isOffering,
                    OfferType = x.OfferType ?? OfferType.None,
                    OfferDescription = x.OfferDescription,
                    BaseTypeName = x.ProductMeasurement.BaseTypeName


                };
                var sun = db.SellUnits.First(su => su.SellUnitId == x.SellUnitId).SellUnitName;
                List<string> list = new List<string>();
                if (!string.IsNullOrEmpty(x.Size)) list.Add(x.Size);
                if (!string.IsNullOrEmpty(x.Color)) list.Add(x.Color);
                if (x.Weight.HasValue) list.Add(x.Weight.Value.ToString() + sun);
                if (x.Quantity.HasValue) list.Add(x.Quantity.Value.ToString() + sun);
                vm.Size_Color_Weight_Quantity = string.Join(",", list);
                vm.SellUnitName = sun;
                products.Add(vm);
            }
            return products;
        }

        [HttpGet("VM/{id}")]
        public async Task<ActionResult<ProductEditModel>> GetProductEditModel(int id)
        {
            var x = await db.Products
                .Include(x => x.Category)
                .Include(x => x.ProductMeasurement)
                .FirstOrDefaultAsync(p => p.ProductId == id);
            if (x is null) return NotFound();
            var vm = new ProductEditModel
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                CategoryId = x.CategoryId,
                ProductMeasurementId = x.ProductMeasurementId,
                SellUnitId = x.SellUnitId,
                PerItemUnitValue = x.PerItemUnitValue,
                UnitPrice = x.UnitPrice,
                Picture = x.Picture,
                BarCodeImage = x.BarCodeImage,
                Description = x.Description,
                CategoryName = x.Category.CategoryName,
                Size = x.Size,
                Color = x.Color,
                Weight = x.Weight,
                Quantity = x.Quantity,
                IsOffering = x.isOffering,
                OfferType = x.OfferType.HasValue ? (int)x.OfferType.Value : 0,
                OfferDescription = x.OfferDescription,
                BaseTypeName = x.ProductMeasurement.BaseTypeName


            };
            var sun = db.SellUnits.First(su => su.SellUnitId == x.SellUnitId).SellUnitName;

            vm.SellUnitName = sun;
            return vm;
        }
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductInputModel model)
        {
            if (db.Products == null)
            {
                return Problem("Entity set 'EPOSDbContext.Products'  is null.");
            }
            var product = new Product
            {
                ProductName = model.ProductName,
                CategoryId = model.CategoryId,
                ProductMeasurementId = model.ProductMeasurementId,
                SellUnitId = model.SellUnitId,
                PerItemUnitValue = model.PerItemUnitValue,
                UnitPrice = model.UnitPrice,
                Picture = model.Picture,

                Description = model.Description,
                Size = model.Size,
                Color = model.Color,
                Weight = model.Weight,
                Quantity = model.Quantity,


            };
            if (model.IsOffering)
            {
                product.isOffering = model.IsOffering;
                product.OfferType = (OfferType)model.OfferType;
                product.OfferDescription = model.OfferDescription;
            }
            db.Products.Add(product);
            await db.SaveChangesAsync();

            return Ok(product);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductEditModel>> PutProduct(int id, ProductEditModel model)
        {
            if (id != model.ProductId) return Problem("'Model pk' does not match");
            var product = await db.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            if (product == null) return NotFound();
            product.ProductName = model.ProductName;
            product.CategoryId = model.CategoryId;
            product.ProductMeasurementId = model.ProductMeasurementId;
            product.SellUnitId = model.SellUnitId;
            product.PerItemUnitValue = model.PerItemUnitValue;
            product.UnitPrice = model.UnitPrice;
            product.Description = model.Description;
            if (!string.IsNullOrEmpty(model.Picture)) product.Picture = model.Picture;

            
            product.Size = model.Size;
            product.Color = model.Color;
            product.Weight = model.Weight;
            product.Quantity = model.Quantity;
            if (model.IsOffering)
            {
                product.isOffering = model.IsOffering;
                product.OfferType = (OfferType)model.OfferType;
                product.OfferDescription = model.OfferDescription;
            }
            await db.SaveChangesAsync();
            return model;
        }
        [HttpPost("Upload")]
        public async Task<ImageUploadResponse> Upload(IFormFile file)
        {
            var ext = Path.GetExtension(file.FileName);
            var randomFileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
            var storedFileName = randomFileName + ext;
            using FileStream fs = new FileStream(Path.Combine(env.WebRootPath, "Pictures", storedFileName), FileMode.Create);
            await file.CopyToAsync(fs);
            fs.Close();
            return new ImageUploadResponse { FileName = file.FileName, StoredFileName = storedFileName };
        }

    }
}
