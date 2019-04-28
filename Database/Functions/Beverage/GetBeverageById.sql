CREATE FUNCTION [dbo].[GetBeverageById] (
	@id CHAR(32)
)
RETURNS TABLE AS RETURN (
	SELECT 
			Id, OrderId, ProductId, Quantity, UnitPrice, TotalPrice
	FROM    [Beverage]
	WHERE	Id = @id
)
