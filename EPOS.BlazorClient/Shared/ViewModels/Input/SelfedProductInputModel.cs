using EPOS.BlazorClient.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPOS.BlazorClient.Shared.ViewModels.Input
{
    public class SelfedProductInputModel
    {
        public int SelfedProductId { get; set; }
        
        public string? SelfCode { get; set; } = default!;
        [Required]
        public int InventoryId { get; set; }
        
        public string? InventoryCode { get; set; } = default!;
       
        public int ProductId { get; set; }
        [Required]
        public int RackId { get; set; }
        [Required]
        public int SelfQuantity { get; set; }

        
        
    }
}
