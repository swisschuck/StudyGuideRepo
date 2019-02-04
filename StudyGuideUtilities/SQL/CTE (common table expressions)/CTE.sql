-- common table expression (CTE) - defines a temporary result set which you can then use in a SELECT statement.  It becomes a convenient way to manage complicated queries.

-- here is what we could have done, but instead we can...

BEGIN -- before CTE example


SELECT
	OrderYear
	,COUNT(*) AS SalesCount
FROM
(
	SELECT
		YEAR(OrderDate) AS OrderYear
		,SalesOrderID
	FROM Sales.SalesOrderHeader
) SalesDetails
WHERE OrderYear = '2006'
GROUP BY OrderYear


END -- before CTE example




-- build out a CTE to handle this

BEGIN -- CTE example 1


WITH SalesDetails
AS
(
	SELECT
		YEAR(OrderDate) AS OrderYear
		,SalesOrderID
	FROM Sales.SalesOrderHeader
)

SELECT
	OrderYear
	,COUNT(*) AS SalesCount
FROM SalesDetails
WHERE OrderYear = '2006'
GROUP BY OrderYear


END -- CTE example 1




BEGIN -- CTE example 2


WITH HR_Emp
AS
(
	SELECT
		BusinessEntityID
		,NationalIDNumber
		,YEAR(BirthDate) AS BirthYear
		,YEAR(HireDate) AS HiredYear
	FROM HumanResources.Employee
)

SELECT
	*
FROM HR_Emp
WHERE HiredYear >= 2004



END -- CTE example 2




BEGIN -- CTE example 3

-- we want to return for each year, the total sales in that year and the total sales
-- that occured in the previous year

-- we can do this with a derived table, like so:

SELECT
	SalesCurrentYear.SalesYear
	,SalesCurrentYear.TotalSales AS AnnualSales
	,SalesPriorYear.TotalSales AS PriorYearSales
FROM
(
	SELECT
		YEAR(OrderDate) AS SalesYear
		,SUM(TotalDue) AS TotalSales
	FROM Sales.SalesOrderHeader
	GROUP BY YEAR(OrderDate)
) AS SalesCurrentYear
LEFT OUTER JOIN -- self join to the same table to get the previous year
(
	SELECT
		YEAR(OrderDate) AS SalesYear
		,SUM(TotalDue) AS TotalSales
	FROM Sales.SalesOrderHeader
	GROUP BY YEAR(OrderDate)
) AS SalesPriorYear
ON SalesCurrentYear.SalesYear - 1 = SalesPriorYear.SalesYear
ORDER BY 1


-- or we can use a CTE, like so:
-------------------------------------

WITH SalesByYearCTE -- this is the CTE
AS
(
	SELECT 
		YEAR(OrderDate) AS SalesYear
		,SUM(TotalDue) AS TotalSales
	FROM Sales.SalesOrderHeader
	GROUP BY YEAR(OrderDate)
)

-- so now that we have the CTE we can use that to perform the self join and
-- rid ourselves of the redunancy

SELECT
	CurrentYearSales.SalesYear
	,CurrentYearSales.TotalSales AS AnnualSales
	,PriorYearSales.TotalSales AS PriorYearSales
FROM SalesByYearCTE CurrentYearSales

LEFT OUTER JOIN SalesByYearCTE AS PriorYearSales
	ON CurrentYearSales.SalesYear - 1 = PriorYearSales.SalesYear
ORDER BY 1

END -- CTE example 3




BEGIN -- CTE example 4


WITH CTE1
AS
(
	SELECT
		YEAR(OrderDate) AS SalesYear
		,SalesOrderID
		,TotalDue
	FROM Sales.SalesOrderHeader
),
CTE2
AS
(
	SELECT
		SalesYear
		,COUNT(SalesOrderID) AS SalesCount
		,SUM(TotalDue) AS AnnualSales
	FROM CTE1
	GROUP BY SalesYear
)

SELECT
	SalesYear
	,SalesCount
	,AnnualSales
FROM CTE2
WHERE SalesCount > 5000
ORDER BY 1


END -- CTE example 4