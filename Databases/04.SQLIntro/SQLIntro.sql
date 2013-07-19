-----------Task 04 All departments information-----------

SELECT d.DepartmentID,
		d.Name as [Department Name],
		d.ManagerID as [Department Manager ID],
		e.FirstName + ' ' + e.LastName as [Manager Name]
FROM Departments d, Employees e
Where d.ManagerID = e.EmployeeID

-----------Task 05 All department names-----------

SELECT d.Name as [Department Name]
FROM Departments d

-----------Task 06 Each employee salary-----------

SELECT e.FirstName + ' ' + e.LastName as [Employee Name],
e.Salary
FROM Employees e

-----------Task 07 Employee full name-----------

SELECT e.FirstName + ' ' + e.LastName as [Employee full name]
FROM Employees e

-----------Task 08 E-mail addresses-----------

SELECT e.FirstName + '.' + e.LastName + '@telerik.com'
	 as [Full Email Addresses]
FROM Employees e

-----------Task 09 Different employee salaries-----------

SELECT e.Salary 
FROM Employees e 
Intersect
SELECT emp.Salary
FROM Employees emp 
Order BY e.Salary DESC


-----------Task 10 All Sales Representatives information-----------

SELECT *
FROM Employees e
	WHERE e.JobTitle = 'Sales Representative'

-----------Task 11 All employee names starting with "SA"-----------

SELECT e.FirstName + ' ' + e.LastName as [Employee Name]
FROM Employees e
	WHERE e.FirstName LIKE 'sa%'


-----------Task 12 All employee last names ending with "ei"-----------

SELECT e.FirstName + ' ' + e.LastName as [Employee Name]
FROM Employees e
	WHERE e.LastName LIKE '%ei%'


-----------Task 13 All salaries in range 20000 and 30000-----------

SELECT e.Salary
FROM  Employees e
	WHERE e.Salary BETWEEN 20000 AND 30000
ORDER BY e.Salary DESC

-----------Task 14 Employees with salary 25000, 14000, 12500, 23600-----------

SELECT e.FirstName + ' ' + e.LastName as [Employee Name], e.Salary
FROM Employees e
	WHERE e.Salary IN (25000, 14000, 12500, 23600)
ORDER BY e.Salary DESC

-----------Task 15 All employees with no manager-----------

SELECT e.FirstName + ' ' + e.LastName as [Employee Name], e.ManagerID
FROM Employees e
	Where e.ManagerID IS NULL

-----------Task 16 All employees with salary more than 50000-----------

SELECT e.FirstName + ' ' + e.LastName as [Employee Name], e.Salary
FROM Employees e
	WHERE e.Salary > 50000
ORDER BY e.Salary DESC

-----------Task 17 Top 5 Best paid employees-----------

SELECT TOP 5 e.FirstName + ' ' + e.LastName as [Employee Name], e.Salary
FROM Employees e
ORDER BY e.Salary DESC

-----------Task 18 All employees with their addresses (ON)-----------

SELECT e.FirstName + ' ' + e.LastName as [Employee Name], a.AddressText
FROM Employees e JOIN Addresses a
	ON e.AddressID = a.AddressID
ORDER BY e.FirstName

-----------Task 19 All employees with their addresses (WHERE)-----------

SELECT e.FirstName + ' ' + e.LastName as [Employee Name], a.AddressText
FROM Employees e, Addresses a
	WHERE e.AddressID = a.AddressID
ORDER BY e.FirstName

-----------Task 20 All employees with their managers-----------

SELECT e.FirstName + ' ' + e.LastName as [Employee Name],
		emp.FirstName + ' ' + emp.LastName as [Manager Name]
FROM Employees e LEFT JOIN Employees emp
	ON e.ManagerID = emp.EmployeeID

-----------Task 21 All employees with their managers and addresses-----------

SELECT e.FirstName + ' ' + e.LastName as [Employee Name],
		a.AddressText as [Employee Address],
		emp.FirstName + ' ' + emp.LastName as [Manager Name]
FROM Employees e LEFT JOIN Employees emp
	ON e.ManagerID = emp.EmployeeID JOIN Addresses a
	ON e.AddressID = a.AddressID

-----------Task 22 All deparments and all town names-----------


SELECT d.Name
FROM Departments d
UNION
SELECT dep.Name
FROM Departments dep

SELECT t.Name
FROM Towns t
UNION
SELECT tow.Name
FROM Towns tow


-----------Task 23 all employers with their managers-----------

--LEFT OUTER JOIN
SELECT e.FirstName + ' ' + e.LastName as [Employee Name],
		emp.FirstName + ' ' + emp.LastName as [Manager Name]
FROM Employees e LEFT OUTER JOIN Employees emp
	ON e.ManagerID = emp.EmployeeID

--RIGHT OUTER JOIN

SELECT e.FirstName + ' ' + e.LastName as [Employee Name],
		emp.FirstName + ' ' + emp.LastName as [Manager Name]
FROM Employees emp RIGHT OUTER JOIN Employees e
	ON e.ManagerID = emp.EmployeeID

-----------TASK 24 All employees from "Sales" and "Finance" hired between 1995 and 2005-----------

SELECT e.FirstName + ' ' + e.LastName as [Employee Name],
		e.HireDate, d.Name as Department
FROM Employees e, Departments d
	WHERE e.DepartmentID = d.DepartmentID AND 
		--d.Name IN ('sales', 'finance') AND 
		e.HireDate BETWEEN '1/1/1998' and '12/31/2005'
ORDER BY e.HireDate DESC