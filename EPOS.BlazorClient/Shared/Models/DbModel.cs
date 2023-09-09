using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EPOS.BlazorClient.Shared.Models
{
    public enum RakType { OneSided=1, TwoSided, ThreeSided, FourSided, Cornered }
    public enum FreezerType { ReachInFreezer=1, ChestFreezer, ChillerRake }
    public enum OfferType {None=1,Bundle, Extra, PriceCut, Gift}
    public class Category
    {
        public int CategoryId { get; set; }
        [Required, StringLength(50), Display(Name = "Category Name")]
        public string CategoryName { get; set; } = default!;
        [Required, StringLength(150)]
        public string Description { get; set; } = default!;
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    }
    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        [Required, StringLength(40)]
        public string SubCategoryName { get; set; } = default!;
        [Required, ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
        [Required, StringLength(150)]
        public string Description { get; set; } = default!;

    }
    public class Rack
    {
        public int RackId { get; set; }
        [Required, StringLength(30)]
        public string RackName { get; set; } = default!;
        [Required, EnumDataType(typeof(RakType))]
        public RakType RakType { get; set; }
        [Required]
        public int LayerCount { get; set; }
        public bool IsTopOpen { get; set; }
        public ICollection<RackLayer>? RackLayers { get; set; } = new List<RackLayer>();
        public virtual ICollection<SelfedProduct> SelfedProducts { get; set; } = new List<SelfedProduct>();
    }
    public class RackLayer
    {
        public int RackLayerId { get; set; }
        [Required, StringLength(30)]
        public string LayerSide { get; set; } = default!;
        public virtual Rack? Rack { get; set; } = default!;
        [Required, ForeignKey("Rack")]
        public int RackId { get; set; }
    }
    public class Freezer
    {
        public int FreezerId { get; set; }
        [Required, StringLength(30)]
        public int FrezerName { get; set; }
        [Required, EnumDataType(typeof(FreezerType))]
        public FreezerType FreezerType { get; set; }

    }
    public class ProductMeasurement
    {
        public int ProductMeasurementId { get; set; }
        [Required, StringLength(30)]
        public string BaseTypeName { get; set; } = default!;
        public ICollection<SellUnit>? SellUnits { get; set; } = new List<SellUnit>();
    }
    public class SellUnit
    {
        public int SellUnitId { get; set; }
        [Required, StringLength(30)]
        public string SellUnitName { get; set; } = default!;
        [Required, ForeignKey("ProductMeasurement")]
        public int ProductMeasurementId { get; set; }
        public virtual ProductMeasurement ProductMeasurement { get; set; } = default!;
        //public virtual ICollection<Product> Products { get; set; }= new List<Product>();
    }
    public class SellPackage
    {
        public int SellPackageId { get; set; }
        [Required, StringLength(30)]
        public string SellPackageName { get; set; } = default!;
    }
    public abstract class ProductBase
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
      
        public virtual Category Category { get; set; } = default!;

        public virtual ProductMeasurement ProductMeasurement { get; set; } = default!;
        public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
        
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
       
    }
    public class Product:ProductBase
    {
        [StringLength(15)]
        public string? Size { get; set; }= default!;
        [StringLength(15)]
        public string? Color { get; set; } = default!;
        public int? Weight { get; set; } = default!;
        public int? Quantity { get; set; } = default!;

        public bool isOffering { get; set; } = false;
        [EnumDataType(typeof(OfferType))]
        public OfferType? OfferType { get; set; }
        [StringLength(40)]
        public string? OfferDescription { get; set; } = default!;
    }
    public class Supplier
    {
        public int SupplierId { get; set; }
        [Required, StringLength(50)]
        public string CompanyName { get; set; } = default!;
        [Required, StringLength(50)]
        public string ContactName { get; set; } = default!;
        [Required, StringLength(20)]
        public string ContactNo { get; set; } = default!;
        public virtual ICollection<Inventory> Inventories { get; set;}= new List<Inventory>();

    }
    public class Inventory
    {
        public int InventoryId { get; set; }
        [Required, StringLength(150)]
        public string InventoryCode { get; set; } = default!;
        [Required, Column(TypeName = "date")]
        public DateTime InDate { get; set; } = DateTime.Today;
        [Required, ForeignKey("Supplier")]
        public int SupplierId { get;set; }
        [Required, ForeignKey("Product")]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; } = default!;
        [Required,Column(TypeName ="money")]
        public decimal UnitPrice { get; set; }
        [Required, Column(TypeName = "money")]
        public decimal SelfPrice { get; set; } = default!;

        public int OnSelf { get; set; } = 0;
        public virtual Supplier Supplier { get; set; } = default!;
        public virtual Product Product { get; set; } = default!;
        public virtual ICollection<SelfedProduct> SelfedProducts { get; set; }= new List<SelfedProduct>();
        
    }
    
    public class SelfedProduct
    {
        public int SelfedProductId { get; set; }
        [Required, StringLength(50)]
        public string SelfCode { get; set; } = default!;
        [Required, ForeignKey("Inventory")]
        public int InventoryId { get; set; }
        
        
        [Required]
        public int RackId { get; set; }
        [Required]
        public int SelfQuantity { get; set; }
       
        public int Sold { get; set; }
        [Required]
        public string BarcodeImage { get; set; } = default!;
       
        public virtual Rack Rack { get; set; } = default!;
        public virtual Inventory Inventory { get; set; } = default!;
    }
    public class Order
    {
        public int OrderId { get; set; }
        [Required, Column(TypeName ="datetime")]
        public DateTime OrderDate { get; set; }
        [StringLength(50)]
        public string? CustomerName { get; set; }
        [Required, StringLength(50)]
        public string Phone { get; set; } = default!;
        [Required, StringLength(30)]
        public string PaymentVia { get; set; } = default!;
        [Column(TypeName ="money")]
        public decimal OrderAmount { get; set; }
        [Required]
        public int CounterId { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        [Required, ForeignKey("Order")]
        public int OrderId { get; set; }
        [Required, ForeignKey("Product")]
        public int ProductId { get; set; }
        
        public int Quantity { get; set; }

        public virtual Order Order { get; set; }=default!;
        public virtual Product Product { get; set; } = default!;

    }
    public class EPOSDbContext : DbContext
    {
        public EPOSDbContext(DbContextOptions<EPOSDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<SubCategory> SubCategories { get; set; } = default!;
        public DbSet<Rack> Racks { get; set; } = default!;
        public DbSet<RackLayer> RackLayers { get; set; } = default!;
        public DbSet<Freezer> Freezers { get; set; } = default!;
        public DbSet<ProductMeasurement> ProductMeasurements { get; set; } = default!;
        public DbSet<SellUnit> SellUnits { get; set; } = default!;
        public DbSet<SellPackage> SellPackages { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
        
        public DbSet<Supplier> Suppliers { get; set; } = default!;
        public DbSet<Inventory> Inventories { get; set; } = default!;
        
        public DbSet<SelfedProduct> SelfedProducts { get; set; } = default!;
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


    }
}
