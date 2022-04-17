Create Procedure [dbo].[VerifyLogin]
(
	@email nVarChar(500) = Null,
	@userName nVarChar(200) = Null,
	@password VarChar(500)
)
As
Begin
	If ((@email Is Null Or Trim(@email) = '') And (@userName Is Null Or Trim(@userName) = ''))
	Begin
		Return -1;
	End;

	Declare @active Bit;
	Declare @locked Bit;
	Declare @existingPassword VarChar(500);
	If (@email Is Not Null)
	Begin
		Select @existingPassword = [Password], @active = [Active], @locked = [Locked]  From [dbo].[User] Where [Email] = @email;
	End
	Else
	Begin
		Select @existingPassword = [Password], @active = [Active], @locked = [Locked]  From [dbo].[User] Where [UserName] = @userName;
	End;

	Return [dbo].[GetLoginVerififcationStatus](@password, @existingPassword, @active, @locked);
End;
