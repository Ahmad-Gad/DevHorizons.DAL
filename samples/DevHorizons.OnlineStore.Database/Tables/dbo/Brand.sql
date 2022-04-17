Create Table [dbo].[Brand]
(
	[BrandId] Int Not Null Identity(1, 1) Constraint [PK_Brand] Primary Key,
	[BrandName] nVarChar(500) Not Null Constraint [UQ_Brand_BrandName] Unique,
	[Description] nVarChar(500) Null,
	[Active] Bit Not Null Constraint [DF_Brand_Active] Default(1),
	[Events] nVarChar(Max) Not Null
);
/*
	[Events]
	{
		[
			{
				"Action": 0 /* Created */
				"ActionDate": "12/12/2000 15:00:00.555"
			},
			{
				"Action" : 1, /* Updated */
				"ActionDate": "12/12/2000 15:00:00.555",
				"Name": "X",
				"Description": "ABC",
				"Stauts":"1,
			}
		]
	}
*/