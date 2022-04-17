Create Table [dbo].[User]
(
	[UserId] Int Not Null Identity(1, 1) Constraint [PK_User] Primary Key,
	[Email] nVarChar(500) Not Null Constraint [UQ_User_Email] Unique,
	[UserName] nVarChar(200) Not Null Constraint [UQ_User_UserName] Unique,
	[FirstName] nVarChar(200) Not Null,
	[MiddleName] nVarChar(200) Null,
	[LastName] nVarChar(200) Not Null,
	[DisplayName] nVarChar(200) Not Null,
	[Profile] nVarChar(Max),
	[Active] Bit Not Null Constraint [DF_User_Active] Default(0), -- Inactive by default. Needs review/process for manual/auotmatic activation.
	[Locked] Bit Not Null Constraint [DF_User_Locked] Default(0),
	[Password] VarChar(500) Not Null,
	[Events] nVarChar(Max) Null
);
/*
	[Address] 
	{
		"Country" : "", -- Mandatory
		"City" : "", -- Mandatory
		"PostCode": "", -- Optional
		"Address": "", -- Mandatory
		"Mobile" : "", -- Mandatory
		"Phone": "" -- Optional
	}
*/