CREATE TABLE [Beverage]
(
	[Id] GUID NOT NULL PRIMARY KEY, 
    [OrderId] GUID NOT NULL, 
    [ProductId] GUID NOT NULL, 
    [Quantity] INT NOT NULL
)
