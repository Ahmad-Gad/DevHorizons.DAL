Create Table [dbo].[Product]
(
	[ProductId] Int Identity Not Null Constraint [PK_Product] Primary Key,
	[ProductGuid] UniqueIdentifier Constraint DF_Products_ProductGuid Default(NewID()) Not Null,
	[ProductName] nVarChar(200) Not Null,
	[ProductCategories] nVarChar(Max) Not Null,
	[ProductBrands] nVarChar(Max) Not Null,
	[DetailsStructure] nVarChar(Max) Not Null,
	[Active] Bit Not Null Constraint [DF_Product_Active] Default(1),
	[Events] nVarChar(Max) Not Null,
	[Description] nVarChar(500) Null
);
/*
	[ProductCategories] { [1, 3 , 5] }
	[ProductBrands] { [2, 3, 7] }
	[DetailsStructure] 
	{
		"Sections":
		{
			"Name": "Specifications",
			"Properties":
			{
				["Length", "Color", "etc"]
			}
		}				
	}
*/

/*
	[Events]
	{
		[
			{
				"Created": "12/12/2000 15:00:00.555"
			},
			{
				"Updated": "12/12/2000 15:00:00.555",
				"Name": "X",
				"Stauts":"1,
				"Description": "ABC",
				"ProductCategories": {},
				"ProductBrands" : {},
				"DetailsStructure": {}
			}
		]
	}
*/