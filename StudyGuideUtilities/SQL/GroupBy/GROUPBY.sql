-- GROUPBY - A SELECT statement clause that divides the query result into groups of rows, usually for the purpose 
--			 of performing one or more aggregations on each group. The SELECT statement returns one row per group
--
--		   - When using a group by clause you must either include every column in the table or make use of the many
--			 SQL aggregate functions


-- this will give us one row for each sales person with the total sales for each
SELECT
	SalesPersonID
	,SUM(TotalDue) as 'Total Sales'
FROM Sales.SalesOrderHeader SOE
GROUP BY SalesPersonID



SELECT
	SalesPersonID
	,P.FirstName
	,SUM(TotalDue) as 'Total Sales'
FROM Sales.SalesOrderHeader SOE
INNER JOIN Person.Person P
	ON P.BusinessEntityID = SOE.SalesPersonID
GROUP BY SalesPersonID, P.FirstName



SELECT
	ProductID
	,SUM(Quantity) as 'Total in Stock' -- the sum of the quality column for each product
	,COUNT(*) as 'Total Locations' -- the number of times the product ID appears in the table
FROM Production.ProductInventory
GROUP BY ProductID


-- get total sales for each sales person for each territory
SELECT
	ST.Name AS 'Territory Name'
	,P.FirstName + ' ' + P.LastName AS 'Sales Person Name'
	,SUM(TotalDue) as 'Total Sales'
FROM Sales.SalesOrderHeader SOH
INNER JOIN Sales.SalesPerson SP
	ON SP.BusinessEntityID = SOH.SalesPersonID
INNER JOIN Person.Person P
	ON P.BusinessEntityID = SP.BusinessEntityID
INNER JOIN Sales.SalesTerritory ST
	ON ST.TerritoryID = SOH.TerritoryID
WHERE OrderDate BETWEEN '1/1/2006' AND '12/31/2006'
GROUP BY ST.Name, P.FirstName + ' ' + P.LastName
ORDER BY 1, 2