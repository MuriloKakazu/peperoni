CREATE TABLE [Order]
(
	[Id] GUID NOT NULL PRIMARY KEY, 
    [AccountId] GUID NOT NULL, 
    [Status] VARCHAR(32) NULL DEFAULT 'Enqueued', 
    [PaymentStatus] VARCHAR(32) NULL DEFAULT 'Unpaid', 
    [PlaceDate] DATETIME NULL, 
    [DeliveryDate] DATETIME NULL, 
    [TotalPrice] MONEY NOT NULL DEFAULT 0.00
)
