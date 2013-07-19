-- TASK 01 
-- Create a table in SQL Server with 1 000 000 
-- log entries (date + text). Search in the
-- table by date range. Check the speed (without caching).
CREATE DATABASE TestPerformance;
USE TestPerformance;

CREATE TABLE TestLogs (
    StartDate datetime PRIMARY KEY,
    InputText nvarchar(100)
) PARTITION BY RANGE(YEAR(StartDate)) (
	PARTITION p0 VALUES LESS THAN (1990),
	PARTITION p1 VALUES LESS THAN (2000),
	PARTITION p2 VALUES LESS THAN (2010),
	PARTITION p3 VALUES LESS THAN MAXVALUE
);


-- BEFORE USE GO TO EDIT->PREFERENCES->SQL EDITOR
-- AND CHANGE THE VALUES IN "DBMS CONNECTION KEEP-ALIVE INTERVAL"
-- AND "DBS CONNECTION READ TIME OUT" TO 99999

-- WARNING: Filling the table may take up to 20 minutes!!!!---
DELIMITER $$
DROP PROCEDURE IF EXISTS fillTable $$
CREATE PROCEDURE fillTable()
BEGIN
	DECLARE counter INT DEFAULT 1000000;
	DECLARE startDate datetime DEFAULT '1980-01-01';
	DECLARE inputText nvarchar(50) DEFAULT 'qwerty';

	WHILE counter > 0 DO
	INSERT INTO `TestLogs`(`StartDate`, `InputText`)
	VALUES (startDate, inputText);
	SET startDate = TIMESTAMPADD(DAY, 1, startDate);
	SET counter = counter - 1;
	END WHILE;
END $$

CALL fillTable ();

SELECT * FROM TestLogs PARTITION(p1);

SELECT * FROM TestLogs WHERE YEAR(StartDate) < 2000;