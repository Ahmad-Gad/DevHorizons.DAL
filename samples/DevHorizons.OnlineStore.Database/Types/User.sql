Create Type [Type].[User] As Table
(
	[Email] nVarChar(500) Not Null,
	[UserName] nVarChar(200) Not Null,
	[FirstName] nVarChar(200) Not Null,
	[MiddleName] nVarChar(200) Null,
	[LastName] nVarChar(200) Not Null,
	[DisplayName] nVarChar(200) Not Null,
	[Profile] nVarChar(Max),
	[Active] Bit Not Null,
	[Password] VarChar(500) Not Null
);
