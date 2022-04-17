Create Procedure [dbo].[AddBulkUsers]
(
	@usersList [Type].[User] ReadOnly
)
As
Begin
	Insert Into [dbo].[User]
	(
		[Email],
		[UserName],
		[FirstName],
		[MiddleName],
		[LastName],
		[DisplayName],
		[Profile],
		[Active],
		[Password]
	)
	Select 
		[Email],
		[UserName],
		[FirstName],
		[MiddleName],
		[LastName],
		[DisplayName],
		[Profile],
		[Active],
		[Password]
		From @usersList;

	Return @@RowCount;
End;
