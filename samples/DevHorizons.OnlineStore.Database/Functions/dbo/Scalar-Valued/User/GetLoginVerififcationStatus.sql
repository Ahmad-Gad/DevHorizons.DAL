Create Function [dbo].[GetLoginVerififcationStatus]
(
	@password VarChar(500),
	@existingPassword VarChar(500),
	@active Bit,
	@locked Bit
)
Returns Int
As
Begin
	Declare @status Int;
	If (@existingPassword Is Null)
	Begin
		Set @status = 1;
	End;
	Else If (@password = @existingPassword)
	Begin
		If (@active = 0 And @locked = 1)
		Begin
			Set @status = 7;
		End
		Else If (@active = 0)
		Begin
			Set @status = 4;
		End;
		Else If (@locked = 1)
		Begin
			Set @status = 3;
		End
		Else
		Begin
			Set @status = 0;
		End;
	End
	Else
	Begin
		Set @status = 2;
	End;

	Return @status;
End;
