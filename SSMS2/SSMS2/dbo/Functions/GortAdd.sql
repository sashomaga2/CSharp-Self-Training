CREATE FUNCTION [dbo].[GortAdd]
(@a INT NULL, @b INT NULL)
RETURNS INT
AS
 EXTERNAL NAME [SSMS].[UserDefinedFunctions].[GortAdd]

