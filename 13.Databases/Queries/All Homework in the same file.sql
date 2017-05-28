--SQL Intro

--4.Write a SQL query to find all information about all departments (use "TelerikAcademy" database).
SELECT
	*
FROM Departments d

--5.Write a SQL query to find all department names.
SELECT
	d.Name
FROM Departments d

--6.Write a SQL query to find the salary of each employee.
SELECT
	e.FirstName
   ,e.Salary
FROM Employees e

--7.Write a SQL to find the full name of each employee.
SELECT
	e.FirstName + e.Lastname AS [Fullname]
FROM Employees e

--8.Write a SQL query to find the email addresses of each employee (by his first and last name).
-- Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com". The produced column should be named "Full Email Addresses".
SELECT
	e.FirstName + '.' + e.Lastname + '@telerik.com' AS [Full Email Adress]
FROM Employees e

--9.Write a SQL query to find all different employee salaries.
SELECT DISTINCT
	e.Salary
FROM Employees e

--10.Write a SQL query to find all information about the employees whose job title is “Sales Representative“.
SELECT
	*
FROM Employees e
WHERE e.JobTitle = 'Sales Representative'

--11.Write a SQL query to find the names of all employees whose first name starts with "SA".
SELECT
	e.FirstName
FROM Employees e
WHERE e.FirstName LIKE 'SA%'
ORDER BY e.FirstName

--12.Write a SQL query to find the names of all employees whose last name contains "ei".
SELECT
	e.FirstName + ' ' + e.Lastname
FROM Employees e
WHERE e.Lastname LIKE '%ei%'
ORDER BY e.Lastname

--13.Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].
SELECT
	e.FirstName
   ,e.Salary
FROM Employees e
WHERE Salary >= 20000
AND Salary <= 30000
ORDER BY Salary
--14.Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
SELECT
	e.FirstName
   ,e.Salary
FROM Employees e
WHERE e.Salary IN (25000, 14000, 12500, 23600)
ORDER BY e.Salary

--15.Write a SQL query to find all employees that do not have manager.
SELECT
	e.FirstName
   ,e.Salary
FROM Employees e
WHERE e.ManagerID IS NULL

--16.Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.
SELECT TOP 5
	e.FirstName
   ,e.Salary
FROM Employees e
WHERE e.Salary > 50000
ORDER BY e.Salary DESC

--17.Write a SQL query to find the top 5 best paid employees.
SELECT TOP 5
	e.FirstName
   ,e.Salary
FROM Employees e
ORDER BY e.Salary DESC

--18.Write a SQL query to find all employees along with their address. Use inner join with ON clause.
SELECT
	e.FirstName
   ,a.AddressText
   ,t.Name
FROM Employees e
JOIN Addresses a
	ON e.AddressID = a.AddressID
JOIN Towns t
	ON a.TownID = t.TownID

--19.Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).
SELECT
	e.FirstName + ' ' + e.Lastname AS [Fullname]
   ,a.AddressText AS [Adress]
   ,t.Name AS [TownName]
FROM Employees e
	,Addresses a
	,Towns t
WHERE e.AddressID = a.AddressID
AND a.TownID = t.TownID


--20.Write a SQL query to find all employees along with their manager.
SELECT
	e.FirstName + ' ' + e.Lastname AS [Employee Name]
   ,m.FirstName + ' ' + m.Lastname AS [ManagerName]
FROM Employees e
JOIN Employees m
	ON e.ManagerID = m.EmployeeID

--21.Write a SQL query to find all employees, along with their manager and their address. Join the 3 tables: Employees e, Employees m and Addresses a.
SELECT
	e.FirstName + ' ' + e.Lastname AS [Employee FullName]
   ,m.FirstName + ' ' + m.Lastname AS [ManagerFullName]
   ,a.AddressText
FROM Employees e
	,Employees m
	,Addresses a
WHERE m.EmployeeID = e.ManagerID
AND e.AddressID = a.AddressID

SELECT
	e.FirstName
   ,m.FirstName
   ,a.AddressText
FROM Employees e
JOIN Employees m
	ON m.EmployeeID = e.ManagerID
JOIN Addresses a
	ON e.AddressID = a.AddressID
--22.Write a SQL query to find all departments and all town names as a single list. Use UNION.
SELECT
	d.Name
FROM Departments d
UNION
SELECT
	t.Name
FROM Towns t

--23.Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager.
-- Use right outer join. Rewrite the query to use left outer join.
SELECT
	e.FirstName + ' ' + e.Lastname AS employeeFullname
   ,m.FirstName + ' ' + m.Lastname AS [ManagerFullName]
FROM Employees e
LEFT JOIN Employees m
	ON e.ManagerID = m.EmployeeID

