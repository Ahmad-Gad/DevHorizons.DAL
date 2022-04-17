Create Procedure [dbo].[UpdateBrand]
(
	@brandId Int,
	@brandName nVarChar(200),
	@userId Int,
	@description nVarChar(500) = Null,
	@active Bit = 1
)
As
Begin
	If (@description Is Null)
	Begin
		Set @description = N'null';
	End
	Else
	Begin
		Set @description = N'"' + @description + N'"';
	End;

	Declare @event nVarChar(Max) = N'{"Events":[{"Action":1, "ActionDate":"' + Cast(GetDate() As nVarChar) + '", "BrandName": "' + @brandName + '", "Description": ' + @description + ', "Active": ' + Cast(@active As nVarChar) + ', "DbUser": "' + SUSER_NAME() + '", "UserId": ' + Cast(@userId As nVarChar) + '}]}';
	
	Update [dbo].[Brand] Set 
		[BrandName] = @brandName,
		[Description] = @description,
		[Active] = @active,
		[Events] = Json_Modify([Events], 'append $.Events', JSON_QUERY(@event))
	Where [BrandId] = @brandId;
	
	Return @@RowCount;
End;
