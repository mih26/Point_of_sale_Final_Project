using EPOS.BlazorClient.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EPOS.BlazorClient.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellUnitsController : ControllerBase
    {
        private readonly EPOSDbContext db;
        public SellUnitsController(EPOSDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SellUnit>>> GetSellUnits() {
            var data = await this.db.SellUnits.ToListAsync();
            return data;
        }
        [HttpGet("For/{id}")]
        public async Task<ActionResult<IEnumerable<SellUnit>>> GetSellUnits(int id /* measurementid */)
        {
            var data = await this.db.SellUnits.Where(su=> su.ProductMeasurementId==id).ToListAsync();
            return data;
        }
    }
}
