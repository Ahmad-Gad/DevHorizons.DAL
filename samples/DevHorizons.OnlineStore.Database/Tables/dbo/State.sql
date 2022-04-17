Create Table [dbo].[State]
(
	[StateId] Int Not Null Identity(1, 1) Constraint [PK_State] Primary Key,
	[StateName] nVarChar(200) Not Null,
	[CountryId] Int Not Null Constraint [FK_State_Country] Foreign Key References [dbo].[Country]([CountryId]),
	[Active] Bit Not Null Constraint [DF_State_Active] Default(0), -- Inactive by default. Needs review/process for manual/auotmatic activation.
	[Events] nVarChar(Max) Not Null,
	Constraint [UQ_City_StateName_CountryId] Unique ([StateName], [CountryId])
);