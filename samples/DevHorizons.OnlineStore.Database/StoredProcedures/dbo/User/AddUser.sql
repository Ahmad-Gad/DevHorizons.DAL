Create Procedure [dbo].[AddUser]
(
	@email nVarChar(500),
	@userName nVarChar(200),
	@firstName nVarChar(200),
	@middleName nVarChar(200) = Null,
	@lastName nVarChar(200),
	@displayName nVarChar(200),
	@profile nVarChar(Max),
	@active Bit,
	@password VarChar(500),
	@adminUserId Int,
	@userId Int Output,
	@events nVarChar(Max) Output
)
As
Begin
	-- Declare @event nVarChar(Max) = N'[{"Action":0, "ActionDate":"' + Cast(GetDate() As nVarChar) + '", "Email": "' + @email + '", "UserName": "' + @userName + '", "FirstName": "' + @firstName + '", "MiddleName": ' + IIF(@middleName Is Null, 'null', '"' + @middleName + '"') + ', "LastName": "' + @lastName + '", "DisplayName": "' + @displayName + '", "Profile": ' + @profile + ', "Active": ' + Cast(@active As nVarChar) + ', "Password": "' + @password  + '", "DbUser": "' + SUSER_NAME() + '", "AdminUserId": ' + Cast(@adminUserId As nVarChar) + '}]';
	Declare @event nVarChar(Max) = N'[{"Action":0, "ActionDate":"' + Cast(GetDate() As nVarChar) + '", "Email": "' + @email + '", "UserName": "' + @userName + '", "FirstName": "' + @firstName + '", "MiddleName": ' + IIF(@middleName Is Null, 'null', '"' + @middleName + '"') + ', "LastName": "' + @lastName + '", "DisplayName": "' + @displayName + '", "Active": ' + Cast(@active As nVarChar) + ', "Password": "' + @password  + '", "DbUser": "' + Replace(SUSER_NAME(), '\', '\\') + '", "AdminUserId": ' + Cast(@adminUserId As nVarChar) + '}]';
	Insert Into [dbo].[User]
	(
		[Email],
		[UserName],
		[FirstName],
		[MiddleName],
		[LastName],
		[DisplayName],
		[Profile],
		[Active],
		[Password],
		[Events]
	)
	Values
	(
		@email,
		@userName,
		@firstName,
		@middleName,
		@lastName,
		@displayName,
		@profile,
		@active,
		@password,
		@event
	);

	Set @events = @event;
	Set @userId = @@IDENTITY;
	Return @@RowCount;
End;
