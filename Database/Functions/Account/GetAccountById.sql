CREATE FUNCTION [dbo].[GetAccountById] (
	@id CHAR(32)
)
RETURNS TABLE AS RETURN (
	SELECT 
			Id, Name, Phone, StreetNumber, PostalCode
	FROM	[Account]
	WHERE	Id = @id
)
