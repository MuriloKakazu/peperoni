CREATE TABLE [dbo].[Pizza]
(
	[Id] CHAR(32) NOT NULL PRIMARY KEY, 
    [OrderId] CHAR(32) NOT NULL, 
    [FirstToppingId] CHAR(32) NOT NULL, 
    [SecondToppingId] CHAR(32) NOT NULL, 
    [BorderId] CHAR(32) NOT NULL,
    [Quantity] INT NOT NULL DEFAULT 0, 
    [UnitPrice] MONEY NOT NULL DEFAULT 0.00, 
    [TotalPrice] MONEY NULL DEFAULT 0.00
)
