SELECT 
	* 
FROM HumanResources.vEmployee
WHERE FirstName = 'Chris' OR
	  FirstName = 'Steve' OR
	  FirstName = 'Michael' OR
	  FirstName = 'Thomas'

-- So we could use the above query or we can use the IN statment
-- IN - Determines whether a specified value matches any value in a subquery or a list.
SELECT 
	* 
FROM HumanResources.vEmployee
WHERE FirstName IN ('Chris', 'Steve', 'Michael', 'Thomas')


SELECT 
	* 
FROM HumanResources.vEmployee
WHERE FirstName NOT IN ('Chris', 'Steve', 'Michael', 'Thomas')
