-- An aggregate function performs a calculation on a set of values, and returns a single value. 
-- Except for COUNT, aggregate functions ignore null values. Aggregate functions are often used with the GROUP BY clause of the SELECT statement.

-- functions include:
--===========================================
-- APPROX_COUNT_DISTINCT - This function returns the approximate number of unique non-null values in a group.

-- AVG - This function returns the average of the values in a group. It ignores null values.
-- CHECKSUM_AGG - This function returns the checksum of the values in a group. CHECKSUM_AGG ignores null values.

-- COUNT - This function returns the number of items found in a group. COUNT operates like the COUNT_BIG function. These functions differ only in 
--		   the data types of their return values. COUNT always returns an int data type value. COUNT_BIG always returns a bigint data type value.

-- COUNT_BIG - This function returns the number of items found in a group. COUNT_BIG operates like the COUNT function. These functions differ only 
--			   in the data types of their return values. COUNT_BIG always returns a bigint data type value. COUNT always returns an int data type value.

-- GROUPING - Indicates whether a specified column expression in a GROUP BY list is aggregated or not. GROUPING returns 1 for aggregated or 0 for not 
--			  aggregated in the result set. GROUPING can be used only in the SELECT <select> list, HAVING, and ORDER BY clauses when GROUP BY is specified.

-- GROUPING_ID - Is a function that computes the level of grouping. GROUPING_ID can be used only in the SELECT <select> list, HAVING, or ORDER BY clauses when GROUP BY is specified.

-- MAX - Returns the maximum value in the expression.

-- MIN - Returns the minimum value in the expression. May be followed by the OVER clause.

-- STDEV - Returns the statistical standard deviation of all values in the specified expression.

-- STDEVP - Returns the statistical standard deviation for the population for all values in the specified expression.

-- STRING_AGG - Concatenates the values of string expressions and places separator values between them. The separator is not added at the end of string.

-- SUM - Returns the sum of all the values, or only the DISTINCT values, in the expression. SUM can be used with numeric columns only. Null values are ignored.

-- VAR - Returns the statistical variance of all values in the specified expression. May be followed by the OVER clause.

-- VARP - Returns the statistical variance for the population for all values in the specified expression.


BEGIN -- MAX

SELECT
	MAX(TotalDue)
FROM Sales.SalesOrderHeader


SELECT
	TotalDue
FROM Sales.SalesOrderHeader
ORDER BY TotalDue DESC

SELECT
	MAX(FirstName) -- will get the First Name of last First Name in the column sorted alphabetically
FROM Person.Person

END -- MAX




BEGIN -- MIN

SELECT
	MIN(TotalDue)
FROM Sales.SalesOrderHeader


SELECT
	TotalDue
FROM Sales.SalesOrderHeader
ORDER BY TotalDue ASC

END -- MIN




BEGIN -- COUNT

SELECT
	COUNT(*) -- counts the rows in the table
FROM Sales.SalesOrderHeader

SELECT
	COUNT(SalesOrderID) -- counts the rows in this column
	, COUNT(SalesPersonID) -- counts the columns that are not null
FROM Sales.SalesOrderHeader

SELECT
	COUNT(FirstName) -- counts the rows in this column
	, COUNT(DISTINCT FirstName) -- returns the count of non-repeating First Names
FROM Person.Person

END -- COUNT




BEGIN -- AVG

SELECT
	AVG(TotalDue)
FROM Sales.SalesOrderHeader


END -- AVG




BEGIN -- SUM

SELECT
	SUM(TotalDue)
FROM Sales.SalesOrderHeader


SELECT
	SUM(TotalDue)
FROM Sales.SalesOrderHeader
WHERE OrderDate BETWEEN '1/1/2006' AND '12/31/2006'


END -- SUM