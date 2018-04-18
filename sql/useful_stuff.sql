drop procedure dbo.spConfirmPendingOrder;
CREATE procedure [dbo].[spConfirmPendingOrder]
(
	@orderId as int
)

AS
	declare @productID int;
	declare @quantity int;
Begin
	select @productID = ProductID from PendingOrders where OrderID = @orderId;
	select @quantity = Quantity from PendingOrders where OrderID = @orderId;

	if @quantity > (select Quantity from Products where ProductID = @productID) 
		print 'Current order can''t be accepted as there is not enough stock. Make an order to the HQ and then you''ll be able to confirm this order.';
	else begin;
		INSERT INTO Orders 
		SELECT *
		FROM [PendingOrders]
		WHERE @orderId=[PendingOrders].OrderID;

		delete from PendingOrders
		where OrderID=@orderId
		update Products 
		set Quantity = Quantity - @Quantity
		where ProductID = @productID;
	end;
End



drop procedure spCreatePendingOrder;
CREATE procedure [dbo].[spCreatePendingOrder]
(
	
	@ClientID as int,
    @EmployeeID as int,
    @ProductID as int,
    @Quantity as int,
    @Date as date,
    @ShipperID as int
)

AS
Begin

	if @Quantity > (select Quantity from Products where ProductID = @ProductID)
		print 'There is not so much stock, try a smaller order. Thanks.';
	else
		begin;
		declare @Id as int 

		select @Id = (MAX(OrderID)+1 )
		from Orders
	
		declare @IdPending as int 

		select @IdPending = (MAX(OrderID)+1 )
		from PendingOrders

		INSERT INTO PendingOrders (OrderID, ClientID, EmployeeID, ProductID,Quantity,Date,ShipperID)
		VALUES (dbo.InlineMax(@Id, @IdPending), @ClientID, @EmployeeID,@ProductID,@Quantity,@Date,@ShipperID);
		end;
End




create function dbo.InlineMax(@val1 int, @val2 int)
returns int
as
begin
  if @val1 > @val2
    return @val1
  return isnull(@val2,@val1)
end





