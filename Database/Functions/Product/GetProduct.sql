CREATE FUNCTION [GetProduct] (
	@id GUID
)
RETURNS TABLE AS RETURN (
	SELECT *
	FROM   [Product]
	WHERE  Id = @id
)
