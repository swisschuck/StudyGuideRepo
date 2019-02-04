
-- The COALESCE() function returns the first non-null value in a list.
SELECT
	FirstName
	,MiddleName
	,LastName
	,COALESCE(MiddleName, 'Middle Name was NULL') as 'COALESCE Middle Name'
FROM Person.Person



-- The NULLIF() function returns NULL if two expressions are equal, otherwise it returns the first expression.
SELECT
	BillToAddressID
	,ShipToAddressID
	,NULLIF(BillToAddressID, ShipToAddressID) as 'NULLIF on BillToAddressID/ShipToAddressID'
	,COALESCE(NULLIF(BillToAddressID, ShipToAddressID), -1) as 'NULLIF nested in COALESCE'
FROM Sales.SalesOrderHeader