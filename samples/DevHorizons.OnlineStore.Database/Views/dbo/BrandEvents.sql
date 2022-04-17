Create View [dbo].[BrandEvents]
As
Select 
	[B].[BrandId],
	[E].[ActionDate],
	[E].[Action],
	[E].[BrandName],
	[E].[Description],
	[E].[Active],
	[E].[DbUser],
	[E].[UserId],
	[dbo].[GetUserNameById]([UserId]) As [UserName],
	[dbo].[GetUserDisplayNameById]([UserId]) As [UserDisplayName]
	From [dbo].[Brand] As [B]
	Outer Apply
	OpenJson([Events], N'$.Events') 
	With 
	(
		[ActionDate] DateTime2(0) '$.ActionDate',
		[Action] TinyInt '$.Action',
		[BrandName] nVarChar(200) '$.BrandName',
		[Description] nVarChar(500) '$.Description',
		[Active] Bit '$.Active',
		[DbUser] nVarChar(256) '$.DbUser',
		[UserId] Int '$.UserId'
	) As [E];