using EPOS.BlazorClient.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPOS.BlazorClient.Shared.ViewModels.Input
{
    
    public class SubCategoryInputModel
    {
        public int SubCategoryId { get; set; }
        [Required, StringLength(40)]
        public string SubCategoryName { get; set; } = default!;
        [Required, ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; } = default!;
        [Required, StringLength(150)]
        public string Description { get; set; } = default!;

    }
}
