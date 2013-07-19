-- TASK 1
-- Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN)
-- and Accounts(Id(PK), PersonId(FK), Balance). Insert few records for testing. 
-- Write a stored procedure that selects the full names of all persons.

USE master
GO

Create DATABASE PeopleDB
GO

Use PeopleDB
GO

CREATE TABLE People(
PersonID int IDENTITY NOT NULL,
FirstName nvarchar(50) NOT NULL,
LastName nvarchar(50) NOT NULL,
SSN nvarchar(50) NOT NULL
CONSTRAINT PK_People PRIMARY KEY(PersonID),
CONSTRAINT AK_SSN UNIQUE(SSN)
)
GO

CREATE TABLE Accounts(
AccountID int IDENTITY NOT NULL,
Balance money,
PersonID int
CONSTRAINT PK_Accounts PRIMARY KEY(AccountID),
CONSTRAINT FK_Accounts_People FOREIGN KEY(PersonID)
	REFERENCES People(PersonID)
)
GO

INSERT INTO People
VALUES
('Peter', 'Petrov', '123-456-7890')

INSERT INTO People
VALUES
('Vasil', 'Dimitrov', '223-456-7690')

INSERT INTO People
VALUES
('Ivan', 'Ivanov', '983-457-7990')

INSERT INTO People
VALUES
('Pesho', 'Peshev', '923-476-5890')

INSERT INTO Accounts
VALUES (1000, 1)

INSERT INTO Accounts
VALUES (3000, 2)

INSERT INTO Accounts
VALUES (5000, 3)

INSERT INTO Accounts
VALUES (9000, 4)

GO

CREATE PROC dbo.usp_FullNameOfAllPeople
AS
SELECT p.FirstName + ' ' + p.LastName as [Full Name]
FROM People p
GO

--Example
EXEC usp_FullNameOfAllPeople


-- TASK 02
-- Create a stored procedure that accepts a number as a parameter and 
-- returns all persons who have more money in their accounts
-- than the supplied number.
GO

CREATE PROC dbo.usp_PeopleWithMoreMoneyThan
(@balance money = 1000)
AS
SELECT p.FirstName + ' ' + p.LastName as [People], a.Balance
FROM People p
	JOIN Accounts a
		ON p.PersonID = a.PersonID and a.Balance > @balance
GO

--Example
EXEC dbo.usp_PeopleWithMoreMoneyThan 3100


-- TASK 03
-- Create a function that accepts as parameters – sum,
-- yearly interest rate and number of months. It should 
-- calculate and return the new sum. Write a SELECT to 
-- test whether the function works as expected.


CREATE FUNCTION dbo.ufn_CalculateSumWithInterest(@sum money, @yearlyInterestRate float, @monthsNumber int)
	RETURNS money
AS
BEGIN
	DECLARE @result money
	SET @result = @sum + (@sum * (@yearlyInterestRate * @monthsNumber / 12))
	RETURN @result
END

USE PeopleDB
GO

-- Example
SELECT dbo.ufn_CalculateSumWithInterest(1000, 0.1, 12) as [Calculated Sum With Interest]


-- TASK 04
-- Create a stored procedure that uses the function from the 
-- previous example to give an interest to a person's account
-- for one month. It should take the AccountId and the interest
-- rate as parameters.
GO

CREATE PROC dbo.usp_GiveInterest(@accountID int, @interestRate float)
AS

UPDATE Accounts
	SET Balance = dbo.ufn_CalculateSumWithInterest(Balance, @interestRate, 1)
	WHERE AccountID = @accountID
GO
GO

--Example
EXEC dbo.usp_GiveInterest 1, 0.1

-- TASK 05
-- Add two more stored procedures WithdrawMoney( AccountId, money)
-- and DepositMoney (AccountId, money) that operate in transactions.
GO

