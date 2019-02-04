-- A derived table is a technique for creating a temporary set of records which can be used within another query in SQL. 
-- You can use derived tables to shorten long queries, or even just to break a complex process into logical steps.

SELECT
	*
	-- here we are selecting everything from our derived table (MyDerivedTable), based on the sub-set query in the FROM clause
FROM 
(
	SELECT
		BusinessEntityID
		,FirstName
		,LastName
	FROM Person.Person
) AS MyDerivedTable


BEGIN -- EXAMPLE 1


-- Example of what we would need to do in lue of a derived table
-- all of these functions we are using here can cause some performance problems so...
SELECT
	YEAR(OrderDate) AS 'Order Year'
	,COUNT(*) AS 'Sales Count'
FROM Sales.SalesOrderHeader
WHERE YEAR(OrderDate) = '2006'
GROUP BY YEAR(OrderDate)


-- we can use a derived table to help out
SELECT
	[Order Year]
	,COUNT(*) as SalesCount
FROM
(
	SELECT 
		YEAR(OrderDate) AS [Order Year]
		,SalesOrderID AS 'Sales Order ID'
	FROM Sales.SalesOrderHeader
) AS SalesDetailsDerivedTable
WHERE [Order Year] = 2006
GROUP BY [Order Year]


END -- EXAMPLE 1




BEGIN -- EXAMPLE 2


SELECT
	*
FROM
(
	SELECT
		BusinessEntityID
		,NationalIDNumber
		,YEAR(BirthDate) AS BirthYear
		,YEAR(HireDate) AS HireYear
	FROM HumanResources.Employee
) AS HR_Employee_DerivedTable
WHERE BirthYear < 1960


END -- EXAMPLE 2




BEGIN -- EXAMPLE 3


SELECT
	*
FROM
(
	SELECT
		BusinessEntityID
		,NationalIDNumber
		,BirthYear AS BirthYear
		,YEAR(HireDate) AS HireYear
	FROM
	(
		SELECT
			BusinessEntityID
			,NationalIDNumber
			,YEAR(BirthDate) AS BirthYear
			,HireDate
		FROM HumanResources.Employee
	) AS InnerNestedDerivedTable
) AS OuterNestedDerivedTable
WHERE HireYear > 1960


END -- EXAMPLE 3



BEGIN -- EXAMPLE 4


SELECT
	*
FROM
(
	SELECT
		BusinessEntityID
		,NationalIDNumber
		,BirthYear AS BirthYear
		,YEAR(HireDate) AS HireYear
	FROM
	(
		SELECT
			BusinessEntityID
			,NationalIDNumber
			,YEAR(BirthDate) AS BirthYear
			,HireDate
		FROM HumanResources.Employee
	) AS InnerNestedDerivedTable
	WHERE BirthYear < 1960
) AS OuterNestedDerivedTable
WHERE HireYear > 2003


END -- EXAMPLE 4




BEGIN -- EXAMPLE 5

-- so lets say we want find for each year that we had sales the total amount of revenue for that year
-- and how many employees we hired for that year

SELECT
	Sales_by_Year.SalesYear AS 'Sales Year'
	,Sales_by_Year.TotalRevenue AS 'Total Revenue'
	,COALESCE(Hires_by_Year.NewHireCount, 0) AS 'New Hire Count For That Year'
FROM
(
	SELECT
		SalesYear
		,SUM(TotalDue) AS TotalRevenue
	FROM
	(
		SELECT
			YEAR(OrderDate) AS SalesYear
			,TotalDue
		FROM Sales.SalesOrderHeader

	) AS SalesYear
	GROUP BY SalesYear

) AS Sales_by_Year
LEFT OUTER JOIN
(
	SELECT
		HireYear
		,COUNT(BusinessEntityID) AS NewHireCount
	FROM
	(
		SELECT 
			YEAR(HireDate) AS HireYear
			,BusinessEntityID
		FROM HumanResources.Employee

	) AS EmployeeDetails
	GROUP BY HireYear

) AS Hires_by_Year

ON Hires_by_Year.HireYear = Sales_by_Year.SalesYear
ORDER BY 1


END -- EXAMPLE 5