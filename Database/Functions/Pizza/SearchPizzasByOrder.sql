CREATE FUNCTION [SearchPizzasByOrder] (
	@orderId GUID
)
RETURNS TABLE AS RETURN (
	SELECT *
	FROM   [Pizza]
	WHERE  OrderId = @orderId
)
