CREATE TABLE [dbo].[Beverage]
(
	[Id] CHAR(32) NOT NULL PRIMARY KEY, 
    [OrderId] CHAR(32) NOT NULL, 
    [ProductId] CHAR(32) NOT NULL, 
    [Quantity] INT NOT NULL, 
    [UnitPrice] MONEY NOT NULL DEFAULT 0.0, 
    [TotalPrice] MONEY NOT NULL DEFAULT 0.0
)
