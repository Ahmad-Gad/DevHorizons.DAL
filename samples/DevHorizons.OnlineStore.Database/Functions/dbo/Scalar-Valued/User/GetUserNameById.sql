Create Function [dbo].[GetUserNameById]
(
	@UserId Int
)
Returns nVarChar(200)
As
Begin
	Return (Select [UserName] From [dbo].[User] Where [UserId] = @UserId);
End;