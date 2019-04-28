CREATE FUNCTION [SearchAccountsByName] (
	@name VARCHAR(64)
)
RETURNS TABLE AS RETURN (
	SELECT *
	FROM   [Account]
	WHERE  LOWER(Name) LIKE '%' + LOWER(@name) + '%'
)