SELECT
	e.FirstName + ' ' + e.Lastname AS [employeeFullName]
   ,m.FirstName + ' ' + m.Lastname AS [ManagerName]
FROM Employees m
RIGHT JOIN Employees e
	ON e.ManagerID = m.EmployeeID


--24.Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.
SELECT
	e.FirstName + ' ' + e.Lastname
   ,d.Name
   ,e.HireDate
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
		AND d.Name IN ('Sales', 'Finance')
WHERE e.HireDate BETWEEN ('1995-1-1') AND ('2005-1-1')


--SQL Advance

--1.Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
--Use a nested SELECT statement.
SELECT
	e.FirstName + ' ' + e.Lastname AS [Fullname]
   ,e.Salary
FROM Employees e
WHERE e.Salary = (SELECT
		MIN(e.Salary)
	FROM Employees e)

--2.Write a SQL query to find the names and salaries of the employees that have a salary
-- that is up to 10% higher than the minimal salary for the company.
SELECT
	e.FirstName + ' ' + e.Lastname AS [Fullname]
   ,e.Salary
FROM Employees e
WHERE e.Salary <= 1.10 * (SELECT
		MIN(e.Salary)
	FROM Employees e)


--3.Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
--Use a nested SELECT statement.
SELECT
	e.FirstName + ' ' + e.Lastname AS [FullName]
   ,d.Name AS [DepartmentName]
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE e.Salary = (SELECT
		MIN(eTemp.Salary)
	FROM Employees eTemp
	WHERE eTemp.DepartmentID = d.DepartmentID)

--4.Write a SQL query to find the average salary in the department #1.
SELECT
	d.Name
   ,AVG(e.Salary) AS [AverageSalary]
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE e.DepartmentID = 1
GROUP BY d.Name


--5.Write a SQL query to find the average salary in the "Sales" department.
SELECT
	d.Name
   ,AVG(e.Salary) AS [AverageSalary]
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
GROUP BY d.Name

--6.Write a SQL query to find the number of employees in the "Sales" department.
SELECT
	d.Name AS [Departament Name]
   ,COUNT(*) AS [Employee number]
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
GROUP BY d.Name

--7.Write a SQL query to find the number of all employees that have manager.
SELECT
	e.FirstName + ' ' + e.Lastname
FROM Employees e
WHERE e.ManagerID IS NOT NULL

--8.Write a SQL query to find the number of all employees that have no manager.
SELECT
	e.FirstName + ' ' + e.Lastname
FROM Employees e
WHERE e.ManagerID IS NULL

--9.Write a SQL query to find all departments and the average salary for each of them.
SELECT
	d.Name AS [DepartmantName]
   ,AVG(e.Salary) AS [AverageSalary]
FROM Employees e
	,Departments d
WHERE d.DepartmentID = e.DepartmentID
GROUP BY d.Name

--10.Write a SQL query to find the count of all employees in each department and for each town.
SELECT
	t.Name AS Town
   ,d.Name AS Departament
   ,COUNT(e.EmployeeID) AS TotalEmployees
FROM Employees e
JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
JOIN Addresses a
	ON e.AddressID = a.AddressID
JOIN Towns t
	ON a.TownID = t.TownID
GROUP BY t.Name
		,d.Name

--11.Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
SELECT
	m.FirstName + ' ' + m.Lastname AS [ManagerName]
   ,COUNT(e.EmployeeID) AS employeTotalNumber
FROM Employees e
JOIN Employees m
	ON m.EmployeeID = e.ManagerID
GROUP BY m.FirstName + ' ' + m.Lastname
HAVING COUNT(e.EmployeeID) = 5
--12.Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".
SELECT
	e.FirstName + ' ' + e.Lastname AS [Employee Name]
   ,ISNULL(m.FirstName + ' ' + m.Lastname, 'No Manager') AS [Manager Name]
FROM Employees e
LEFT JOIN Employees m
	ON e.ManagerID = m.EmployeeID

--13.Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.
SELECT
	e.Lastname
FROM Employees e
WHERE LEN(e.Lastname) = 5

--14.Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".
SELECT
	CONVERT(NVARCHAR(50), GETDATE(), 104) + ' ' + CONVERT(NVARCHAR(50), GETDATE(), 114) AS [Current Time Now]

--15.Write a SQL statement to create a table Users. Users should have username, password, full name and last login time. 

--Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
--Define the primary key column as identity to facilitate inserting records.
--Define unique constraint to avoid repeating usernames.
--Define a check constraint to ensure the password is at least 5 characters long.
CREATE TABLE Users (
	Userid INT IDENTITY
   ,Username NVARCHAR(50) NOT NULL
   ,Password NVARCHAR(50) NOT NULL
   ,Fullname NVARCHAR(50) NOT NULL
   ,LastLogin DATETIME
   ,CONSTRAINT PK_USERS PRIMARY KEY (Userid)
   ,CONSTRAINT UK_Username UNIQUE (Username)
   ,CONSTRAINT CK_Password CHECK (LEN(Password) >= 5)
)

--16.Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
--Test if the view works correctly.
INSERT INTO Users (Username, Password, Fullname, LastLogin)
	VALUES ('CatWoman', 'someCat', 'BigPussy', GETDATE()), ('Batman', 'biggay', 'big mouse', GETDATE())
GO
CREATE VIEW [InfoForAllUsers]
AS
SELECT
	*
FROM Users
WHERE CONVERT(NVARCHAR(20), LastLogin, 104) = CONVERT(NVARCHAR(20), GETDATE(), 104)
GO


--17.Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
--Define primary key and identity column.
CREATE TABLE Groups (
	GroupId INT IDENTITY
   ,Name NVARCHAR(50) NOT NULL
   ,CONSTRAINT PK_Groups PRIMARY KEY (GroupId)
   ,CONSTRAINT UK_Name UNIQUE (Name)
)


--18.Write a SQL statement to add a column GroupID to the table Users.
--Fill some data in this new column and as well in the `Groups table.
--Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.

--19.Write SQL statements to insert several records in the Users and Groups tables.

--20.Write SQL statements to update some of the records in the Users and Groups tables.

--21.Write SQL statements to delete some of the records from the Users and Groups tables.




--Transact SQL

--1.Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).
--Insert few records for testing.
--Write a stored procedure that selects the full names of all persons.


CREATE DATABASE BankSystem

CREATE TABLE [BankSystem].[dbo].[People] (
	PersonID INT IDENTITY
   ,FirstName NVARCHAR(50)
   ,Lastname NVARCHAR(50)
   ,SSN NVARCHAR(50)
   ,CONSTRAINT PK_PersonID PRIMARY KEY (PersonID)
)

CREATE TABLE [BankSystem].[dbo].[Account] (
	AccountID INT IDENTITY
   ,PersonID INT NOT NULL
   ,Balance MONEY NOT NULL
   ,CONSTRAINT PK_AccountID PRIMARY KEY (AccountID)
   ,CONSTRAINT FK_Account_People_PersonID FOREIGN KEY (PersonID) REFERENCES [BankSystem].[dbo].[People] (PersonID)
)

INSERT INTO [BankSystem].[dbo].[People] (FirstName, Lastname, SSN)
	VALUES ('Ivan', 'Ivanov', '12345678'),
	('Pepa', 'Todora', '112244'),
	('Mitko', 'Kirqkov', '556677')

INSERT INTO [BankSystem].[dbo].[Account] (PersonID, Balance)
	VALUES (1, 333.55),
	(2, 2500.55),
	(3, 21000.300)

--2.Create a stored procedure that accepts a number as a parameter and returns all persons who have more money
--in their accounts than the supplied number.

GO
CREATE PROC usp_UsersWithMoreMoney @minMoney MONEY = 0
AS
	SELECT
		p.FirstName
	   ,p.Lastname
	   ,a.Balance
	FROM [BankSystem].[dbo].[People] p
	JOIN [BankSystem].[dbo].[Account] a
		ON p.PersonID = a.PersonID
	WHERE a.Balance > @minMoney
GO

CREATE PROC lessMoneyThanTenThousandExtension @maxMoney MONEY = 10000
AS
	SELECT
		p.FirstName + ' ' + p.Lastname AS [Fullname]
	   ,a.Balance AS [Balance]
	FROM People p
	JOIN Account a
		ON p.PersonID = a.PersonID
	WHERE a.Balance < @maxMoney

	--Test the procedure
	EXEC usp_UsersWithMoreMoney @minMoney = 2000
	EXEC lessMoneyThanTenThousandExtension @maxMoney = 50000

--3.Create a function that accepts as parameters – sum, yearly interest rate and number of months.
--It should calculate and return the new sum.
--Write a SELECT to test whether the function works as expected.
--sum = 12000 interest rate = 5.9% number of months = 5
GO
CREATE FUNCTION ufn_CalculateSumWithInterest (@sum MONEY, @yearInterest DECIMAL, @months INT) RETURNS MONEY
AS
BEGIN
RETURN (@sum + @sum*(@yearInterest/100)*@months/12)
END
GO


DECLARE @sum MONEY = (SELECT Balance FROM Account WHERE AccountID = 1)
PRINT dbo.ufn_CalculateSumWithInterest(@sum,5,5)




















