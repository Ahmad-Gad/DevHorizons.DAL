Create Table [dbo].[SystemUser]
(
	[UserId] Int Not Null Identity(1, 1) Constraint [PK_SystemUser] Primary Key,
	[Email] nVarChar(500) Not Null Constraint [UQ_SystemUser_Email] Unique,
	[UserName] nVarChar(200) Not Null Constraint [UQ_SystemUser_UserName] Unique,
	[FirstName] nVarChar(200) Not Null,
	[MiddleName] nVarChar(200) Null,
	[LastName] nVarChar(200) Not Null,
	[DisplayName] nVarChar(200) Not Null,
	[Address] nVarChar(Max),
	[SystemRoles] nVarChar(Max) Not Null,
	[Locked] Bit Not Null Constraint [DF_SystemUser_Locked] Default(0),
	[Password] nVarChar(500) Not Null,
	[Active] Bit Not Null Constraint [DF_SystemUser_Active] Default(0), -- Inactive by default. Needs review/process for manual/auotmatic activation.
	[Events] VarChar(Max) Not Null
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