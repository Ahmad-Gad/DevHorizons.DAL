Create Function [dbo].[GetUserDisplayNameById]
(
	@UserId Int
)
Returns nVarChar(200)
As
Begin
	Return (Select [DisplayName] From [dbo].[User] Where [UserId] = @UserId);
End;