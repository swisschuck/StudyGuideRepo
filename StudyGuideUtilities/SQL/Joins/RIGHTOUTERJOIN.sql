
-- The RIGHT JOIN or RIGHT OUTER JOIN keyword returns all records from the right table (table2), and the matched records 
-- from the left table (table1). The result is NULL from the left side, when there is no match.
SELECT
	P.ProductNumber
	,P.Name as 'Product Name'
	,PS.Name as 'Product Subcategory Name'
FROM Production.Product P
RIGHT OUTER JOIN Production.ProductSubcategory PS
	ON P.ProductSubcategoryID = PS.ProductSubcategoryID


SELECT
	P.ProductNumber
	,P.Name as 'Product Name'
	,PS.Name as 'Product Subcategory Name'
FROM Production.ProductSubcategory PS
RIGHT OUTER JOIN Production.Product P
	ON P.ProductSubcategoryID = PS.ProductSubcategoryID