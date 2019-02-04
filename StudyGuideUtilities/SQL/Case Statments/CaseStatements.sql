BEGIN -- Example 1

-- orginal query
SELECT
	ProductID
	,ListPrice
FROM Production.Product
WHERE ListPrice <> 0


-- now we can make this more helpful with a CASE statment

SELECT
	ProductID
	,ListPrice
	,CASE
		WHEN ListPrice > 100 THEN 'YES'
		ELSE 'NO'
	 END AS 'Is Product Expensive?'
FROM Production.Product
WHERE ListPrice <> 0



-- another way to the same as above:

SELECT
	ProductID
	,ListPrice
	,CASE
		WHEN ListPrice > 100 THEN 'YES'
		WHEN ListPrice <= 100 THEN 'NO'
	 END AS 'Is Product Expensive?'
FROM Production.Product
WHERE ListPrice <> 0


END -- Example 1




BEGIN -- Example 2

WITH CustomerAgesCTE
AS 
(
	SELECT
		P.FirstName
		,P.LastName
		,FLOOR(DATEDIFF(DAY, PDView.BirthDate, GETDATE()) /365.25) AS Age-- Floor drops decimal, convert to whole number
	FROM Sales.vPersonDemographics PDView
	INNER JOIN Person.Person P
		ON P.BusinessEntityID = PDView.BusinessEntityID
)

SELECT
	*
	,CASE
		WHEN Age IS NULL THEN 'Unknown Age'
		WHEN Age BETWEEN 0 AND 17 THEN 'Under 18'
		WHEN Age BETWEEN 18 AND 24 THEN '18 to 24'
		WHEN Age BETWEEN 25 AND 34 THEN '25 to 34'
		WHEN Age BETWEEN 35 AND 49 THEN '35 to 49'
		WHEN Age BETWEEN 50 AND 64 THEN '50 to 64'
		ElSE '65 and over'
	 END AS AgeRange
FROM CustomerAgesCTE

END -- Example 2




BEGIN -- Example 3

WITH CustomerAgesCTE
AS 
(
	SELECT
		P.FirstName
		,P.LastName
		,FLOOR(DATEDIFF(DAY, PDView.BirthDate, GETDATE()) /365.25) AS Age-- Floor drops decimal, convert to whole number
	FROM Sales.vPersonDemographics PDView
	INNER JOIN Person.Person P
		ON P.BusinessEntityID = PDView.BusinessEntityID
),
CustomerAgeRangesCTE AS 
(
	SELECT
		*
		,CASE
			WHEN Age IS NULL THEN 'Unknown Age'
			WHEN Age BETWEEN 0 AND 17 THEN 'Under 18'
			WHEN Age BETWEEN 18 AND 24 THEN '18 to 24'
			WHEN Age BETWEEN 25 AND 34 THEN '25 to 34'
			WHEN Age BETWEEN 35 AND 49 THEN '35 to 49'
			WHEN Age BETWEEN 50 AND 64 THEN '50 to 64'
			ElSE '65 and over'
		 END AS AgeRange
	FROM CustomerAgesCTE
)

SELECT 
	AgeRange
	,COUNT(*) AS Customer_Count
FROM CustomerAgeRangesCTE
GROUP BY AgeRange
ORDER BY 1

END -- Example 3





BEGIN -- Example 4


SELECT
	PD.BusinessEntityID
	,P.FirstName
	,P.LastName
	,PD.Gender
	,CASE
		WHEN PD.Gender = 'M' THEN 'Male'
		WHEN PD.Gender = 'F' THEN 'Female'
		ELSE 'No Gender Listed'
	 END AS GenerValue
FROM Sales.vPersonDemographics PD
INNER JOIN Person.Person P
	ON P.BusinessEntityID = PD.BusinessEntityID



END -- Example 4





BEGIN -- Example 5


SELECT
	MiddleName AS 'Original Middle Name'
	,COALESCE(MiddleName, ' ') AS COALESCEDMiddleName
	,CASE
		WHEN MiddleName IS NULL THEN ' '
		ELSE MiddleName
	 END AS CasedMiddleName
FROM Person.Person


END -- Example 5




BEGIN -- Example 6


WITH CustomerSalesCTE
AS
(
	SELECT
		P.BusinessEntityID
		,SUM(SOH.TotalDue) AS TotalSalesAmount
	FROM Sales.SalesOrderHeader SOH
	INNER JOIN Sales.Customer SC
		ON SC.CustomerID = SOH.CustomerID
	INNER JOIN Person.Person P
		ON P.BusinessEntityID = SC.PersonID
	GROUP BY P.BusinessEntityID
),
CustomerSalesRangeCTE AS
(
	SELECT
		P.FirstName + ' ' + P.LastName AS CustomerName
		,CASE
			WHEN CS.TotalSalesAmount BETWEEN 0 AND 149.99 THEN 'Under $150'
			WHEN CS.TotalSalesAmount BETWEEN 150 AND 499.99 THEN '$150 - $499.99'
			WHEN CS.TotalSalesAmount BETWEEN 500 AND 999.99 THEN '$500 - $999.99'
			WHEN CS.TotalSalesAmount BETWEEN 1000 AND 4999.99 THEN '$1,000 - $4,999.99'
			WHEN CS.TotalSalesAmount BETWEEN 5000 AND 14999.99 THEN '$5,000 - $14.999.99'
			ELSE 'Over $15,000'
		 END AS SalesRange

	FROM CustomerSalesCTE CS
	INNER JOIN Person.Person P
		ON P.BusinessEntityID = CS.BusinessEntityID
)

SELECT
	SalesRange
	,COUNT(*) AS [Customers in Range]
FROM CustomerSalesRangeCTE
GROUP BY SalesRange
ORDER BY
	-- A little trick from the pros, if you're trying to order a string column we can use a CASE
	-- to tell it how to order the column
	CASE
		WHEN SalesRange = 'Under $150' THEN 1
		WHEN SalesRange = '$150 - $499.99' THEN 2
		WHEN SalesRange = '$500 - $999.99' THEN 3
		WHEN SalesRange = '$1,000 - $4,999.99' THEN 4
		WHEN SalesRange = '$5,000 - $14.999.99' THEN 5
		ELSE 6
	END

END -- Example 6