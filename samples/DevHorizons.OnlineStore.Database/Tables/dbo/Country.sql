Create Table [dbo].[Country]
(
	[CountryId] Int Not Null Identity(1, 1) Constraint [PK_Country] Primary Key,
	[CountryName] nVarChar(200) Not Null Constraint [UQ_Country_CountryName] Unique,
	[Active] Bit Not Null Constraint [DF_Country_Active] Default(0), -- Inactive by default. Needs review/process for manual/auotmatic activation.
	[Events] nVarChar(Max) Not Null
);