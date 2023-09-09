using EPOS.BlazorClient.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPOS.BlazorClient.Shared.ViewModels
{
    public class SelfedProductViewModel
    {
        public int SelfedProductId { get; set; }
        [Required, StringLength(50)]
        public string SelfCode { get; set; } = default!;
        [Required, StringLength(50)]
        public string InventoryCode { get; set; } = default!;
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int RackId { get; set; }
        [Required]
        public int SelfQuantity { get; set; }

        public int Sold { get; set; }
        public int Remaining { get; set; }
        public string? BarcodeImage { get; set; } = default!;
        public string? ProductName { get; set; } = default!;
        public string? RackName { get; set; } = default!;
    }
}
