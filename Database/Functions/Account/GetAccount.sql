CREATE FUNCTION [GetAccount] (
	@id GUID
)
RETURNS TABLE AS RETURN (
	SELECT *
	FROM   [Account]
	WHERE  Id = @id
)
