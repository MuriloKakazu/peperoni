CREATE FUNCTION [SearchOrdersByAccount] (
	@accountId GUID
)
RETURNS TABLE AS RETURN (
	SELECT *
	FROM   [Order]
	WHERE  AccountId = @accountId
)
