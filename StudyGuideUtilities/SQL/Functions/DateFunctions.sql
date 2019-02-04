DECLARE @myCurrentDate AS DATETIME
DECLARE @mySystemDate AS DATETIME
DECLARE @myTestDate AS DATETIME

SET @myCurrentDate = GETDATE()
SET @mySystemDate = SYSDATETIME()
SET @myTestDate = '1/1/2018'

SELECT 
	@myCurrentDate as 'Current Date/Time'
	,@mySystemDate as 'System Date/Time'
	,@myTestDate as 'Beginning of last year'
	,DATEDIFF(YEAR, @myTestDate, @myCurrentDate) as 'DATEDIFF in years'
	,DATEDIFF(MONTH, @myTestDate, @myCurrentDate) as 'DATEDIFF in months'
	,DATEDIFF(DAY, @myTestDate, @myCurrentDate) as 'DATEDIFF in days'
	,DATEDIFF(HOUR, @myTestDate, @myCurrentDate) as 'DATEDIFF in hours'


SELECT 
	@myCurrentDate as 'Current Date/Time'
	,DATEADD(DAY,30, @myCurrentDate) as 'DATEADD add 30 days'
	,DATEADD(DAY,-30, @myCurrentDate) as 'DATEADD subtract 30 days'
	,DATEADD(WEEK,-3, @myCurrentDate) as 'DATEADD subtract 3 weeks'