CREATE PROC dbo.usp_WithdrawMoney(@accountID int, @amount money)
AS
BEGIN TRAN
	DECLARE @currentBalance money = (
	SELECT Balance
	FROM Accounts a
	WHERE a.AccountID = @accountID
	)

	IF (@currentBalance < @amount)
	BEGIN
		RAISERROR('Not enough balance to widthdraw that amount', 16, 1)
		ROLLBACK TRAN
	END
	ELSE
	BEGIN
		UPDATE Accounts
			SET Balance = Balance - @amount
			WHERE Accounts.AccountID = @accountID
		COMMIT TRAN
	END
GO

-- Example
EXEC usp_WithdrawMoney 1, 1000

GO

CREATE PROC dbo.usp_DepositMoney(@accountID int, @amount money)
AS
BEGIN TRAN
	IF (@amount < 0)
	BEGIN
		RAISERROR('Cannot deposit negative amount.', 16,1)
		ROLLBACK TRAN
	END
	ELSE
	BEGIN
		UPDATE Accounts
			SET Balance = Balance + @amount
			WHERE Accounts.AccountID = @accountID
		COMMIT
	END
GO

-- Example
EXEC usp_DepositMoney 1, 1000


-- TASK 06
-- Create another table – Logs(LogID, AccountID, OldSum, NewSum). 
-- Add a trigger to the Accounts table that enters a new entry into
-- the Logs table every time the sum on an account changes.


CREATE TABLE Logs(
LogID int IDENTITY NOT NULL,
AccountID int,
OldSum money NOT NULL,
NewSum money NOT NULL
CONSTRAINT PK_Logs PRIMARY KEY(LogID),
CONSTRAINT F_Logs_Accounts FOREIGN KEY(AccountID)
	REFERENCES Accounts(AccountID)
)

GO

CREATE TRIGGER AmountChangeTrigger
ON Accounts
FOR UPDATE 
AS 
INSERT INTO Logs
(
AccountID, OldSum, NewSum
)

SELECT
AccountID = i.AccountID,
OldSum = d.Balance,
NewSum = i.Balance
FROM inserted i, deleted d

-- Test the trigger

EXEC usp_DepositMoney 1, 200

EXEC usp_WithdrawMoney 3, 300

-- TASK 07
-- Define a function in the database TelerikAcademy that returns
-- all Employee's names (first or middle or last name) and all 
-- town's names that are comprised of given set of letters. 
-- Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.

GO

USE TelerikAcademy
GO

CREATE FUNCTION dbo.ufn_ContainsLetters(@word nvarchar(50), @letterSet nvarchar(50))
RETURNS bit
AS
BEGIN
	DECLARE @containFlag bit = 1
	DECLARE @currentLetter NVARCHAR(1)
	DECLARE @currentPosition int = 1
	
	WHILE(@currentPosition < LEN(@word) + 1)
	BEGIN
		SET @currentLetter = SUBSTRING(@word, @currentPosition, 1)
		
		IF (CHARINDEX(@currentLetter, @letterSet) = 0)
		BEGIN
			RETURN 0;
		END
		SET @currentPosition = @currentPosition + 1;
	END
	RETURN @containFlag;
END
GO

GO
CREATE PROC dbo.usp_FindMatchingNames(@letterSet nvarchar(50))
AS

	SELECT e.FirstName as [Matching Names]
	FROM Employees e
	WHERE 1 = (
	SELECT dbo.ufn_ContainsLetters(e.FirstName, @letterSet)
	)
	UNION
	SELECT e.MiddleName
	FROM Employees e
	WHERE 1 = (
	SELECT dbo.ufn_ContainsLetters(e.MiddleName, @letterSet)
	) AND e.MiddleName IS NOT NULL
	UNION
	SELECT e.LastName
	FROM Employees e
	WHERE 1 = (
	SELECT dbo.ufn_ContainsLetters(e.LastName, @letterSet)
	)
	UNION
	SELECT t.Name
	FROM Towns t
	WHERE 1 = (
	SELECT dbo.ufn_ContainsLetters(t.Name, @letterSet)
	)
GO

