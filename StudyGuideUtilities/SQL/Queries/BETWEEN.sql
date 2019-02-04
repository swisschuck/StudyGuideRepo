SELECT
	*
FROM Sales.vStoreWithDemographics
WHERE AnnualSales >= 1000000 AND AnnualSales < = 2000000

-- we could do the above or we can use the BETWEEN
-- BETWEEN - Specifies a range to test.

SELECT
	*
FROM Sales.vStoreWithDemographics
WHERE AnnualSales BETWEEN 1000000 AND 2000000
