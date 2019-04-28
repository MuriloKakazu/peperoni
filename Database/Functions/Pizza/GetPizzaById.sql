CREATE FUNCTION [dbo].[GetPizzaById] (
	@id CHAR(32)
)
RETURNS TABLE AS RETURN (
	SELECT 
			Id, OrderId, FirstToppingId, SecondToppingId, 
			BorderId, Quantity, UnitPrice, TotalPrice
	FROM    [Pizza]
	WHERE	Id = @id
)
