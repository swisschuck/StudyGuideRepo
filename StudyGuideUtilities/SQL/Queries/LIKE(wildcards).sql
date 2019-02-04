-- LIKE - Determines whether a specific character string matches a specified pattern. 
--        A pattern can include regular characters and wildcard characters. During pattern matching, 
--        regular characters must exactly match the characters specified in the character string. However, 
--        wildcard characters can be matched with arbitrary fragments of the character string. Using wildcard 
--        characters makes the LIKE operator more flexible than using the = and != string comparison operators. 
--        If any one of the arguments is not of character string data type, the SQL Server Database Engine converts 
--        it to character string data type, if it is possible.
-- The LIKE operator is telling SQL to expect a wild card character

-- WILDCARDS --
--		% (percent)- Any string of zero or more characters.
--		_ (underscore) - Any single character.
--		[] (brackets) - Any single character within the specified range ([a-f]) or set ([abcdef]).
--		[^] - Any single character not within the specified range ([^a-f]) or set ([^abcdef]).


-- give us all First Names that start with MI, everything after the MI will be ignored and can be any number of characters
SELECT
	*
FROM HumanResources.vEmployee
WHERE FirstName LIKE 'MI%'


-- give us all First Names that start with any number of characters before the s, so basically ends with an s
SELECT
	*
FROM HumanResources.vEmployee
WHERE FirstName LIKE '%s'


-- give us all First Names that have an h somewhere in the name
SELECT
	*
FROM HumanResources.vEmployee
WHERE FirstName LIKE '%h%'


-- give us all First Names that start with MI, where the next character can be anything but it limited to a single character
SELECT
	*
FROM HumanResources.vEmployee
WHERE FirstName LIKE 'MI_'


-- give us all First Names that start with any ONE character but end with on
SELECT
	*
FROM HumanResources.vEmployee
WHERE FirstName LIKE '_on'


-- give us all First Names where the first letter is D, followed by an a or o then ends with n
SELECT
	*
FROM HumanResources.vEmployee
WHERE FirstName LIKE 'D[a,o]n'


-- give us all First Names where the first letter is D, has any letters that are a through f or r through z and ends with n
SELECT
	*
FROM HumanResources.vEmployee
WHERE FirstName LIKE 'D[a-f, r-z]n'


-- give us all First Names where the first letter is D, has any letters that are not a through f and ends with n
SELECT
	*
FROM HumanResources.vEmployee
WHERE FirstName LIKE 'D[^a-f]n'
