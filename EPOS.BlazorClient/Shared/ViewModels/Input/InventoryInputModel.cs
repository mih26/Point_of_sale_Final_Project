using EPOS.BlazorClient.Shared.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPOS.BlazorClient.Shared.ViewModels.Input
{
    public class InventoryInputModel
    {
        public int InventoryId { get; set; }
        [StringLength(150)]
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
        public virtual Supplier? Supplier { get; set; } = default!;
        public virtual Product? Product { get; set; } = default!;
        //public virtual ICollection<StockEntry>? StockEntries { get; set; } = new List<StockEntry>();
    }
}
