
-- The inner join is the most common of all the join types. Most DBAs use them when they're looking for data 
-- that matches up between two tables. The inner join connects two tables on the values that are matching. The 
-- result set that you get contains the rows from table A that match table B on the specified join predicate. 
-- If there are rows in either table that don't match, they aren't returned in the result set.

SELECT
	P.Name as 'Product Name'
	,P.ProductNumber
	,PS.Name as 'Product Subcategory'
FROM Production.Product P
INNER JOIN Production.ProductSubcategory PS
	ON P.ProductSubcategoryID = PS.ProductSubcategoryID


-- another example
SELECT
	PC.Name AS 'Product Category Name'
	,PS.Name AS 'Product Subcategory Name'
FROM Production.ProductSubcategory PS
INNER JOIN Production.ProductCategory PC
	ON PS.ProductCategoryID = PC.ProductCategoryID


-- another example
SELECT
	P.FirstName
	,P.LastName
	,PE.EmailAddress
	,PP.PhoneNumber
FROM Person.Person P
INNER JOIN Person.EmailAddress PE
	ON P.BusinessEntityID = PE.BusinessEntityID
INNER JOIN Person.PersonPhone PP
	ON P.BusinessEntityID = PP.BusinessEntityID