Create Table [dbo].[Voucher]
(
	[VoucherId] Int Not Null Identity(1, 1) Constraint [PK_Voucher] Primary Key,
	[VoucherCode] nVarChar(100) Not Null,
	[Title] nVarChar(250),
	[StartDate] DateTime2(0) Not Null,
	[ExpiryDate] DateTime2(0) Not Null,
	[Details] nVarChar(Max) Not Null,
	[Active] Bit Not Null Constraint [DF_Voucher_Active] Default(0), -- Inactive by default. Needs review/process for manual/auotmatic activation.
	[Events] nVarChar(Max) Not Null
);

/*
	[StockID] {[ 5, 15, 7]} /* Qualified stocks which can be combined together */
	[Details]
	{
		[
			"ValuePerItem" : "5",
			"ValueTypePerItem" : 1, /* 1 >> Percent, 2 >>> Money Unit E.g 0.5 Euro, 1.0 Euro, 1.75 Euro, etc */
			"ValuePerOrder" : "5",
			"ValueTypePerOrder" : 1, /* 1 >> Percent, 2 >>> Money Unit E.g 0.5 Euro, 1.0 Euro, 1.75 Euro, etc */
			"MinOrder" : 0, /* No minimum limit */
			"MaxOrder" : 0, /* No maximum limit */
			"MaxPerUser" : 1, /* 0 >>> No maximum limit for the same user */
			"ExemptedUsers" : {},
			"ExemptedCountries" : {},
			"ExemptedStates" : {},
			"ExemptedCities" : {},
			"AllowedCountries" : {},
			"AllowedStates" : {},
			"AllowedCities" : {}
		]
	}
*/