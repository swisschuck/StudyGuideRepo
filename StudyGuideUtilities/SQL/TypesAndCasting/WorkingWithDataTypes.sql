DECLARE @myCurrentDate AS DATETIME
DECLARE @mySystemDate AS DATETIME
DECLARE @myTestDate AS DATETIME

SET @myCurrentDate = GETDATE()
SET @mySystemDate = SYSDATETIME()
SET @myTestDate = '1/1/2018'

SELECT
	@myCurrentDate
	,CAST(@myCurrentDate AS DATE) as 'CAST to just DATE'
	,CAST(@myCurrentDate AS TIME) as 'CAST to just TIME'
	,CONVERT(DATE, @myCurrentDate) as 'CONVERT to DATE'


--SELECT
--	FirstName as 'First Name'
--	,
--FROM Person.Person