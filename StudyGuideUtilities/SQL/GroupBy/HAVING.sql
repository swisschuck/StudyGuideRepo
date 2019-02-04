-- HAVING - Specifies a search condition for a group or an aggregate. HAVING can be used only with the SELECT statement. 
--          HAVING is typically used with a GROUP BY clause. When GROUP BY is not used, there is an implicit single, aggregated group.
--
--		   - HAVING is similar to the WHERE clause but instead of filtering out data based on column values, it filters out groups
--			 based on aggregate functions.


-- get total sales for each territory in 2006 where the territory did more than 4,000,000 in sales
SELECT
	ST.Name AS 'Territory Name'
	,SUM(TotalDue) as 'Total Sales for 2006'
FROM Sales.SalesOrderHeader SOH
INNER JOIN Sales.SalesTerritory ST
	ON ST.TerritoryID = SOH.TerritoryID
WHERE OrderDate BETWEEN '1/1/2006' AND '12/31/2006'
GROUP BY ST.Name
HAVING SUM(TotalDue) > 4000000
ORDER BY 1



-- only return the product categories that have at least 15 products
SELECT
	PS.Name as 'Subcategory Name'
	,COUNT(*) as 'Product Count'
FROM Production.Product P
INNER JOIN Production.ProductSubcategory PS
	ON PS.ProductSubcategoryID = P.ProductSubcategoryID
GROUP BY PS.Name
HAVING COUNT(*) >= 15
ORDER BY PS.Name


-- only return the departments that have at least 8 employees
SELECT
	Department as 'Department Name'
	,COUNT(*) as 'Employee Count'
FROM HumanResources.vEmployeeDepartment
GROUP BY Department
HAVING COUNT(*) >= 8


-- only return the departments that have at least 6 -10 employees
SELECT
	Department as 'Department Name'
	,COUNT(*) as 'Employee Count'
FROM HumanResources.vEmployeeDepartment
GROUP BY Department
HAVING COUNT(*) BETWEEN 6 AND 10


-- only return the departments that have 6 OR 10 employees
SELECT
	Department as 'Department Name'
	,COUNT(*) as 'Employee Count'
FROM HumanResources.vEmployeeDepartment
GROUP BY Department
HAVING COUNT(*) IN (6, 10)



-- only return sales people who have done more than 2,000,000 in sales in 2006 and have had at least 75 total sales for 2006
SELECT
	SalesPersonID
	,SUM(TotalDue) as 'Total Sales Amount'
	,COUNT(*) AS 'Total Sales Count'
FROM Sales.SalesOrderHeader SOE
WHERE SOE.OrderDate BETWEEN '1/1/2006' AND '12/31/2006' AND
	  SOE.SalesPersonID IS NOT NULL
GROUP BY SalesPersonID
HAVING SUM(TotalDue) > 2000000 AND
	   COUNT(*) >= 75
ORDER BY 'Total Sales Amount' DESC