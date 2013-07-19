-- TASK 01 
-- Create a table in SQL Server with 1 000 000 
-- log entries (date + text). Search in the
-- table by date range. Check the speed (without caching).

USE TelerikAcademy
GO

CREATE TABLE TestLogs(
LogID int NOT NULL IDENTITY,
StartDate datetime,
Logs text
CONSTRAINT PK_TestLogs_LogID PRIMARY KEY(LogID)
)
GO

-- WARNING: Filling the table may take up to 20 minutes!!!!---

DECLARE @counter int = 1000000
DECLARE @date datetime = '01.01.1990'
DECLARE @text nvarchar(50) = 'qwertyuiuytrew bla bla'

WHILE (@counter > 0)
BEGIN
	INSERT INTO TestLogs
	VALUES (@date, @text)
	

	SET @counter = @counter - 1
	SET	@date = @date + 1
END

-- Example 
SElECT t.Logs, t.StartDate
FROM TestLogs t
WHERE FORMAT(t.StartDate, 'yyyy') > '2000' AND
	FORMAT(t.StartDate, 'yyyy') < '2115' 

-- TASK 02 Add an index to speed-up the search by date.
-- Test the search speed (after cleaning the cache).

CREATE INDEX IDX_TestLogs_StartDate ON TestLogs(StartDate)

CHECKPOINT; DBCC DROPCLEANBUFFERS

SElECT t.Logs, t.StartDate
FROM TestLogs t
WHERE FORMAT(t.StartDate, 'yyyy') > '2000' AND
	FORMAT(t.StartDate, 'yyyy') < '2115'

-- TASK 03 Add a full text index for the text column.
-- Try to search with and without the full-text
-- index and compare the speed.

CREATE FULLTEXT CATALOG TestLogsFullTextCatalog
WITH ACCENT_SENSITIVITY = OFF

CREATE FULLTEXT INDEX ON TestLogs(Logs)
KEY INDEX PK_TestLogs_LogID
ON TestLogsFullTextCatalog
WITH CHANGE_TRACKING AUTO


-- Slower example
CHECKPOINT; DBCC DROPCLEANBUFFERS

SELECT *
FROM TestLogs t
WHERE t.Logs LIKE '%qwertyuiuytrew%'

-- Faster example
CHECKPOINT; DBCC DROPCLEANBUFFERS

SELECT * 
FROM TestLogs t
WHERE CONTAINS(Logs, 'qwertyuiuytrew')