using EPOS.BlazorClient.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPOS.BlazorClient.Shared.ViewModels
{
    public class StockEntryViewModel
    {
        
            
            [Required]
            public int Stock { get; set; } = 0;
            public int Sold { get; set; } = 0;
            public int OnSelf { get; set; } = 0;
        public int ProductId { get; set; }
        public string? ProductName { get; set; } = default!;
        
        
        
    }
}
