using EPOS.BlazorClient.Shared.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPOS.BlazorClient.Shared.ViewModels
{
    public class InventoryViewModel
    {
        public int InventoryId { get; set; }
        [Required, StringLength(150)]
        public string? InventoryCode { get; set; } = default!;
        [Required, Column(TypeName = "date")]
        public DateTime InDate { get; set; } = DateTime.Today;
        [Required, ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        [Required, ForeignKey("Product")]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; } = default!;
        [Required, Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }
        [Required, Column(TypeName = "money")]
        public decimal SelfPrice { get; set; }
        public string?  SupplierName { get; set; } = default!;
        public string? ProductName { get; set; } = default!;
        public int OnSelf { get; set; }
        public int Sold { get; set; }
        public int Stock { get; set; }
        
    }
}
