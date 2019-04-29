CREATE FUNCTION [SearchProductsByFamily] (
	@family VARCHAR(36)
)
RETURNS TABLE AS RETURN (
	SELECT *
	FROM   [Product]
	WHERE  Family = @family
)
