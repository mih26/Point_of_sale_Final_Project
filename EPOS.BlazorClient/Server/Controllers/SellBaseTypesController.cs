using EPOS.BlazorClient.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace EPOS.BlazorClient.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellBaseTypesController : ControllerBase
    {
        private readonly EPOSDbContext db;
        public SellBaseTypesController(EPOSDbContext db)
        {
            this.db = db;
        }
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<SellBaseType>>> GetBaseTypes()
        //{
        //    var data =await db.SellBaseTypes.ToListAsync();
        //    return data;
        //}
    }
}
