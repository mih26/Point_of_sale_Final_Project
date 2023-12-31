USE [epos]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description]) VALUES (1, N'Toiletries', N'Care items')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description]) VALUES (2, N'Baby care', N'Baby care')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName], [Description]) VALUES (3, N'Body care', N'Body care')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductMeasurements] ON 

INSERT [dbo].[ProductMeasurements] ([ProductMeasurementId], [BaseTypeName]) VALUES (1, N'Weight')
INSERT [dbo].[ProductMeasurements] ([ProductMeasurementId], [BaseTypeName]) VALUES (2, N'Volume')
INSERT [dbo].[ProductMeasurements] ([ProductMeasurementId], [BaseTypeName]) VALUES (3, N'No(s)')
INSERT [dbo].[ProductMeasurements] ([ProductMeasurementId], [BaseTypeName]) VALUES (4, N'Dozens')
SET IDENTITY_INSERT [dbo].[ProductMeasurements] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [Size], [Color], [Weight], [Quantity], [isOffering], [OfferType], [OfferDescription], [ProductName], [UniqueCode], [InventoryCode], [CategoryId], [ProductMeasurementId], [SellUnitId], [PerItemUnitValue], [Description], [UnitPrice], [Picture], [BarCodeImage]) VALUES (1, NULL, NULL, 200, NULL, 0, NULL, NULL, N'Johnson;s baby loation', NULL, NULL, 2, 2, 5, N'200', N'Baby ltion', 150.0000, N'3udraar1.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [Size], [Color], [Weight], [Quantity], [isOffering], [OfferType], [OfferDescription], [ProductName], [UniqueCode], [InventoryCode], [CategoryId], [ProductMeasurementId], [SellUnitId], [PerItemUnitValue], [Description], [UnitPrice], [Picture], [BarCodeImage]) VALUES (2, NULL, NULL, 200, NULL, 0, NULL, NULL, N'BioB body lotion', NULL, NULL, 3, 2, 5, N'200', N'Body care', 100.0000, N'slabdiaz.jpg', NULL)
INSERT [dbo].[Products] ([ProductId], [Size], [Color], [Weight], [Quantity], [isOffering], [OfferType], [OfferDescription], [ProductName], [UniqueCode], [InventoryCode], [CategoryId], [ProductMeasurementId], [SellUnitId], [PerItemUnitValue], [Description], [UnitPrice], [Picture], [BarCodeImage]) VALUES (3, NULL, NULL, 200, NULL, 0, NULL, NULL, N'Nivea body loation', NULL, NULL, 3, 2, 5, N'200', N'Nivea', 230.0000, N'ksonaraa.jpg', NULL)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [OrderDate], [CustomerName], [Phone], [PaymentVia], [OrderAmount]) VALUES (2, CAST(N'2023-03-08T22:24:27.813' AS DateTime), N'Asaduzzaman', N'01764364833', N'Cash', 571.3000)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderItems] ON 

INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity]) VALUES (3, 2, 1, 1)
INSERT [dbo].[OrderItems] ([OrderItemId], [OrderId], [ProductId], [Quantity]) VALUES (4, 2, 1, 1)
SET IDENTITY_INSERT [dbo].[OrderItems] OFF
GO
SET IDENTITY_INSERT [dbo].[SellUnits] ON 

INSERT [dbo].[SellUnits] ([SellUnitId], [SellUnitName], [ProductMeasurementId]) VALUES (1, N'Kg', 1)
INSERT [dbo].[SellUnits] ([SellUnitId], [SellUnitName], [ProductMeasurementId]) VALUES (2, N'G', 1)
INSERT [dbo].[SellUnits] ([SellUnitId], [SellUnitName], [ProductMeasurementId]) VALUES (3, N'Mg', 1)
INSERT [dbo].[SellUnits] ([SellUnitId], [SellUnitName], [ProductMeasurementId]) VALUES (4, N'L', 2)
INSERT [dbo].[SellUnits] ([SellUnitId], [SellUnitName], [ProductMeasurementId]) VALUES (5, N'Ml', 2)
INSERT [dbo].[SellUnits] ([SellUnitId], [SellUnitName], [ProductMeasurementId]) VALUES (6, N'No(s)', 3)
INSERT [dbo].[SellUnits] ([SellUnitId], [SellUnitName], [ProductMeasurementId]) VALUES (7, N'Dozen(s)', 4)
SET IDENTITY_INSERT [dbo].[SellUnits] OFF
GO
SET IDENTITY_INSERT [dbo].[Racks] ON 

INSERT [dbo].[Racks] ([RackId], [RackName], [RakType], [LayerCount], [IsTopOpen]) VALUES (1, N'REC-1', 5, 3, 0)
INSERT [dbo].[Racks] ([RackId], [RackName], [RakType], [LayerCount], [IsTopOpen]) VALUES (2, N'REC=2', 5, 3, 0)
SET IDENTITY_INSERT [dbo].[Racks] OFF
GO
SET IDENTITY_INSERT [dbo].[RackLayers] ON 

