Create Procedure [dbo].[GetBrand]
(
	@brandId Int = Null,
	@brandName nVarChar(200) = Null,
	@exactMatch Bit = 1
)
As
Begin
	Set NOCOUNT Off;
	
	If (@brandId Is Not Null)
	Begin
		Select 
			[BrandId],
			[BrandName],
			[Description],
			[Active],
			Json_Value([Events], '$.Events[0].UserId') As [UserId],
			[dbo].[GetUserNameById](Json_Value([Events], '$.Events[0].UserId')) As [UserName],
			[dbo].[GetUserDisplayNameById](Json_Value([Events], '$.Events[0].UserId')) As [UserDisplayName]
		From [dbo].[Brand]
		Where [BrandId] = @brandId;
	End
	Else If (@brandName Is Not Null)
	Begin
		If (@exactMatch = 1)
			Begin
				Select 
					[BrandId],
					[BrandName],
					[Description],
					[Active],
					Json_Value([Events], '$.Events[0].UserId') As [UserId],
					[dbo].[GetUserNameById](Json_Value([Events], '$.Events[0].UserId')) As [UserName],
					[dbo].[GetUserDisplayNameById](Json_Value([Events], '$.Events[0].UserId')) As [UserDisplayName]
				From [dbo].[Brand]
				Where [BrandName] = @brandName;
			End
			Else
			Begin
				Select 
					[BrandId],
					[BrandName],
					[Description],
					[Active],
					Json_Value([Events], '$.Events[0].UserId') As [UserId],
					[dbo].[GetUserNameById](Json_Value([Events], '$.Events[0].UserId')) As [UserName],
					[dbo].[GetUserDisplayNameById](Json_Value([Events], '$.Events[0].UserId')) As [UserDisplayName]
				From [dbo].[Brand]
				Where [BrandName] Like '%' + @brandName + '%';
			End
	End
	Else
	Begin
		Select 
			[BrandId],
			[BrandName],
			[Description],
			[Active],
			Json_Value([Events], '$.Events[0].UserId') As [UserId],
			[dbo].[GetUserNameById](Json_Value([Events], '$.Events[0].UserId')) As [UserName],
			[dbo].[GetUserDisplayNameById](Json_Value([Events], '$.Events[0].UserId')) As [UserDisplayName]
		From [dbo].[Brand];
	End;
End;