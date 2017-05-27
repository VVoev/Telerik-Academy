--1.Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
--Use a nested SELECT statement.

SELECT e.FirstName + ' '+e.LastName as [FullName],e.Salary from Employees e
WHERE e.Salary = (SELECT MIN(salary) from Employees)

--2.Write a SQL query to find the names and salaries of the employees
-- that have a salary that is up to 10% higher than the minimal salary for the company.
SELECT e.FirstName + ' '+e.LastName as [FullName],e.Salary from Employees e
WHERE e.Salary <= 1.1 * (Select MIN(Salary) from Employees)

--3.Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
--Use a nested SELECT statement.
SELECT e.FirstName,e.LastName as [FullName],e.Salary,d.Name from Employees e
LEFT JOIN Departments d
ON e.DepartmentID = d.DepartmentID
where e.Salary = (SELECT MIN(salary) FROM Employees tempEmployee
WHERE tempEmployee.DepartmentID = d.DepartmentID)
ORDER BY e.Salary DESC

--4.Write a SQL query to find the average salary in the department #1.
SELECT e.DepartmentID,AVG(e.Salary) AS [AverageSalary] from Employees e
JOIN Departments d
ON e.DepartmentID=d.DepartmentID
WHERE d.DepartmentID=1
GROUP BY e.DepartmentID

--5.Write a SQL query to find the average salary in the "Sales" department.
SELECT d.Name,AVG(e.salary) AS [AverageSalary] FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID
WHERE d.name = 'Sales'
GROUP BY d.Name

--6.Write a SQL query to find the number of employees in the "Sales" department.
SELECT  d.Name as [Name of Department] ,COUNT(*) as [TotalCount] FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID WHERE d.Name = 'Sales'
GROUP BY d.Name

--7.Write a SQL query to find the number of all employees that have manager.
SELECT Count (*) FROM Employees e
WHERE e.ManagerID is NOT NULL

--8.find the number of all employees that have no manager.
SELECT COUNT(*)
FROM Employees e
WHERE E.ManagerID IS NULL

--9.Write a SQL query to find all departments and the average salary for each of them.
SELECT  d.Name,ROUND(AVG(e.salary),2) AS [AverageSalary] FROM Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID 
GROUP BY d.Name

--10.Write a SQL query to find the count of all employees in each department and for each town.
SELECT t.Name AS Town,d.Name as Department,COUNT(e.EmployeeID) as Employees 
from Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
JOIN Addresses a ON e.AddressID = a.AddressID
JOIN Towns t ON t.TownID = a.TownID
GROUP BY
t.name,d.name

--11.Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
SELECT m.FirstName+' ' +m.LastName AS [Manager Name],COUNT(e.EmployeeID) AS [Employees]
FROM Employees e
	JOIN Employees m ON m.EmployeeID=e.ManagerID
	GROUP BY m.FirstName + ' ' + m.LastName
	 HAVING COUNT(e.EmployeeID)=5

--12.Write a SQL query to find all employees along with their managers.
-- For employees that do not have manager display the value "(no manager)".
SELECT e.FirstName+ ' ' + e.LastName AS EmployeeName,
ISNULL(m.FirstName + ' '+ m.LastName,'No Manager') AS ManagerName
 from Employees e
LEFT JOIN Employees m
on m.EmployeeID = e.ManagerID

--13.Write a SQL query to find the names of all employees whose last name is exactly 5 characters long.
-- Use the built-in LEN(str) function.
SELECT e.FirstName + ' ' + e.LastName as Fullname,e.LastName FROM  Employees e
WHERE LEN(e.LastName)=5

--14.Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".
--Search in Google to find how to format dates in SQL Server.
SELECT CONVERT(NVARCHAR(50),GETDATE(),104) + ' ' + CONVERT(NVARCHAR(50),GETDATE(),114) AS [DateTime]

--15.Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
--Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
-- Define the primary key column as identity to facilitate inserting records.
-- Define unique constraint to avoid repeating usernames.
-- Define a check constraint to ensure the password is at least 5 characters long.

CREATE TABLE Users(
UserId INT IDENTITY,
Username NVARCHAR(100)NOT NULL,
Password VARCHAR(100)NOT NULL,
LastLogin DATETIME,
CONSTRAINT PK_Users PRIMARY KEY(UserId),
CONSTRAINT UK_Username UNIQUE(Username),
CONSTRAINT CK_Password CHECK (LEN(Password)>=5))


















