Create Procedure [dbo].[testGetAllBrands]
As
Begin
	Set NOCOUNT Off;
	Select
		[BrandId],
		[BrandName],
		[Description],
		[Active],
		[Events]
	From [dbo].[Brand];
End;