Create Table [dbo].[City]
(
	[CityId] Int Not Null Identity(1, 1) Constraint [PK_City] Primary Key,
	[CityName] nVarChar(200) Not Null,
	[StateId] Int Not Null Constraint [FK_City_State] Foreign Key References [dbo].[State]([StateId]),
	[Active] Bit Not Null Constraint [DF_City_Active] Default(0), -- Inactive by default. Needs review/process for manual/auotmatic activation.
	[Events] nVarChar(Max) Not Null,
	Constraint [UQ_City_CityName_StateId] Unique ([CityName], [StateId])
);