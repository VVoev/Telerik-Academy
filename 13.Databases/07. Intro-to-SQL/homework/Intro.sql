--4.Write a SQL query to find all information about all departments (use "TelerikAcademy" database).
SELECT * FROM Departments d

--5.Write a SQL query to find all department names.
SELECT d.name FROM Departments d

--6.Write a SQL query to find the salary of each employee.
SELECT e.FirstName + ' ' + e.LastName AS [FullName],e.Salary from Employees e

--7.Write a SQL to find the full name of each employee.
SELECT e.FirstName + ' ' + e.LastName AS [FullName] from Employees e

--8.Write a SQL query to find the email addresses of each employee (by his first and last name).
-- Consider that the mail domain is telerik.com. Emails should look like “John.Doe@telerik.com".
-- The produced column should be named "Full Email Addresses".
SELECT e.FirstName + '.' + e.LastName+'@telerik.com' AS Email from Employees e

--9.Write a SQL query to find all different employee salaries.
SELECT DISTINCT e.Salary from Employees e

--10.Write a SQL query to find all information about the employees whose job title is “Sales Representative“.
SELECT DISTINCT e.FirstName + ' ' +e.LastName as FullName,e.JobTitle from Employees e
WHERE e.JobTitle='Sales Representative'

--11.Write a SQL query to find the names of all employees whose first name starts with "SA".
SELECT DISTINCT e.FirstName + ' ' +e.LastName as FullName,e.JobTitle from Employees e
WHERE e.FirstName LIKE 'SA%'

--12.Write a SQL query to find the names of all employees whose last name contains "ei".
SELECT e.FirstName + ' ' +e.LastName as FullName,e.JobTitle from Employees e
WHERE e.LastName LIKE '%ei%'

--13.Write a SQL query to find the salary of all employees whose salary is in the range [20000…30000].
SELECT e.FirstName + ' ' +e.LastName as FullName,e.Salary from Employees e
WHERE e.Salary>=20000 AND e.Salary<=30000

--14.Write a SQL query to find the names of all employees whose salary is 25000, 14000, 12500 or 23600.
SELECT e.FirstName + ' ' +e.LastName as FullName,e.Salary from Employees e
WHERE e.Salary IN(12500,25000,14000,23600)

--15.Write a SQL query to find all employees that do not have manager.
SELECT e.FirstName +' ' + e.LastName as FullName,e.FirstName+ ' ' +e.LastName AS [ManagerName] from Employees e
WHERE e.ManagerID is NULL

--16.Write a SQL query to find all employees that have salary more than 50000. Order them in decreasing order by salary.
SELECT e.FirstName +' ' + e.LastName as FullName,e.Salary AS Salary from Employees e
WHERE e.Salary > 50000
ORDER BY e.Salary DESC

--17.Write a SQL query to find the top 5 best paid employees.
SELECT top 5 e.FirstName + e.LastName AS Fullname,e.Salary AS Salary  from Employees e
order by e.Salary DESC

--18.Write a SQL query to find all employees along with their address. Use inner join with ON clause.
SELECT e.FirstName + ' ' + e.LastName AS Fullname,a.AddressText AS Adress from Employees e
JOIN Addresses a
ON e.AddressID = a.AddressID

--19.Write a SQL query to find all employees and their address. Use equijoins (conditions in the WHERE clause).
SELECT e.FirstName + ' ' + e.LastName AS Fullname,a.AddressText AS Adress FROM Employees e,Addresses a
WHERE a.AddressID = e.AddressID

--20.Write a SQL query to find all employees along with their manager.
SELECT e.FirstName + ' ' + e.LastName AS EmployeeName,m.firstname + ' ' +m.lastname AS ManagerName from Employees e
JOIN Employees m
ON m.EmployeeID = e.ManagerID

--21.Write a SQL query to find all employees, along with their manager and their address.
-- Join the 3 tables: Employees e, Employees m and Addresses a.

SELECT e.FirstName + ' ' + e.LastName AS EmployeeName,m.firstname + ' ' +m.lastname AS ManagerName,a.AddressText AS AdressEmployee from Employees e
JOIN Employees m
ON m.EmployeeID = e.ManagerID
join Addresses a
ON e.AddressID = a.AddressID

--22.Write a SQL query to find all departments and all town names as a single list. Use UNION.
SELECT d.Name FROM Departments d
UNION
SELECT t.name FROM Towns t

--23.Write a SQL query to find all the employees and the manager for each of them along with the employees that do not have manager
-- Use right outer join. Rewrite the query to use left outer join.
SELECT e.FirstName + ' ' + e.LastName as [Employee Name],m.FirstName + ' ' + m.LastName AS [Manager Name] from Employees e
LEFT JOIN Employees m
ON e.ManagerID = m.EmployeeID

SELECT m.FirstName + ' ' + m.LastName as [Manager Name] ,e.FirstName + ' ' + e.LastName AS [EmployeeName] from Employees m
RIGHT JOIN Employees e
ON e.ManagerID = m.EmployeeID

--24.Write a SQL query to find the names of all employees from the departments "Sales" and "Finance" whose hire year is between 1995 and 2005.
SELECT e.FirstName,e.LastName,d.Name AS Department,e.HireDate AS HireDate from Employees e,Departments d
WHERE e.DepartmentID = d.DepartmentID
AND d.name IN('Sales','Finance')
AND e.HireDate BETWEEN '1995-1-1' AND '2005-1-1'

SELECT e.FirstName,e.LastName,d.name AS Department,e.HireDate AS HireDate from Employees e
JOIN Departments d
ON e.DepartmentID = d.DepartmentID AND d.name IN ('Sales','Finance')
WHERE e.HireDate BETWEEN '1995-1-1' AND '2005-1-1' 


