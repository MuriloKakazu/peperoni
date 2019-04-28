CREATE TABLE [dbo].[Order]
(
	[Id] CHAR(32) NOT NULL PRIMARY KEY, 
    [AccountId] CHAR(32) NOT NULL, 
    [Status] VARCHAR(32) NULL DEFAULT 'Enqueued', 
    [PaymentStatus] VARCHAR(32) NULL DEFAULT 'Unpaid', 
    [PlaceDate] DATETIME NULL, 
    [DeliveryDate] DATETIME NULL, 
    [TotalPrice] MONEY NULL DEFAULT 0.00
)
