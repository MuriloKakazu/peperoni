CREATE FUNCTION [GetBeverage] (
	@id GUID
)
RETURNS TABLE AS RETURN (
	SELECT *
	FROM   [Beverage]
	WHERE  Id = @id
)
