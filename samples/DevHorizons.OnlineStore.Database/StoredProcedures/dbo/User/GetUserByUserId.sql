Create Procedure [dbo].[GetUserByUserId]
(
	@userId Int
)
As
Begin
	Select * From [dbo].[User] Where [UserId] = @userId;
End;