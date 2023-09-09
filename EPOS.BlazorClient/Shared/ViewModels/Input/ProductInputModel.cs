using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using EPOS.BlazorClient.Shared.Models;

namespace EPOS.BlazorClient.Shared.ViewModels.Input
{
    public class ProductInputModel
    {
        [Key]
        public int ProductId { get; set; }
        
        [Required, StringLength(50)]
        public string ProductName { get; set; } = default!;
        [StringLength(150)]
        public string? UniqueCode { get; set; } = default!;
        [StringLength(150)]
        public string? InventoryCode { get; set; } = default!;
        [Required, ForeignKey("Category")]
        public int CategoryId { get; set; } = default!;
        [Required, ForeignKey("ProductMeasurement")]
        public int ProductMeasurementId { get; set; } = default!;
        [Required]
        public int SellUnitId { get; set; } = default!;
        public string PerItemUnitValue { get; set; } = default!;
        [Required, StringLength(150)]
        public string Description { get; set; } = default!;
        [Required, Column(TypeName = "money")]
        public decimal UnitPrice { get; set; } = default!;
        [Required, StringLength(50)]
        public string Picture { get; set; } = default!;
        [StringLength(50)]
        public string? BarCodeImage { get; set; } = default!;
        [StringLength(15)]
        public string? Size { get; set; } = default!;
        [StringLength(15)]
        public string? Color { get; set; } = default!;
        public int? Weight { get; set; } = default!;
        public int? Quantity { get; set; } = default!;

        public bool IsOffering { get; set; } = false;
        
        public int OfferType { get; set; }
        [StringLength(40)]
        public string? OfferDescription { get; set; } = default!;
        public virtual Category? Category { get; set; } = default!;

        public virtual ProductMeasurement? ProductMeasurement { get; set; } = default!;
        
        public virtual SellUnit? SellUnit { get; set; } = default!;
        
        
    }
}
