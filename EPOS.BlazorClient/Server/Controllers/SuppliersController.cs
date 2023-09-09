using EPOS.BlazorClient.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EPOS.BlazorClient.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly EPOSDbContext db;
        public SuppliersController(EPOSDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
        {
            var data = await db.Suppliers.ToListAsync();
            return data;
        }
        [HttpPost]
        public async Task<ActionResult<Supplier>> PostSupplier(Supplier model)
        {
            await db.Suppliers.AddAsync(model);
            await db.SaveChangesAsync();
            return model;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Supplier>> DeleteSupplier(int id)
        {
            var model = await db.Suppliers.FirstOrDefaultAsync(s=> s.SupplierId== id);
            if(model==null) return NotFound();
            db.Suppliers.Remove(model);
            await db.SaveChangesAsync();
            return model;
        }
    }
}
