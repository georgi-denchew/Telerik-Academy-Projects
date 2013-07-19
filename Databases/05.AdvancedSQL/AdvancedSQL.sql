---------Task 01 Names and salaries of employees with minimal salary---------

USE TelerikAcademy
GO

SELECT
FirstName + ' ' + LastName as [Employee Name],
Salary	
FROM Employees 
WHERE Salary = 
(SELECT MIN(Salary) FROM Employees)

---------Task 02 Names and salaries of employees with salary up to 10% higher than the minimal---------

SELECT
FirstName + ' ' + LastName as [Employee Name],
Salary
FROM Employees
Where Salary < 1.101*(Select MIN(Salary) From Employees)
ORDER BY Salary ASC


---------Task 03 Full name, salary and department wit minimal salary for the department---------

SELECT
e.FirstName + ' ' + e.LastName as [Employee Name],
e.Salary, d.Name as [Department Name]
FROM Employees e, Departments d
WHERE e.DepartmentID = d.DepartmentID AND e.Salary = 
(Select MIN(salary) FROM Employees
WHERE DepartmentID = d.DepartmentID)
ORDER BY [Department Name]

---------Task 04 Average salary in department #1---------

Select AVG(Salary) as [Average Salary for department #1]
FROM Employees e
WHERE e.DepartmentID = 1


---------Task 05 Average salary in "sales" department---------

Select AVG(Salary)
FROM Employees e JOIN Departments d
ON d.Name = 'sales' AND e.DepartmentID = d.DepartmentID


---------Task 06 Number of employees in "sales" department---------

SELECT COUNT(e.EmployeeID)
FROM Employees e JOIN Departments d
ON d.Name = 'sales' AND e.DepartmentID = d.DepartmentID

---------Task 07 Number of employees with manager---------

SELECT COUNT(e.EmployeeID)
FROM Employees e
WHERE e.ManagerID IS NOT NULL

---------Task 08 Number of employees with no manager---------

SELECT COUNT(e.EmployeeID)
FROM Employees e
WHERE e.ManagerID IS NULL

---------Task 09 all departments and their average salaries---------

SELECT d.Name, AVG(e.Salary)
FROM Employees e JOIN Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name

---------Task 10 Count all employees in each department from each town---------

SELECT d.Name as [Department Name],
 COUNT(e.EmployeeID) as [Employees Count], t.Name as [Town Name]
FROM Employees e JOIN Departments d
ON e.DepartmentID = d.DepartmentID JOIN Addresses a
ON e.AddressID = a.AddressID JOIN Towns t
ON a.TownID = t.TownID
GROUP BY t.Name, d.Name


---------Task 11 All managers with 5 employees---------

SELECT e.FirstName + ' ' + e.LastName
FROM Employees e JOIN Employees emp
ON e.EmployeeID = emp.ManagerID
GROUP BY e.FirstName + ' ' + e.LastName
HAVING COUNT(e.EmployeeID) = 5;

---------Task 12 all employees with their managers---------

SELECT e.FirstName + ' ' + e.LastName as [Employee Name],
COALESCE(CONVERT(nvarchar(50), emp.FirstName + ' ' + emp.LastName), 'no manager') as [Manager Name]
FROM Employees e LEFT JOIN Employees emp
ON emp.EmployeeID = e.ManagerID

---------Task 13 All employees with last name 5 characters long---------

SELECT e.FirstName, e.LastName
FROM Employees e
WHERE LEN(e.LastName) = 5;

---------Task 14 Display Current Date---------

SELECT FORMAT(GETDATE(), 'dd.MM.yyyy HH:mm:ss:ffff')

---------Task 15 Create Users table---------

CREATE TABLE Users(
UserID int IDENTITY,
Username nvarchar(50) NOT NULL,
[Password] nvarchar(50) NOT NULL,
[Full name] nvarchar(50) NOT NULL,
[Last Login] datetime,
CONSTRAINT PK_Users PRIMARY KEY(UserID),
CONSTRAINT AK_Username UNIQUE(Username),
CHECK (LEN([Password]) > 4)
)
GO

---------Task 16 Create view for Users logged in today---------

CREATE VIEW [Users Logged In Today] AS
SELECT * 
FROM Users u
WHERE FORMAT(u.[Last Login], 'dd.MM.yyyy') = FORMAT(GETDATE(), 'dd.MM.yyyy')
GO
---------Task 17 Create Groups table---------

CREATE TABLE Groups (
Name nvarchar(50) NOT NULL,
CONSTRAINT AK_Name UNIQUE(Name)
)
GO

---------Task 18 Add GroupID---------

ALTER TABLE Groups 
ADD GroupID int IDENTITY
CONSTRAINT PK_Groups PRIMARY KEY(GroupID)


ALTER TABLE Users
ADD GroupID int
CONSTRAINT FK_Users_Groups FOREIGN KEY(GroupID)
	REFERENCES Groups(GroupID)

---------Task 19 Insert records---------

INSERT INTO Groups
VALUES ('first inserted group')

INSERT INTO Groups
VALUES ('second inserted group')

INSERT INTO Users
VALUES ('first username', '12345', 'user userov', GETDATE(), 1)

INSERT INTO Users
VALUES ('second username', '12345', 'user userov', GETDATE(), 4)

---------Task 20 Update records---------

UPDATE Users
	SET Username = 'updated username'
	WHERE Username = 'first username'
GO

UPDATE Groups
	SET Name = 'update group'
	WHERE Name LIKE 'first%'
GO

---------Task 21 Delete records---------

DELETE FROM Users
	WHERE Username LIKE 'second%'

DELETE FROM Groups
	WHERE Name = 'second inserted group'

---------Task 22 insert Employees into Users---------
-- The task cannot be executed under the given conditions so
-- I'm going to use the whole name for username, otherwise there would be duplicates
-- and also the whole first name and the first three letters from the last,
-- because the password must be at least 5 characters

INSERT INTO Users
(Username, [Password], [Full name], [Last Login]
)
SELECT 
Username = LOWER(e.FirstName + e.LastName),
[Password] = LOWER(e.FirstName + LEFT(e.LastName, 3)),
[Full name] = e.FirstName + ' ' + e.LastName,
[Last login] = NULL
FROM Employees e 
ORDER BY [Password] ASC


---------Task 23 Password change---------

ALTER TABLE Users
ALTER COLUMN [Password] nvarchar(50)

	
UPDATE Users
	SET [Password] = NULL --MM.DD.YYYY
	WHERE [Last Login] < CAST('10.03.2010' as datetime) OR [Last Login] IS NULL

---------Task 24 Delete users without passwords---------

DELETE FROM Users
	WHERE [Password] IS NULL

---------Task 25 average employee salary by department and job title---------

SELECT d.Name as [Department], e.JobTitle, AVG(e.Salary)
FROM Employees e 
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID
GROUP BY e.JobTitle, d.Name

---------Task 26 Minimal employee salary by dep, job title with name of some employees---------


SELECT d.DepartmentID, d.Name as [Department], e.JobTitle, e.Salary as [Minimal Salary],
e.FirstName + ' ' +  e.LastName as [Employee]
FROM Employees e 
	JOIN Departments d
		ON e.DepartmentID = d.DepartmentID AND
		e.Salary = (
		SELECT MIN(emp.Salary)
		FROM Employees emp
		WHERE emp.DepartmentID = d.DepartmentID)

GROUP BY e.Salary, e.JobTitle, d.Name, e.FirstName + ' ' +  e.LastName, d.DepartmentID

---------Task 27 Town with maximal number of employees---------

SELECT TOP 1 COUNT(t.Name) as [Employees Count], t.Name
FROM Employees e
	JOIN Addresses a
		ON a.AddressID = e.AddressID
	JOIN Towns t
		ON t.TownID = a.TownID
GROUP BY t.Name
ORDER BY COUNT(t.name) DESC

---------Task 28 number of managers from each town---------

SELECT  (t.Name) ,COUNT( DISTINCT(e.EmployeeID))
FROM Employees e
	JOIN Employees emp
		ON e.EmployeeID = emp.ManagerID
	JOIN Addresses a
		ON e.AddressID = a.AddressID
	JOIN Towns t
		ON t.TownID = a.TownID
GROUP BY t.Name

---------Task 29 Create WorkHours Table and triggers---------

CREATE TABLE WorkHours(
WorkHoursID int IDENTITY,
WorkDate date,
HoursWorked int,
Task nvarchar(50),
Comments nvarchar(300),
EmployeeID int
CONSTRAINT PK_WorkHours PRIMARY KEY(WorkHoursID)
CONSTRAINT FK_WorkHours_Employees FOREIGN KEY(EmployeeID)
	REFERENCES Employees(EmployeeID)
)
GO

CREATE TABLE WorkHoursLogs(
ChangeID int IDENTITY,
Command nvarchar(10) NOT NULL,
WorkHoursID int NOT NULL,
OldWorkDate date,
OldHoursWorked int,
OldTask nvarchar(50),
OldComments nvarchar(300),
OldEmployeeID int,
NewWorkDate date,
NewHoursWorked int,
NewTask nvarchar(50),
NewComments nvarchar(300),
NewEmployeeID int
CONSTRAINT PK_WorkHoursLogs PRIMARY KEY(ChangeID)
CONSTRAINT FK_WrokHoursLogs_Employees FOREIGN KEY(WorkHoursID)
	REFERENCES WorkHours(WorkHoursID)
)
GO

------- Trigger start
CREATE TRIGGER InsertLogTrigger
ON WorkHours
FOR INSERT
AS 
INSERT INTO WorkHoursLogs
(
Command, WorkHoursID, OldWorkDate, 
OldHoursWorked, OldTask, OldComments, OldEmployeeID,
NewWorkDate, NewHoursWorked, NewTask, NewComments, NewEmployeeID
)
SELECT
Command = 'INSERT',
[WorkHoursID] = i.WorkHoursID,
[OldWorkDate] = NULL,
[OldHoursWorked] = NULL,
[OldTask] = NULL,
[OldComments] = NULL,
[OldEmployeeID] = NULL,
[NewWorkDate] = i.WorkDate,
[NewHoursWorked] = i.HoursWorked,
[NewTask] = i.Task,
NewComments = i.Comments,
NewEmployeeID = i.EmployeeID
FROM inserted i
----- Trigger end
GO
----- Trigger start


CREATE TRIGGER UpdateLogTrigger
ON WorkHours
FOR UPDATE
AS 
INSERT INTO WorkHoursLogs
(
Command, WorkHoursID, OldWorkDate, 
OldHoursWorked, OldTask, OldComments, OldEmployeeID,
NewWorkDate, NewHoursWorked, NewTask, NewComments, NewEmployeeID
)
SELECT
Command = 'UPDATE',
[WorkHoursID] = i.WorkHoursID,
[OldWorkDate] = d.WorkDate,
[OldHoursWorked] = d.HoursWorked,
[OldTask] = d.Task,
[OldComments] = d.Comments,
[OldEmployeeID] = d.EmployeeID,
[NewWorkDate] = i.WorkDate,
[NewHoursWorked] = i.HoursWorked,
[NewTask] = i.Task,
NewComments = i.Comments,
NewEmployeeID = i.EmployeeID
FROM inserted i, deleted d
-----Trigger end
GO
--------Trigger start
CREATE TRIGGER DeleteLogTrigger
ON WorkHours
INSTEAD OF Delete
AS

UPDATE WorkHours
	SET WorkDate = NULL,
		HoursWorked = NULL,
		Task = NULL,
		Comments = NULL,
		EmployeeID = NULL


INSERT INTO WorkHoursLogs
(
Command, WorkHoursID, OldWorkDate, 
OldHoursWorked, OldTask, OldComments, OldEmployeeID,
NewWorkDate, NewHoursWorked, NewTask, NewComments, NewEmployeeID
)


SELECT
Command = 'Delete',
[WorkHoursID] = d.WorkHoursID,
[OldWorkDate] = d.WorkDate,
[OldHoursWorked] = d.HoursWorked,
[OldTask] = d.Task,
[OldComments] = d.Comments,
[OldEmployeeID] = d.EmployeeID,
[NewWorkDate] = null,
[NewHoursWorked] = null,
[NewTask] = null,
NewComments = null,
NewEmployeeID = null
FROM  deleted d
-------- Trigger end

------- Examples for the triggers 

INSERT INTO WorkHours
VALUES(GETDATE(), 8, 'mission impossible', 'KIA', 1)

UPDATE WorkHours
	SET Task = 'SECOND UPDATED task',
		Comments = 'updated comment'
	WHERE WorkHoursID = 1
GO

DELETE FROM WorkHours
	WHERE WorkHoursID = 1