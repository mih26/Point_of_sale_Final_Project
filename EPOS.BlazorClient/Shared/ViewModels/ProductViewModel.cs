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
    public class ProductViewModel
    {
       
        public int ProductId { get; set; }
       
        public string ProductName { get; set; } = default!;
       
        public string? UniqueCode { get; set; } = default!;
       
        public string? InventoryCode { get; set; } = default!;
        [Required, ForeignKey("Category")]
        public int CategoryId { get; set; } = default!;
        
        public int ProductMeasurementId { get; set; } = default!;
       
        public int SellUnitId { get; set; } = default!;
        public string PerItemUnitValue { get; set; } = default!;
        
        public string Description { get; set; } = default!;
       
        public decimal UnitPrice { get; set; } = default!;
        
        public string Picture { get; set; } = default!;
        
        public string? BarCodeImage { get; set; } = default!;
        
        public string? Size_Color_Weight_Quantity { get; set; } = default!;
        

        public bool IsOffering { get; set; } = false;
        [EnumDataType(typeof(OfferType))]
        public OfferType? OfferType { get; set; }
       
        public string? OfferDescription { get; set; } = default!;
        public string? CategoryName { get; set; } = default!;

        public string? BaseTypeName { get; set; } = default!;

        public string? SellUnitName { get; set; } = default!;
    }
}
