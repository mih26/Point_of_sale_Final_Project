using EPOS.BlazorClient.Shared.Models;
using EPOS.BlazorClient.Shared.ViewModels.Input;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;

namespace EPOS.BlazorClient.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly EPOSDbContext db;
        public CategoriesController(EPOSDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var data = await db.Categories.ToListAsync();
            return data;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var data = await db.Categories.FirstOrDefaultAsync(x=> x.CategoryId==id);
            if (data == null) return NotFound();
            return data;
        }
        [HttpGet("Sub/{id}")]
        public async Task<ActionResult<CategoryInputModel>> GetCategoryWithSubCategories(int id)
        {
            var data = await db.Categories.FirstOrDefaultAsync(x=> x.CategoryId==id);
            if (data == null) return NotFound();
            return new CategoryInputModel
            {
                CategoryId=data.CategoryId,
                CategoryName=data.CategoryName,
                Description=data.Description
               
            };
        }
        [HttpPost]
        public async Task<Category> PostCategory(Category category)
        {
            await db.Categories.AddAsync(category);
            await db.SaveChangesAsync();
            return category;
        }
        [HttpPost("Sub")]
        public async Task<Category> PostCategoryWithSubCategories(CategoryInputModel model)
        {
            var category = new Category {  CategoryName= model.CategoryName, Description=model.Description };
            await db.Categories.AddAsync(category);
            await db.SaveChangesAsync();
            //category.SubCategories.AddRange(await AddSubCategories(model.SubCategories, category));
            

            return category;
        }
        [HttpPut("Edit/{id}")]
        public async  Task<Category> PutCategory(CategoryInputModel model)
        {
            
            var existing =await db.Categories.FirstAsync(x=> x.CategoryId==model.CategoryId);
            existing.CategoryName= model.CategoryName;
            existing.Description= model.Description;
            
            await db.SaveChangesAsync();
            return await db.Categories.FirstAsync(x=> x.CategoryId == model.CategoryId);

        }
        [HttpGet("CanDelete/{id}")]
        public async Task<bool> CanDelete(int id)
        {
            var hasAny = await db.SubCategories.AnyAsync(s=> s.CategoryId == id);
            return !hasAny;
            
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (db.Categories == null)
            {
                return NotFound();
            }
            var category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Categories.Remove(category);
            await db.SaveChangesAsync();

            return NoContent();
        }

        ///
        /// Private methods
        /// 
        private async Task<IEnumerable<SubCategory>> AddSubCategories(IEnumerable<SubCategoryInputModel> subs, Category category)
        {
            List<SubCategory> subCategories = new List<SubCategory>();
            foreach(var sub in subs)
            {
               var s = new SubCategory {  SubCategoryName=sub.SubCategoryName, Description=sub.Description, CategoryId=category.CategoryId };
               await db.SubCategories.AddAsync(s);
               subCategories.Add(s);
            }
            await db.SaveChangesAsync();
            return subCategories;
        }
    }
}
