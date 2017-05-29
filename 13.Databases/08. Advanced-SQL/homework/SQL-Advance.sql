--1.Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
--Use a nested SELECT statement.
SELECT e.FirstName,e.LastName,e.Salary AS [Minimum Salary] from Employees e
where e.Salary = (SELECT MIN(salary) from Employees)

--2.Write a SQL query to find the names and salaries of the employees that have a salary that is up to 10% higher
--than the minimal salary for the company.
SELECT e.FirstName,e.LastName,e.Salary AS [Minimum Salary] from Employees e
where e.Salary<=1.1 * (SELECT MIN(salary) from Employees)

--3.Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
--.Use a nested SELECT statement.
SELECT e.FirstName,e.LastName,e.Salary,d.Name from Employees e,Departments d
where e.DepartmentID = d.DepartmentID AND e.Salary = (SELECT min(salary) from Employees e1 --novata poluchena tablica E1
WHERE e1.DepartmentID = d.DepartmentID)
order BY e.Salary DESC

SELECT e.FirstName,e.LastName as [FullName],e.Salary,d.Name from Employees e
LEFT JOIN Departments d
ON e.DepartmentID = d.DepartmentID
where e.Salary = (SELECT MIN(salary) FROM Employees tempEmployee
WHERE tempEmployee.DepartmentID = d.DepartmentID)
ORDER BY e.Salary DESC

--4.Write a SQL query to find the average salary in the department #1.
SELECT e.departmentID AS [Department ID],AVG(e.Salary) as AverageSalary from Employees e,Departments d
WHERE e.DepartmentID = d.DepartmentID AND  d.DepartmentID = 1
GROUP BY e.DepartmentID

SELECT e.DepartmentID,AVG(e.Salary) AS [AverageSalary] from Employees e
JOIN Departments d
ON e.DepartmentID=d.DepartmentID
WHERE d.DepartmentID=1
GROUP BY e.DepartmentID

--5.Write a SQL query to find the average salary in the "Sales" department.
SELECT d.name,AVG(e.Salary) AS AverageSalary FROM Employees e,Departments d
WHERE d.DepartmentID = e.DepartmentID AND d.Name = 'Sales'
GROUP BY d.Name

SELECT d.Name, AVG(e.Salary) AS AverageSalary  from Employees e
JOIN
Departments d
ON e.DepartmentID = d.DepartmentID AND d.name = 'Sales'
GROUP BY d.Name

--6.Write a SQL query to find the number of employees in the "Sales" department.
SELECT d.name AS [Department Name], COUNT(e.EmployeeID) AS totalEmployees from Employees e,Departments d
WHERE e.DepartmentID = d.DepartmentID and d.name = 'Sales'
GROUP BY d.Name

SELECT COUNT(e.EmployeeID) AS TotalEmployees,d.name from Employees e
JOIN  Departments d
ON d.DepartmentID = e.DepartmentID AND d.Name = 'Sales'
GROUP BY d.name

--7.Write a SQL query to find the number of all employees that have manager.
SELECT COUNT(e.EmployeeID) AS Workers FROM Employees e
WHERE e.ManagerID is not NULL

--8.Write a SQL query to find the number of all employees that have no manager.
SELECT COUNT(e.EmployeeID) AS Bosses FROM Employees e
WHERE e.ManagerID is NULL

--9.Write a SQL query to find all departments and the average salary for each of them.
SELECT d.Name,Round (AVG(e.Salary),2) AS AverageSalary from Employees e,Departments d
WHERE e.DepartmentID = d.DepartmentID
GROUP BY d.Name

SELECT d.name as departmentName,Round(AVG(e.salary),3) AS [AverageSalary] from Employees e
JOIN Departments d
ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name

--10.Write a SQL query to find the count of all employees in each department and for each town.
SELECT t.name AS [Town Name],d.name as [Department name],COUNT(e.EmployeeID) AS [Total numbers Employees]
from Employees e
join Departments d ON e.DepartmentID = d.DepartmentID
JOIN Addresses a ON e.AddressID = a.AddressID
JOIN Towns t ON t.TownID = a.TownID
GROUP BY t.name,d.Name

SELECT t.name AS [Town],d.name AS [Department],COUNT(e.EmployeeID) AS Total from Employees e,Addresses a,Towns t,Departments d
WHERE e.DepartmentID = d.DepartmentID
AND e.AddressID = a.AddressID
AND t.TownID = a.TownID
GROUP BY t.name,d.Name