-- Example
EXEC dbo.usp_FindMatchingNames 'oistmiahf'

GO

USE TelerikAcademy
GO

-- TASK 08 
-- Using database cursor write a T-SQL script that
-- scans all employees and their addresses and prints
-- all pairs of employees that live in the same town.

DECLARE firstCursor CURSOR READ_ONLY FOR
	SELECT e.FirstName, e.LastName, e.EmployeeID, a.TownID
	FROM Employees e, Addresses a
	WHERE e.AddressID = a.AddressID

OPEN firstCursor
DECLARE @firstCFirstName nvarchar(50), @firstCLastName nvarchar(50), @firstCEmployeeID int, @firstCTownID int, @count int = 1
FETCH NEXT FROM firstCursor INTO @firstCFirstName, @firstCLastName, @firstCEmployeeID, @firstCTownID

WHILE @@FETCH_STATUS = 0
	BEGIN
		
		DECLARE secondCursor CURSOR READ_ONLY FOR
		SELECT emp.FirstName, emp.LastName, emp.EmployeeID, a.TownID
		FROM Employees emp, Addresses a
		WHERE emp.AddressID = a.AddressID

		OPEN secondCursor
		DECLARE @secondCFirstName nvarchar(50), @secondCLastName nvarchar(50), @secondCEmployeeID int, @secondCTownID int
		FETCH FROM secondCursor INTO @secondCFirstName, @secondCLastName, @secondCEmployeeID, @secondCTownID
		
		WHILE @@FETCH_STATUS = 0
		BEGIN	
			
			IF (@firstCEmployeeID <> @secondCEmployeeID AND @firstCTownID = @secondCTownID)
			BEGIN
				PRINT @firstCFirstName + ' ' + @firstCLastName + ' lives in the same city with '
					 + @secondCFirstName + ' ' + @secondCLastName
			END

		FETCH NEXT FROM secondCursor INTO @secondCFirstName, @secondCLastName, @secondCEmployeeID, @secondCTownID
		END

		CLOSE secondCursor
		DEALLOCATE secondCursor

	FETCH NEXT FROM firstCursor INTO @firstCFirstName, @firstCLastName, @firstCEmployeeID, @firstCTownID 
	END

CLOSE firstCursor
DEALLOCATE firstCursor


-- TASK 09
-- *Write a T-SQL script that shows for each
-- town a list of all employees that live in it.

GO

USE TelerikAcademy
GO

DECLARE townCursor CURSOR READ_ONLY FOR
SELECT t.Name, t.TownID
FROM Towns t

OPEN townCursor
DECLARE @townName nvarchar(50), @townID int
FETCH NEXT FROM townCursor INTO @townName, @townID

WHILE @@FETCH_STATUS = 0
BEGIN
	
	DECLARE empCursor CURSOR READ_ONLY FOR
	SELECT e.FirstName, e.LastName, a.TownID
	FROM Employees e, Addresses a
	WHERE e.AddressID = a.AddressID
	
	OPEN empCursor
	DECLARE @empFirstName nvarchar(50), @empLastName nvarchar(50), @empTownID nvarchar(50), @toPrint nvarchar(1000) = @townName + ' ->'

	FETCH NEXT FROM empCursor INTO @empFirstName, @empLastName, @empTownID

	WHILE @@FETCH_STATUS = 0
	BEGIN
		IF(@empTownID = @townID)
		BEGIN
			SET @toPrint = @toPrint + ' ' + @empFirstName + ' ' + @empLastName + ','
		END

		FETCH NEXT FROM empCursor INTO @empFirstName, @empLastName, @empTownID
	END

	DECLARE @length int = LEN(@toPrint)
	SET @toPrint = SUBSTRING(@toPrint, 1, @length - 1)
	PRINT @toPrint;

	CLOSE empCursor
	DEALLOCATE empCursor

	FETCH NEXT FROM townCursor INTO @townName, @townID
END

CLOSE townCursor
DEALLOCATE townCursor