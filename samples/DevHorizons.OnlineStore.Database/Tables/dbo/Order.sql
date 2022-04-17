Create Table [dbo].[Order]
(
	[OrderId] BigInt Not Null Constraint [PK_Order] Primary Key,
	[OrderDate] DateTime2(3) Not Null Constraint [DF_Order_OrderDate] Default(GetDate()),
	[UserId] Int Not Null Constraint [FK_Order_User] Foreign Key References [dbo].[User]([UserId]),
	[OrderDetails] nVarChar(Max) Not Null,
	[OrderStatusHistory] nVarChar(Max) Not Null
)
/*
	[OrderStatusHistory]
	{
		[
			{
				"StatusId": "3",
				"Updated" : "12/12/2012 12:12:12",
				"Notes" : ""
			}
		]
	}
*/