--11.Write a SQL query to find all managers that have exactly 5 employees. Display their first name and last name.
SELECT m.FirstName + ' ' + m.LastName AS [Manager],COUNT(e.EmployeeID) AS count from Employees e,Employees m
where m.EmployeeID = e.ManagerID
GROUP BY m.FirstName + ' ' + m.LastName
HAVING COUNT(e.EmployeeID) = 5

SELECT m.FirstName + ' ' + m.LastName AS Manager,Count(e.EmployeeID) AS CountEmployees from Employees e
JOIN Employees m
ON
e.ManagerID = m.EmployeeID
GROUP BY m.FirstName + ' ' +m.LastName
HAVING COUNT(e.EmployeeID)=5

--12.Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".
SELECT e.FirstName + ' ' +e.LastName AS Employee,ISNULL(m.FirstName + ' ' + m.LastName,'I am Boss') AS Manager from Employees e
LEFT JOIN Employees m
ON m.EmployeeID = e.ManagerID

--13.Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.
SELECT e.FirstName,e.LastName from Employees e
WHERE LEN(e.LastName) = 5

--14.Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".
--Search in Google to find how to format dates in SQL Server.
--https://www.w3schools.com/sql/func_convert.asp
SELECT CONVERT(NVARCHAR(50),GETDATE(),104) + ' ' + CONVERT(NVARCHAR(50),GETDATE(),114) AS [DateTime]

--15.Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
--Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
--Define the primary key column as identity to facilitate inserting records.
--Define unique constraint to avoid repeating usernames.
--Define a check constraint to ensure the password is at least 5 characters long.
 Create TABLE Users(
					UserID INT IDENTITY,
					Username NVARCHAR(50) NOT NULL,
					Password NVARCHAR(50) NOT NULL,
					Fullname NVARCHAR(100) NOT NULL,
					Login DATETIME,
					CONSTRAINT PK_Users PRIMARY KEY(UserID),
					CONSTRAINT UK_Username UNIQUE(Username),
					CONSTRAINT CK_Password CHECK(LEN(Password)>=5)
					)

--16.Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
--Test if the view works correctly.
INSERT INTO Users(Username,Password,Fullname,Login)
VALUES
	  ('Venko','12345','Venko Ivanov',GETDATE()),
	  ('Maca','1234567','Petq Marinova',GETDATE())
GO

CREATE VIEW[First 2 Persons] AS
SELECT Username FROM Users
WHERE CONVERT(NVARCHAR(20),Login,104) = CONVERT(NVARCHAR(20),GETDATE(),104)
GO

INSERT INTO Users (Username, Password,LastLogin)
VALUES ('Batman','Peshterata01',GETDATE()),('Superman','outofearth',GETDATE())
GO
CREATE VIEW [First 10 Persons] AS
SELECT Username FROM Users
WHERE CONVERT(NVARCHAR(20),LastLogin,104) = CONVERT(NVARCHAR(20),GETDATE(),104)
GO

--17.Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
--Define primary key and identity column.
create TABLE Groups
					(
					GroupsID INT IDENTITY,
					Name NVARCHAR(50) NOT NULL,
					CONSTRAINT PK_Groups PRIMARY KEY(GroupsID),
					CONSTRAINT UK_Name UNIQUE(Name)
					)