INSERT [dbo].[Clients] ([ClientID], [City], [Name], [PreferedFormat]) VALUES (1, 'Kraków', 'Wedel', 'Liquid')
INSERT [dbo].[Clients] ([ClientID], [City], [Name], [PreferedFormat]) VALUES (2, N'Warszawa', N'Mondelez', N'Liquid')
INSERT [dbo].[Clients] ([ClientID], [City], [Name], [PreferedFormat]) VALUES (3, N'Białystok', N'Ambasador', N'Solid')
INSERT [dbo].[Clients] ([ClientID], [City], [Name], [PreferedFormat]) VALUES (4, N'Warszawa', N'Blikle', N'Solid')
INSERT [dbo].[Clients] ([ClientID], [City], [Name], [PreferedFormat]) VALUES (5, N'Łódź', N'Piekarenka', N'Solid')
INSERT [dbo].[Clients] ([ClientID], [City], [Name], [PreferedFormat]) VALUES (6, N'Kraków', N'ChocoWorld', N'Liquid')
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [Age], [Position], [Salary], [DateOfHire]) VALUES (1, N'Roman     ', N'Wacha     ', 31, N'KeyAccount', 8000, CAST(N'2000-01-01' AS Date))
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [Age], [Position], [Salary], [DateOfHire]) VALUES (2, N'Janusz    ', N'Nosacz    ', 24, N'Sales Rep ', 3500, CAST(N'2005-04-05' AS Date))
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [Age], [Position], [Salary], [DateOfHire]) VALUES (3, N'Grażyna   ', N'Nosek     ', 38, N'Accountant', 19000, CAST(N'2007-01-09' AS Date))
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [Age], [Position], [Salary], [DateOfHire]) VALUES (4, N'Wiesław   ', N'Bąk       ', 45, N'Sales Rep ', 3800, CAST(N'2001-05-19' AS Date))
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [Age], [Position], [Salary], [DateOfHire]) VALUES (5, N'Sławomir  ', N'Ryba      ', 37, N'Logistics ', 3500, CAST(N'2003-06-10' AS Date))
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [Age], [Position], [Salary], [DateOfHire]) VALUES (6, N'Adam      ', N'Wąski     ', 32, N'IT        ', 3200, CAST(N'2012-03-01' AS Date))
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [Age], [Position], [Salary], [DateOfHire]) VALUES (7, N'Sebastian ', N'Łysiewicz ', 52, N'Lawyer    ', 8000, CAST(N'2017-08-08' AS Date))
INSERT [dbo].[Employees] ([EmployeeID], [FirstName], [LastName], [Age], [Position], [Salary], [DateOfHire]) VALUES (8, N'Krystyna  ', N'Wąs       ', 62, N'Logistics ', 3000, CAST(N'2017-11-26' AS Date))
INSERT [dbo].[Orders] ([OrderID], [ClientID], [EmployeeID], [ProductID], [Quantity], [Date], [ShipperID]) VALUES (1, 2, 2, 3, 500, CAST(N'2016-12-21' AS Date), 1)
INSERT [dbo].[Orders] ([OrderID], [ClientID], [EmployeeID], [ProductID], [Quantity], [Date], [ShipperID]) VALUES (2, 3, 4, 2, 270, CAST(N'2016-11-11' AS Date), 3)
INSERT [dbo].[Orders] ([OrderID], [ClientID], [EmployeeID], [ProductID], [Quantity], [Date], [ShipperID]) VALUES (3, 1, 2, 1, 1000, CAST(N'2017-11-11' AS Date), 2)
INSERT [dbo].[Orders] ([OrderID], [ClientID], [EmployeeID], [ProductID], [Quantity], [Date], [ShipperID]) VALUES (4, 4, 4, 4, 100, CAST(N'2018-02-01' AS Date), 1)
INSERT [dbo].[Orders] ([OrderID], [ClientID], [EmployeeID], [ProductID], [Quantity], [Date], [ShipperID]) VALUES (5, 1, 2, 2, 200, CAST(N'2018-01-15' AS Date), 2)
INSERT [dbo].[Orders] ([OrderID], [ClientID], [EmployeeID], [ProductID], [Quantity], [Date], [ShipperID]) VALUES (6, 3, 4, 4, 300, CAST(N'2017-03-25' AS Date), 3)
INSERT [dbo].[Orders] ([OrderID], [ClientID], [EmployeeID], [ProductID], [Quantity], [Date], [ShipperID]) VALUES (7, 2, 2, 1, 200, CAST(N'2017-06-27' AS Date), 2)
INSERT [dbo].[Orders] ([OrderID], [ClientID], [EmployeeID], [ProductID], [Quantity], [Date], [ShipperID]) VALUES (8, 4, 4, 3, 100, CAST(N'2017-08-08' AS Date), 3)
INSERT [dbo].[Orders] ([OrderID], [ClientID], [EmployeeID], [ProductID], [Quantity], [Date], [ShipperID]) VALUES (9, 2, 3, 2, 500, CAST(N'2018-06-16' AS Date), 2)
INSERT [dbo].[Orders] ([OrderID], [ClientID], [EmployeeID], [ProductID], [Quantity], [Date], [ShipperID]) VALUES (10, 2, 2, 3, 2, CAST(N'2010-10-01' AS Date), 1)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Type], [Quantity], [Price], [Cost]) VALUES (1, N'Callebaut ', N'Dark      ', 1500, 520, 370)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Type], [Quantity], [Price], [Cost]) VALUES (2, N'Ashanti   ', N'Dark      ', 1500, 820, 420)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Type], [Quantity], [Price], [Cost]) VALUES (3, N'Vahlrona  ', N'Milk      ', 1500, 380, 350)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Type], [Quantity], [Price], [Cost]) VALUES (4, N'Hersheys  ', N'White     ', 1500, 740, 580)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Type], [Quantity], [Price], [Cost]) VALUES (5, N'GhanaSpec ', N'Dark      ', 1500, 800, 500)
INSERT [dbo].[Products] ([ProductID], [ProductName], [Type], [Quantity], [Price], [Cost]) VALUES (6, N'Brasilica ', N'Milk      ', 1500, 615, 315)
INSERT [dbo].[Shippers] ([ShipperID], [Name], [City], [CostPerTon]) VALUES (1, N'Raben     ', N'Warszawa  ', 10)
INSERT [dbo].[Shippers] ([ShipperID], [Name], [City], [CostPerTon]) VALUES (2, N'DHL       ', N'Kraków    ', 8)
INSERT [dbo].[Shippers] ([ShipperID], [Name], [City], [CostPerTon]) VALUES (3, N'UPS       ', N'Gdańsk    ', 12)
INSERT [dbo].[Shippers] ([ShipperID], [Name], [City], [CostPerTon]) VALUES (4, N'Maersk    ', N'Poznań    ', 17)
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Clients] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Clients] ([ClientID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Clients]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Employees]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Products]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Shippers] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Shippers] ([ShipperID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Shippers]
GO







CREATE TABLE [dbo].[PendingOrders](
	[OrderID] [int] NOT NULL,
	[ClientID] [int] NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[ShipperID] [int] NOT NULL
) ON [PRIMARY]
GO