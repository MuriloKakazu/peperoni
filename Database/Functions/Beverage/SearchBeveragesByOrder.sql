CREATE FUNCTION [SearchBeveragesByOrder] (
	@orderId GUID
)
RETURNS TABLE AS RETURN (
	SELECT *
	FROM   [Beverage]
	WHERE  OrderId = @orderId
)
