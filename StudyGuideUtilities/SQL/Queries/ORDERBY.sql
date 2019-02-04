-- ORDER BY is ASC (assending) by default
-- if you want a descending order you will need to specify this with DESC
SELECT
	FirstName
	,LastName
FROM Sales.vIndividualCustomer
ORDER BY FirstName DESC


-- you can also order by the columns ordinal order
SELECT
	FirstName
	,LastName
FROM Sales.vIndividualCustomer
ORDER BY 2 -- 2 being the 2nd column in the select statement or LastName


-- we can also order by column alias
SELECT
	FirstName as 'some custom name here'
	,LastName
FROM Sales.vIndividualCustomer
ORDER BY 'some custom name here'


-- we can also order by multiple columns
SELECT
	FirstName
	,LastName
FROM Sales.vIndividualCustomer
ORDER BY LastName ASC, FirstName DESC


-- combining multiple clauses
SELECT
	LastName
	,FirstName
	,SalesQuota
FROM Sales.vSalesPerson
WHERE SalesQuota >= 250000
ORDER BY SalesQuota DESC, LastName ASC

