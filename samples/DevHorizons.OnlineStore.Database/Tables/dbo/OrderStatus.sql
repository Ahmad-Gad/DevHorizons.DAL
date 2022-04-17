Create Table [dbo].[OrderStatus]
(
	[OrderStatusId] SmallInt Not Null Constraint [PK_OrderStatus] Primary Key,
	[OrderStatusName] nVarChar(200) Not Null,
	[Description] nVarChar(500) Null,
	[Active] Bit Not Null Constraint [DF_OrderStatus_Active] Default(1),
	[Events] nVarChar(Max) Not Null
);

/*
	 -- [0 Pending | -1 AutoRejected | -2 ManualRejected | -3 User Cancelled | ]
*/