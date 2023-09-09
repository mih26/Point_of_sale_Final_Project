using EPOS.BlazorClient.Shared.Models;
using EPOS.BlazorClient.Shared.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EPOS.BlazorClient.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly EPOSDbContext db;
        public StocksController(EPOSDbContext db)
        {
            this.db = db;
        }
        [HttpGet("VM")]
        public async Task<ActionResult<IEnumerable<StockEntryViewModel>>> GetStockEntryViewModels()
        {
            var data = await db.Products

               .Include(x => x.Inventories).ThenInclude(y => y.SelfedProducts)


               .ToListAsync();
            List<StockEntryViewModel> list = new List<StockEntryViewModel>();
            data.ForEach(x =>
            {
                var vm = new StockEntryViewModel
                {

                    ProductName = x.ProductName,

                    ProductId = x.ProductId,

                };

                vm.Sold = x.Inventories.Sum(y => y.SelfedProducts.Sum(z => z.Sold));
                vm.OnSelf = x.Inventories.Sum(y => y.OnSelf) - vm.Sold;
                vm.Stock = x.Inventories.Sum(y => y.Quantity) - vm.OnSelf - vm.Sold;
                list.Add(vm);
            });
            return list;
        }
    }
}
