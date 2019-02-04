
-- The LEFT JOIN or LEFT OUTER JOIN  returns all records from the left table (table1), and the 
-- matched records from the right table (table2). IF there is no match on the right table, the result is NULL.
SELECT
	P.ProductNumber
	,P.Name as 'Product Name'
	,PS.Name as 'Product Subcategory Name'
FROM Production.Product P
LEFT JOIN Production.ProductSubcategory PS
	ON P.ProductSubcategoryID = PS.ProductSubcategoryID



-- if we are unsure of the relationships between tables we can use LEFT OUTER JOIN to ensure we dont
-- have missing data

SELECT
	P.FirstName
	,P.LastName
	,SOH.SalesOrderNumber
	,SOH.TotalDue AS 'sales amount'
	,T.Name AS 'Territory Name'
FROM Sales.SalesOrderHeader SOH
LEFT OUTER JOIN Sales.SalesPerson SP
	ON SOH.SalesPersonID = SP.BusinessEntityID
LEFT OUTER JOIN HumanResources.Employee E
	ON E.BusinessEntityID = SP.BusinessEntityID
LEFT OUTER JOIN Person.Person P
	ON P.BusinessEntityID = E.BusinessEntityID
LEFT OUTER JOIN Sales.SalesTerritory T
	ON T.TerritoryID = SOH.TerritoryID




SELECT
	P.FirstName
	,P.LastName
	,SOH.SalesOrderNumber
	,SOH.TotalDue AS 'sales amount'
	,T.Name AS 'Territory Name'
FROM Sales.SalesOrderHeader SOH
LEFT OUTER JOIN Sales.SalesPerson SP
	ON SOH.SalesPersonID = SP.BusinessEntityID
LEFT OUTER JOIN HumanResources.Employee E
	ON E.BusinessEntityID = SP.BusinessEntityID
LEFT OUTER JOIN Person.Person P
	ON P.BusinessEntityID = E.BusinessEntityID
LEFT OUTER JOIN Sales.SalesTerritory T
	ON T.TerritoryID = SOH.TerritoryID
WHERE T.Name = 'Northwest'
ORDER BY SOH.TotalDue DESC