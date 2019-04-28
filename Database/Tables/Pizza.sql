CREATE TABLE [Pizza]
(
	[Id] GUID NOT NULL PRIMARY KEY, 
    [OrderId] GUID NOT NULL, 
    [FirstToppingId] GUID NOT NULL, 
    [SecondToppingId] GUID NOT NULL, 
    [BorderId] GUID NOT NULL,
    [Quantity] INT NOT NULL DEFAULT 0, 
    [UnitPrice] MONEY NOT NULL DEFAULT 0.00, 
    [TotalPrice] MONEY NULL DEFAULT 0.00
)
