-- ASCII - Returns the ASCII value for the specific character
-- CHAR - Returns the character based on the ASCII code
-- CHARINDEX - Returns the position of a substring in a string
-- CONCAT - Adds two or more strings together
-- Concat - with +	Adds two or more strings together
-- CONCAT_WS - Adds two or more strings together with a separator
-- DATALENGTH - Returns the number of bytes used to represent an expression
-- DIFFERENCE - Compares two SOUNDEX values, and returns an integer value
-- FORMAT - Formats a value with the specified format
-- LEFT - Extracts a number of characters from a string (starting from left)
-- LEN - Returns the length of a string
-- LOWER - Converts a string to lower-case
-- LTRIM - Removes leading spaces from a string
-- NCHAR - Returns the Unicode character based on the number code
-- PATINDEX - Returns the position of a pattern in a string
-- QUOTENAME - Returns a Unicode string with delimiters added to make the string a valid SQL Server delimited identifier
-- REPLACE - Replaces all occurrences of a substring within a string, with a new substring
-- REPLICATE - Repeats a string a specified number of times
-- REVERSE - Reverses a string and returns the result
-- RIGHT - Extracts a number of characters from a string (starting from right)
-- RTRIM - Removes trailing spaces from a string
-- SOUNDEX - Returns a four-character code to evaluate the similarity of two strings
-- SPACE - Returns a string of the specified number of space characters
-- STR - Returns a number as string
-- STUFF - Deletes a part of a string and then inserts another part into the string, starting at a specified position
-- SUBSTRING - Extracts some characters from a string
-- TRANSLATE - Returns the string from the first argument after the characters specified in the second argument are translated into the characters specified in the third argument.
-- TRIM - Removes leading and trailing spaces (or other specified characters) from a string
-- UNICODE - Returns the Unicode value for the first character of the input expression
-- UPPER - Converts a string to upper-case

BEGIN -- LEFT

DECLARE @myLEFTString AS NVARCHAR(MAX)
SET @myLEFTString = 'charlie'

SELECT 
	@myLEFTString
	,LEFT(@myLEFTString, 4) as 'LEFT 4'

SELECT
	FirstName
	,LEFT(FirstName, 5) as 'LEFT 4'
FROM Person.Person


END -- LEFT



BEGIN -- RIGHT

DECLARE @myRIGHTString AS NVARCHAR(MAX)
SET @myRIGHTString = 'charlie'

SELECT 
	@myRIGHTString
	,RIGHT(@myRIGHTString, 4) as 'RIGHT 4'

SELECT
	FirstName
	,RIGHT(FirstName, 4) as 'RIGHT 4'
FROM Person.Person


END -- RIGHT



BEGIN -- SUBSTRING

DECLARE @mySUBSTRINGString AS NVARCHAR(MAX)
SET @mySUBSTRINGString = 'charlie'

SELECT 
	@mySUBSTRINGString
	,SUBSTRING(@mySUBSTRINGString, 2, 4) as 'SUBSTRING 2, 4'

SELECT
	FirstName
	,SUBSTRING(FirstName, 2, 4) as 'SUBSTRING 2, 4'
FROM Person.Person


END -- SUBSTRING




BEGIN -- CHARINDEX

DECLARE @myCHARINDEXString AS NVARCHAR(MAX)
SET @myCHARINDEXString = 'charlie'

SELECT 
	@myCHARINDEXString
	,CHARINDEX('r', @myCHARINDEXString, 0) as 'CHARINDEX find r starting at position 0'

SELECT
	FirstName
	,CHARINDEX('r', FirstName, 0) as 'CHARINDEX find r starting at position 0'
FROM Person.Person


END -- CHARINDEX



BEGIN -- LTRIM

DECLARE @myLTRIMString AS NVARCHAR(MAX)
SET @myLTRIMString = '     charlie      '

SELECT 
	@myLTRIMString
	,LTRIM(@myLTRIMString) as 'LTRIM'

SELECT
	FirstName
	,LTRIM(FirstName) as 'LTRIM'
FROM Person.Person


END -- LTRIM




BEGIN -- UPPER AND LOWER

DECLARE @myUPPERLOWERString AS NVARCHAR(MAX)
SET @myUPPERLOWERString = 'Charlie'

SELECT 
	@myUPPERLOWERString
	,UPPER(@myUPPERLOWERString) as 'UPPER'
	,LOWER(@myUPPERLOWERString) as 'LOWER'

SELECT
	FirstName
	,UPPER(FirstName) as 'UPPER'
	,LOWER(FirstName) as 'LOWER'
FROM Person.Person


END -- UPPER AND LOWER




BEGIN -- LEN

DECLARE @myLENString AS NVARCHAR(MAX)
SET @myLENString = 'charlie'

SELECT 
	@myLENString
	,LEN(@myLENString) as 'LEN'

SELECT
	FirstName
	,LEN(FirstName) as 'LEN'
FROM Person.Person


END -- LTRIM




BEGIN -- NESTED FUNCTIONS

DECLARE @myNestedFunctionString AS NVARCHAR(MAX)
SET @myNestedFunctionString = '  T-SQL Class'

SELECT 
	@myNestedFunctionString
	,LTRIM(@myNestedFunctionString) as 'LTRIM'
	,LEN(LTRIM(@myNestedFunctionString)) as 'LTRIM nested in LEN'
	,UPPER(SUBSTRING(@myNestedFunctionString, 3, 7)) as 'UPPER nested in SUBSTRING'
	,REPLACE(UPPER(SUBSTRING(@myNestedFunctionString, 3, 7)), 'S', '@') as 'REPLACE nested in UPPER Nested in SUBSTRING'
SELECT
	Name
	,LTRIM(Name) as 'LEN'
	,LEN(LTRIM(Name)) as 'LTRIM Nested in LEN'
	,UPPER(SUBSTRING(Name, 3, 7)) as 'UPPER nested in SUBSTRING'
	,REPLACE(UPPER(SUBSTRING(Name, 3, 7)), 'S', '@') as 'REPLACE nested in UPPER Nested in SUBSTRING'
FROM Production.Product


END -- NESTED FUNCTIONS