CREATE FUNCTION [dbo].[GetOrderById] (
	@id CHAR(32)
)
RETURNS TABLE AS RETURN (
	SELECT 
			Id, AccountId, Status, PaymentStatus, PlaceDate, DeliveryDate, TotalPrice
	FROM    [Order]
	WHERE	Id = @id
)
