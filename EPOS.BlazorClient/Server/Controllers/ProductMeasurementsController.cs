using EPOS.BlazorClient.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace EPOS.BlazorClient.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductMeasurementsController : ControllerBase
    {
        private readonly EPOSDbContext db;
        public ProductMeasurementsController(EPOSDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductMeasurement>>> GetBaseTypes()
        {
            var data =await db.ProductMeasurements.ToListAsync();
            return data;
        }
        [HttpPost]
        public async Task<ActionResult<ProductMeasurement>> PostBaseTypes(ProductMeasurement model)
        {
            await db.ProductMeasurements.AddAsync(model);
            await db.SaveChangesAsync();
            return model;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductMeasurement>> PutBaseTypes(int id, ProductMeasurement model)
        {
            if(id != model.ProductMeasurementId) { return BadRequest(); }
            if (!db.ProductMeasurements.Any(x => x.ProductMeasurementId == model.ProductMeasurementId)) return NotFound();
            db.Entry(model).State= EntityState.Modified;
            await db.SaveChangesAsync();
            return model;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductMeasurement(int id)
        {
            if (db.ProductMeasurements == null)
            {
                return NotFound();
            }
            var pm = await db.ProductMeasurements.FindAsync(id);
            if (pm == null)
            {
                return NotFound();
            }

            db.ProductMeasurements.Remove(pm);
            await db.SaveChangesAsync();

            return NoContent();
        }
        [HttpGet("CanDelete/{id}")]
        public async Task<bool> CanDelete(int id)
        {
            var hasAny = await db.ProductMeasurements.AnyAsync(s => s.ProductMeasurementId == id);
            //return !hasAny;
            id++;
            return await Task.FromResult<bool>(true);

        }
    }
}
