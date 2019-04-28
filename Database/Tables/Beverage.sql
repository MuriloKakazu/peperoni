CREATE TABLE [Beverage]
(
	[Id] GUID NOT NULL PRIMARY KEY, 
    [OrderId] GUID NOT NULL, 
    [ProductId] GUID NOT NULL, 
    [Quantity] INT NOT NULL, 
    [UnitPrice] MONEY NOT NULL DEFAULT 0.0, 
    [TotalPrice] MONEY NOT NULL DEFAULT 0.0
)
