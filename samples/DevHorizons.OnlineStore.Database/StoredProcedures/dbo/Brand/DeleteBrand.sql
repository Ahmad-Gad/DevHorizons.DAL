Create Procedure [dbo].[DeleteBrand]
(
	@brandId Int,
	@userId Int,
	@reason nVarChar(500)
)
As
Begin
	Set XACT_ABORT On;
	Begin Transaction [DeleteBrand]
	Begin Try
		Declare @deletedModule nVarChar(Max) = (Select * From [dbo].[Brand] Where [BrandId] = @brandId For Json Auto);
		Insert Into [dbo].[DeletedModules] ([ModuleType], [Module], [UserId], [Notes]) Values ('Brand', @deletedModule, @userId, @reason);
		Delete From [dbo].[Brand] Where [BrandId] = @brandId;
		Commit Transaction [DeleteBrand];
	End Try
	Begin Catch
		Rollback Transaction [DeleteBrand];
	End Catch;
	
	Return @@RowCount;
End;
