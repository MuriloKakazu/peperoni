CREATE FUNCTION [dbo].[GetProductById] (
	@id CHAR(32)
)
RETURNS TABLE AS RETURN (
	SELECT 
			Id, Name, Family, ListPrice
	FROM    [Product]
	WHERE	Id = @id
)
