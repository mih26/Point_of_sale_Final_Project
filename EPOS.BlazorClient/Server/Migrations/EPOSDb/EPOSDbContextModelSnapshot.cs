﻿// <auto-generated />
using System;
using EPOS.BlazorClient.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EPOS.BlazorClient.Server.Migrations.EPOSDb
{
    [DbContext(typeof(EPOSDbContext))]
    partial class EPOSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.Freezer", b =>
                {
                    b.Property<int>("FreezerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FreezerId"));

                    b.Property<int>("FreezerType")
                        .HasColumnType("int");

                    b.Property<int>("FrezerName")
                        .HasMaxLength(30)
                        .HasColumnType("int");

                    b.HasKey("FreezerId");

                    b.ToTable("Freezers");
                });

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.Inventory", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InventoryId"));

                    b.Property<DateTime>("InDate")
                        .HasColumnType("date");

                    b.Property<string>("InventoryCode")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("OnSelf")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("SelfPrice")
                        .HasColumnType("money");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("money");

                    b.HasKey("InventoryId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("CounterId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("OrderAmount")
                        .HasColumnType("money");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime");

                    b.Property<string>("PaymentVia")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("BarCodeImage")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("InventoryCode")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("OfferDescription")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int?>("OfferType")
                        .HasColumnType("int");

                    b.Property<string>("PerItemUnitValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ProductMeasurementId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SellUnitId")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("UniqueCode")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("money");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.Property<bool>("isOffering")
                        .HasColumnType("bit");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ProductMeasurementId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.ProductMeasurement", b =>
                {
                    b.Property<int>("ProductMeasurementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductMeasurementId"));

                    b.Property<string>("BaseTypeName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ProductMeasurementId");

                    b.ToTable("ProductMeasurements");
                });

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.Rack", b =>
                {
                    b.Property<int>("RackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RackId"));

                    b.Property<bool>("IsTopOpen")
                        .HasColumnType("bit");

                    b.Property<int>("LayerCount")
                        .HasColumnType("int");

                    b.Property<string>("RackName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("RakType")
                        .HasColumnType("int");

                    b.HasKey("RackId");

                    b.ToTable("Racks");
                });

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.RackLayer", b =>
                {
                    b.Property<int>("RackLayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RackLayerId"));

                    b.Property<string>("LayerSide")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("RackId")
                        .HasColumnType("int");

                    b.HasKey("RackLayerId");

                    b.HasIndex("RackId");

                    b.ToTable("RackLayers");
                });

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.SelfedProduct", b =>
                {
                    b.Property<int>("SelfedProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SelfedProductId"));

                    b.Property<string>("BarcodeImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InventoryId")
                        .HasColumnType("int");

                    b.Property<int>("RackId")
                        .HasColumnType("int");

                    b.Property<string>("SelfCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SelfQuantity")
                        .HasColumnType("int");

                    b.Property<int>("Sold")
                        .HasColumnType("int");

                    b.HasKey("SelfedProductId");

                    b.HasIndex("InventoryId");

                    b.HasIndex("RackId");

                    b.ToTable("SelfedProducts");
                });

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.SellPackage", b =>
                {
                    b.Property<int>("SellPackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SellPackageId"));

                    b.Property<string>("SellPackageName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("SellPackageId");

                    b.ToTable("SellPackages");
                });

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.SellUnit", b =>
                {
                    b.Property<int>("SellUnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SellUnitId"));

                    b.Property<int>("ProductMeasurementId")
                        .HasColumnType("int");

                    b.Property<string>("SellUnitName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("SellUnitId");

                    b.HasIndex("ProductMeasurementId");

                    b.ToTable("SellUnits");
                });

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.SubCategory", b =>
                {
                    b.Property<int>("SubCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubCategoryId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("SubCategoryName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("SubCategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierId"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ContactNo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.Inventory", b =>
                {
                    b.HasOne("EPOS.BlazorClient.Shared.Models.Product", "Product")
                        .WithMany("Inventories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EPOS.BlazorClient.Shared.Models.Supplier", "Supplier")
                        .WithMany("Inventories")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.OrderItem", b =>
                {
                    b.HasOne("EPOS.BlazorClient.Shared.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EPOS.BlazorClient.Shared.Models.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.Product", b =>
                {
                    b.HasOne("EPOS.BlazorClient.Shared.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EPOS.BlazorClient.Shared.Models.ProductMeasurement", "ProductMeasurement")
                        .WithMany()
                        .HasForeignKey("ProductMeasurementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("ProductMeasurement");
                });

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.RackLayer", b =>
                {
                    b.HasOne("EPOS.BlazorClient.Shared.Models.Rack", "Rack")
                        .WithMany("RackLayers")
                        .HasForeignKey("RackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rack");
                });

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.SelfedProduct", b =>
                {
                    b.HasOne("EPOS.BlazorClient.Shared.Models.Inventory", "Inventory")
                        .WithMany("SelfedProducts")
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EPOS.BlazorClient.Shared.Models.Rack", "Rack")
                        .WithMany("SelfedProducts")
                        .HasForeignKey("RackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventory");

                    b.Navigation("Rack");
                });

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.SellUnit", b =>
                {
                    b.HasOne("EPOS.BlazorClient.Shared.Models.ProductMeasurement", "ProductMeasurement")
                        .WithMany("SellUnits")
                        .HasForeignKey("ProductMeasurementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductMeasurement");
                });

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.SubCategory", b =>
                {
                    b.HasOne("EPOS.BlazorClient.Shared.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.Inventory", b =>
                {
                    b.Navigation("SelfedProducts");
                });

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.Product", b =>
                {
                    b.Navigation("Inventories");

                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.ProductMeasurement", b =>
                {
                    b.Navigation("SellUnits");
                });

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.Rack", b =>
                {
                    b.Navigation("RackLayers");

                    b.Navigation("SelfedProducts");
                });

            modelBuilder.Entity("EPOS.BlazorClient.Shared.Models.Supplier", b =>
                {
                    b.Navigation("Inventories");
                });
#pragma warning restore 612, 618
        }
    }
}
