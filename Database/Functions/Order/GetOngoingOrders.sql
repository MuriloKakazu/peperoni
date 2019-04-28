CREATE FUNCTION [GetOngoingOrders] ()
RETURNS TABLE AS RETURN (
	SELECT *
	FROM   [Order]
	WHERE  Status IN ('Enqueued', 'InProgress', 'Ready')
)
