Create Table [dbo].[DeletedModules]
(
	[ModuleType] nVarChar(200) Not Null,
	[DeletedOn] DateTime Not Null Constraint [FK_DeletedModules_DeletedOn] Default(GetDate()),
	[Module] nVarChar(Max) Not Null,
	[UserId] Int Not Null Constraint [FK_DeletedModules] Foreign Key References [dbo].[User] ([UserId]),
	[DbUser] nVarChar(256) Not Null Constraint [DF_DeletedModules_DbUser] Default(SUSER_NAME()),
	[Notes] nVarChar(1000) Not Null,
	Constraint [PK_DeletedModules] Primary Key ([ModuleType], [DeletedOn])
)