--18.Write a SQL statement to add a column GroupID to the table Users.
--Fill some data in this new column and as well in the `Groups table.
--Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.

ALTER TABLE Users
ADD GroupID INT

ALTER TABLE Users
ADD CONSTRAINT FK_Users_Groups_GroupID FOREIGN KEY (GroupID)
REFERENCES Groups(GroupsID)

--19.Write SQL statements to insert several records in the Users and Groups tables.
INSERT INTO Users (Username, Password, Fullname, Login)
	VALUES ('Vlado','12345','TheWolf', GETDATE()),
		   ('Pepito','1234567','ForbiddenProgrammer', GETDATE()),
		   ('NoOne','12345sjaklsja','TheWolf', GETDATE());

INSERT INTO Groups (Name)
	VALUES('Hackers'),
		  ('Noobs'),
		  ('Zealots');


--20.Write SQL statements to update some of the records in the Users and Groups tables.
--CTRL + SHIFT + R update Table
UPDATE Users 
SET Username = 'Pencho',GroupId=2
WHERE Username = 'Vlado'

UPDATE Users
SET GroupID = 1 
WHERE GroupID is NULL

UPDATE TOP (1) Groups
set Name = 'Telerik Ninjas'

--Test
SELECT u.Fullname,g.Name FROM Users u,Groups g
WHERE u.groupID = g.GroupsID

--21.Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE FROM Users
WHERE Username = 'Pencho'

DELETE FROM Groups
WHERE Name = 'Zealots'

--22.Write SQL statements to insert in the Users table the names of all employees from the Employees table.
--Combine the first and last names as a full name.
--For username use the first letter of the first name + the last name (in lowercase).
--Use the same for the password, and NULL for last login time.
INSERT INTO Users (Username,Password)
SELECT FirstName+LastName,LOWER(FirstName+LastName) FROM Employees

--23.Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
UPDATE Users
SET Login = ('2010-3-10')
WHERE Login is NULL

ALTER TABLE Users
ALTER COLUMN Password NVARCHAR(100) NULL

UPDATE Users
SET Password = NULL
WHERE Login <='2010-3-10'

--24.Write a SQL statement that deletes all users without passwords (NULL password).
DELETE FROM Users
WHERE Password is NULL

--25.Write a SQL query to display the average employee salary by department and job title.
SELECT AVG(e.Salary) AS [AverageSalary],d.Name AS [Department Name],e.JobTitle AS [Job Title] from Employees e
join Departments d
ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name,e.JobTitle

SELECT d.Name AS Departament,e.JobTitle AS JobTitle,AVG(e.Salary) AS AvgSalary from Employees e,Departments d
where e.DepartmentID = d.DepartmentID
GROUP BY d.name,e.JobTitle

--26.Write a SQL query to display the minimal employee salary by department and job title along
-- with the name of some of the employees that take it.
SELECT d.Name AS Departament,e.JobTitle AS JobTitle,MIN(e.FirstName + ' ' +e.LastName) AS [The Poorest Guy],MIN(e.Salary) AS minSalary FROM Employees e,Departments d
where e.DepartmentID = d.DepartmentID
GROUP BY d.name,e.JobTitle
order BY d.Name ASC

--27.Write a SQL query to display the town where maximal number of employees work.
SELECT t.name AS [Town],COUNT(e.EmployeeID) AS [TotalEmployees] from Employees e
JOIN Addresses a ON e.AddressID = a.AddressID
JOIN Towns t ON a.TownID = t.TownID
GROUP BY t.Name
order BY [TotalEmployees] DESC

SELECT TOP 1 t.Name, COUNT(e.EmployeeID) AS [Number of employees]
FROM Employees e
JOIN Addresses a ON e.AddressID = a.AddressID
JOIN Towns t ON t.TownID = a.TownID
GROUP BY t.Name
ORDER BY [Number of employees] DESC

--28.Write a SQL query to display the number of managers from each town.
SELECT t.name AS Town,COUNT(DISTINCT e.ManagerID) AS totalManagers  from Employees e,Employees m,Addresses a,Towns t
WHERE e.ManagerID = m.EmployeeID
AND m.AddressID = a.AddressID
AND a.TownID = t.TownID
GROUP BY t.Name

SELECT t.name AS TownName,COUNT(e.ManagerID) AS totalManagers
FROM Employees e
JOIN Employees m ON e.ManagerID = m.EmployeeID
join Addresses a ON m.AddressID = a.AddressID
JOIN Towns t ON a.TownID = t.TownID
GROUP BY t.Name

--29.Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments).
--Don't forget to define identity, primary key and appropriate foreign key.
CREATE TABLE WorkHours (
WorkHoursID INT IDENTITY,
WorkDate DATETIME,
Task NVARCHAR(100),
Comments NVARCHAR(100),
EmployeeID INT,
WorkHours INT,
CONSTRAINT PK_WorkHoursID PRIMARY KEY(WorkHoursID) ,
CONSTRAINT FK_WorkHours_Employees_EmployeeID FOREIGN KEY(EmployeeID) REFERENCES Employees(EmployeeID)
)
--Issue few SQL statements to insert, update and delete of some data in the table.
INSERT INTO WorkHours
			(WorkDate,Task,Comments,EmployeeID,WorkHours)
		VALUES
			(GETDATE(), 'task 1', 'comment 1', 3, 8),
			(GETDATE(), 'task 2', 'comment 2', 10, 8),
			(GETDATE(), 'task 3', 'comment 3', 50, 7)
--Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
CREATE TABLE WorkHoursLogs(
	WorkHoursLogsID INT IDENTITY,
	LogCommand NVARCHAR(10),
	OldWorkHoursID INT,
	NewWorkHoursID INT,
	OldWorkDate DATETIME,
	NewWorkDate DATETIME,
	OldTask NVARCHAR(100),
	NewTask NVARCHAR(100),
	OldComments NVARCHAR(100),
	NewComments NVARCHAR(100),
	OldEmployeeID INT,
	NewEmployeeID INT,
	OldWorkHours INT,
	NewWorkHours INT,
	CONSTRAINT PK_WorkHoursLogsID PRIMARY KEY(WorkHoursLogsID) ,
	CONSTRAINT FK_WorkHours_Employees_OldEmployeeID FOREIGN KEY(OldEmployeeID) REFERENCES Employees(EmployeeID),
	CONSTRAINT FK_WorkHours_Employees_NewEmployeeID FOREIGN KEY(NewEmployeeID) REFERENCES Employees(EmployeeID))
GO

--For each change keep the old record data, the new record data and the command (insert / update / delete).
CREATE TRIGGER Tr_WorkHoursUpdate 
ON WorkHours
FOR UPDATE
AS
SET NOCOUNT ON
INSERT INTO WorkHoursLogs
SELECT 
	'UPDATED',
	d.WorkHoursID,
	i.WorkHoursID,
	d.WorkDate,
	i.WorkDate,
	d.Task,
	i.Task,
	d.Comments,
	i.Comments,
	d.EmployeeID,
	i.EmployeeID,
	d.WorkHours,
	i.WorkHours
FROM INSERTED i, DELETED d
GO

CREATE TRIGGER Tr_WorkHoursDelete 
ON WorkHours
FOR DELETE
AS
SET NOCOUNT ON
INSERT INTO WorkHoursLogs
SELECT 
	'DELETED',
	d.WorkHoursID,
	NULL,
	d.WorkDate,
	NULL,
	d.Task,
	NULL,
	d.Comments,
	NULL,
	d.EmployeeID,
	NULL,
	d.WorkHours,
	NULL
	FROM DELETED d
GO

CREATE TRIGGER Tr_WorkHoursInsert 
ON WorkHours
FOR INSERT
AS
INSERT INTO WorkHoursLogs
SELECT 
	'INSERTED',
	NULL,
	i.WorkHoursID,
	NULL,
	i.WorkDate,
	NULL,
	i.Task,
	NULL,
	i.Comments,
	NULL,
	i.EmployeeID,
	NULL,
	i.WorkHours
	FROM INSERTED i
GO

--tests for the triggers
UPDATE WorkHours
SET Task = 'task 1 updated updated'
WHERE Task = 'task 1 updated'

INSERT INTO WorkHours(WorkDate,Task,Comments,EmployeeID,WorkHours)
VALUES(GETDATE(),'TASK INSERTED','COMMENTS ON INSERTED TASK',20,6)

DELETE FROM WorkHours
WHERE Task = 'TASK INSERTED'

--30.Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables.
--At the end rollback the transaction.
BEGIN TRAN

ALTER TABLE Departments
DROP CONSTRAINT FK_Departments_Employees

DELETE FROM Employees
WHERE DepartmentID =
	(
	SELECT DepartmentID FROM Departments
	WHERE Name = 'Sales'
	)

ROLLBACK TRAN

--31.Start a database transaction and drop the table EmployeesProjects.
--Now how you could restore back the lost table data?

--Answer : Use BEGIN TRAN / ROLLBACK TRAN / COMMIT TRAN for all transactions that modify the database structure

--32.32. Find how to use temporary tables in SQL Server.
--Using temporary tables backup all records from EmployeesProjects and restore them back after dropping and re-creating the table.
BEGIN TRAN

CREATE TABLE #MyTemporaryTable
(
    EmployeeID int, 
	ProjectID int
)
SELECT EmployeeID, ProjectID FROM EmployeesProjects

DROP TABLE EmployeesProjects;

CREATE TABLE EmployeesProjects
(
    EmployeeID int, 
	ProjectID int
)
SELECT EmployeeID, ProjectID FROM #MyTemporaryTable

ROLLBACK TRAN















