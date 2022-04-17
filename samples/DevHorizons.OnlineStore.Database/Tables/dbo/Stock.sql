Create Table [dbo].[Stock]
(
	[StockId] Int Not Null Constraint [PK_Stock] Primary Key,
	[Title] nVarChar(500) Not Null,
	[ProductID] Int Not Null Constraint [FK_Stock_Product] Foreign Key References [dbo].[Product]([ProductId]),
	[Details] nVarChar(Max) Not Null,
	[Quntity] Int Not Null,
	[MaxSaleQuantity] Int Not Null Constraint [DF_Stock_MaxSaleQuantity] Default(0), -- Unlimited per single purchase.
	[Active] Bit Not Null Constraint [DF_Stock_Active] Default(0), -- Inactive by default. Needs review/process for manual/auotmatic activation.
	[Events] nVarChar(Max) Not Null
);
