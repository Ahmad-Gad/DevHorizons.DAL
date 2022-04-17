Create Procedure [dbo].[AddBrand]
(
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

	Declare @event nVarChar(Max) = N'{"Events":[{"Action":0, "ActionDate":"' + Cast(GetDate() As nVarChar) + '", "BrandName": "' + @brandName + '", "Description": ' + @description + ', "Active": ' + Cast(@active As nVarChar) + ', "DbUser": "' + SUSER_NAME() + '", "UserId": ' + Cast(@userId As nVarChar) + '}]}';
	Insert Into [dbo].[Brand] 
		(
			[BrandName],
			[Description],
			[Active],
			[Events]
		)
		Values
		(
			@brandName,
			@description,
			@active,
			@event
		);

	Return @@RowCount;
End;