INSERT [dbo].[RackLayers] ([RackLayerId], [LayerSide], [RackId]) VALUES (1, N'Left', 1)
INSERT [dbo].[RackLayers] ([RackLayerId], [LayerSide], [RackId]) VALUES (2, N'Right', 1)
INSERT [dbo].[RackLayers] ([RackLayerId], [LayerSide], [RackId]) VALUES (3, N'Left', 2)
INSERT [dbo].[RackLayers] ([RackLayerId], [LayerSide], [RackId]) VALUES (4, N'Right', 2)
SET IDENTITY_INSERT [dbo].[RackLayers] OFF
GO
SET IDENTITY_INSERT [dbo].[Suppliers] ON 

INSERT [dbo].[Suppliers] ([SupplierId], [CompanyName], [ContactName], [ContactNo]) VALUES (1, N'ABC Corporation', N'MDB PREPAID CARD', N'01786XXXXXX')
INSERT [dbo].[Suppliers] ([SupplierId], [CompanyName], [ContactName], [ContactNo]) VALUES (2, N'Bugs Bunny', N'BB Bunny', N'01810XXXXXX')
SET IDENTITY_INSERT [dbo].[Suppliers] OFF
GO
SET IDENTITY_INSERT [dbo].[Inventories] ON 

INSERT [dbo].[Inventories] ([InventoryId], [InventoryCode], [InDate], [SupplierId], [ProductId], [Quantity], [UnitPrice], [SelfPrice], [OnSelf]) VALUES (1, N'001-047124-001', CAST(N'2023-03-02' AS Date), 1, 1, 20, 230.0000, 290.0000, 20)
INSERT [dbo].[Inventories] ([InventoryId], [InventoryCode], [InDate], [SupplierId], [ProductId], [Quantity], [UnitPrice], [SelfPrice], [OnSelf]) VALUES (2, N'002-017105-002', CAST(N'2023-03-05' AS Date), 2, 2, 50, 250.0000, 310.0000, 10)
INSERT [dbo].[Inventories] ([InventoryId], [InventoryCode], [InDate], [SupplierId], [ProductId], [Quantity], [UnitPrice], [SelfPrice], [OnSelf]) VALUES (3, N'003-091858-001', CAST(N'2023-03-07' AS Date), 1, 3, 100, 200.0000, 300.0000, 10)
SET IDENTITY_INSERT [dbo].[Inventories] OFF
GO
SET IDENTITY_INSERT [dbo].[SelfedProducts] ON 

INSERT [dbo].[SelfedProducts] ([SelfedProductId], [SelfCode], [InventoryId], [RackId], [SelfQuantity], [Sold], [BarcodeImage]) VALUES (2, N'001-070848-001', 1, 1, 20, 2, N'2non3k2f.png')
INSERT [dbo].[SelfedProducts] ([SelfedProductId], [SelfCode], [InventoryId], [RackId], [SelfQuantity], [Sold], [BarcodeImage]) VALUES (3, N'002-043486-002', 2, 2, 10, 0, N'quq20qw1.png')
INSERT [dbo].[SelfedProducts] ([SelfedProductId], [SelfCode], [InventoryId], [RackId], [SelfQuantity], [Sold], [BarcodeImage]) VALUES (4, N'003-082588-001', 3, 1, 10, 0, N'0jm0fgoc.png')
SET IDENTITY_INSERT [dbo].[SelfedProducts] OFF
GO
SET IDENTITY_INSERT [dbo].[SellPackages] ON 

INSERT [dbo].[SellPackages] ([SellPackageId], [SellPackageName]) VALUES (1, N'Ploy Back')
INSERT [dbo].[SellPackages] ([SellPackageId], [SellPackageName]) VALUES (2, N'Paper Box')
INSERT [dbo].[SellPackages] ([SellPackageId], [SellPackageName]) VALUES (3, N'Plastic box')
INSERT [dbo].[SellPackages] ([SellPackageId], [SellPackageName]) VALUES (4, N'Tetrapack')
INSERT [dbo].[SellPackages] ([SellPackageId], [SellPackageName]) VALUES (5, N'Box')
INSERT [dbo].[SellPackages] ([SellPackageId], [SellPackageName]) VALUES (6, N'Wrapped')
INSERT [dbo].[SellPackages] ([SellPackageId], [SellPackageName]) VALUES (7, N'Can')
INSERT [dbo].[SellPackages] ([SellPackageId], [SellPackageName]) VALUES (8, N'Free')
SET IDENTITY_INSERT [dbo].[SellPackages] OFF
GO
