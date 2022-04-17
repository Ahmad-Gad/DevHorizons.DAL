Create Table [dbo].[ProductCategory]
(
	[ProductCategoryId] Int Not Null Constraint [PK_ProductCategory] Primary Key,
	[ProductCategoryName] nVarChar(500) Not Null,
	[ParentProductCategory] HierarchyId Not Null,
	[Active] Bit Not Null Constraint [DF_ProductCategory_Active] Default(1),
	[Events] nVarChar(Max) Not Null,
	[Description] nVarChar(500) Null
);
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
				"ParentProductCategory": "/1/1/"
				"Description": "ABC",
				"Stauts":"1,
			}
		]
	}
*/