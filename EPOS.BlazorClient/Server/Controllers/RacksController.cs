using EPOS.BlazorClient.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EPOS.BlazorClient.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacksController : ControllerBase
    {
        private readonly EPOSDbContext db;
        public RacksController(EPOSDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public async Task<IEnumerable<Rack>> GetRacks()
        {
            var data = await db.Racks.ToListAsync();
            return data;
        }
        [HttpGet("Layers")]
        public async Task<IEnumerable<Rack>> GetRacksWithLayes()
        {
            var data = await db.Racks.Include(r=> r.RackLayers).ToListAsync();
            return data;
        }
        [HttpPost]
        public async Task<ActionResult<Rack>> PostRack(Rack rack)
        {
            if (db.Racks == null)
            {
                return Problem("Entity set 'EPOSDbContext.Racks'  is null.");
            }
            db.Racks.Add(rack);
            await db.SaveChangesAsync();

            return rack;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRack(int id)
        {
            if (db.Racks == null)
            {
                return NotFound();
            }
            var rack = await db.Racks.FindAsync(id);
            if (rack == null)
            {
                return NotFound();
            }

            db.Racks.Remove(rack);
            await db.SaveChangesAsync();

            return NoContent();
        }

    }
}
