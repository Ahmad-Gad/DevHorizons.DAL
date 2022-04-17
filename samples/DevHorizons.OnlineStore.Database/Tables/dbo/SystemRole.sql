Create Table [dbo].[SystemRole]
(
	[SystemRoleId] Int Not Null Identity(1, 1) Constraint [PK_SystemRole] Primary Key,
	[SystemRoleName] nVarChar(200) Not Null Constraint [UQ_SystemRole_SystemRoleName] Unique,
	[SubRoles] nVarChar(Max) Null,
	[Active] Bit Not Null Constraint [DF_SystemRole_Active] Default(0), -- Inactive by default. Needs review/process for manual/auotmatic activation.
	[Events] nVarChar(Max) Not Null
);

/*
	[SubRoles]
	{
		[ 1, 2, 3 ]
	}
*/