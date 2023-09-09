using EPOS.BlazorClient.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EPOS.BlazorClient.Shared.ViewModels.Input
{
    
    public class CategoryInputModel
    {
        public int CategoryId { get; set; }
        [Required, StringLength(50), Display(Name = "Category Name")]
        public string CategoryName { get; set; } = default!;
        [Required, StringLength(150)]
        public string Description { get; set; } = default!;
       // public virtual ICollection<SubCategoryInputModel> SubCategories { get; set; } = new List<SubCategoryInputModel>();

    }
}
