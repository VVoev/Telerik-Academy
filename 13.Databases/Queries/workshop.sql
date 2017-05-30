--Your task is to normalize the database.
--Please use only SQL Queries in order to fully understand them.
--You are not allowed to use Management studio and create or modify tables from there.

--1.Create table Cities with (CityId, Name)
CREATE TABLE Cities
					(
					CityID INT PRIMARY KEY IDENTITY,
					Name NVARCHAR(50) NOT NULL
					)

--2.Insert into Cities all the Cities from Employees, Suppliers, Customers tables (RESULT: 95 row(s) affected)
INSERT INTO Cities 
	SELECT City 
		FROM Employees 
		WHERE City IS NOT NULL 
	UNION 
	SELECT CITY 
		FROM Suppliers 
		WHERE City IS NOT NULL 
	UNION 
	SELECT CITY 
		FROM Customers 
		WHERE City IS NOT NULL

--3.Add CityId into Employees, Suppliers, Customers tables which is Foreign Key to CityId in Cities
ALTER TABLE Employees
ADD CityId INT FOREIGN KEY REFERENCES Cities(CityID)

ALTER TABLE Suppliers
add CityId INT FOREIGN KEY REFERENCES Cities(CityID)

ALTER TABLE Customers
ADD CityId INT FOREIGN KEY REFERENCES Cities(CityID)

--4.Update Employees, Suppliers, Customers tables with CityId which is in the Cities table
UPDATE Employees 
SET CityId = c.CityId
FROM (
    SELECT Name, CityId
    FROM Cities) c
WHERE 
    c.Name = Employees.City

UPDATE Suppliers
set CityId = c.CityId 
FROM (
	SELECT name,cityID
	FROM Cities c) c
	WHERE c.name = Suppliers.City

UPDATE Customers
set CityId = c.CityId 
FROM (
	SELECT name,cityID
	FROM Cities c) c
	WHERE c.name = Customers.City

--5.Make the column Name in Cities Unique
ALTER TABLE Cities
ADD UNIQUE(Name)

--6.Now after looking at the database again we found there are Cities (ShipCity) in the Orders table as well :D
--(always read before start coding).
--Insert those cities please. (RESULT: 1 row(s) affected)
INSERT INTO Cities
SELECT DISTINCT ShipCity
FROM Orders o
WHERE o.ShipCity NOT IN(SELECT c.name FROM Cities c)

--7.Add CityId column in Orders with Foreign Key to CityId in Cities
ALTER TABLE Orders
ADD CityID int FOREIGN KEY REFERENCES Cities(CityID)

--8.Now rename that column to be ShipCityId to be consistent (use stored procedure :) )
EXEC sp_rename 'Orders.CityId','ShipCityID','COLUMN'

--9.Update ShipCityId in Orders table with values from Cities table (RESULT: 830 row(s) affected)
UPDATE Orders
SET Orders.ShipCityId = c.cityID
FROM (SELECT CityID,Name from Cities) c
WHERE c.name  = Orders.ShipCity

--10.Drop column ShipCity from Orders
ALTER TABLE Orders
DROP COLUMN ShipCity

--11.Create table Countries with columns CountryId and Name (Unique)
Create TABLE Countries
					(CountryID INT PRIMARY KEY IDENTITY,
					Name NVARCHAR(50) UNIQUE
					)

--12.Add CountryId to Cities with Foreign Key to CountryId in Countries
ALTER TABLE Cities
add CountryID INT FOREIGN KEY REFERENCES Countries(CountryID)

--13.Insert all the Countries from Employees, Customers, Suppliers and Orders (RESULT: 25 row(s) affected)
INSERT INTO Countries 
	SELECT Country FROM  Employees
	WHERE Country IS NOT NULL
	UNION
	SELECT Country FROM  Customers
	WHERE Country IS NOT NULL
	UNION
	SELECT ShipCountry FROM  Orders
	WHERE ShipCountry IS NOT NULL
	UNION
	SELECT Country FROM  Suppliers
	WHERE Country IS NOT NULL

--14.Update CountryId in Cities table with values from Countries table
UPDATE Cities
SET Cities.CountryId = CitiesInCountries.CountryId
FROM (
		(SELECT DISTINCT UnionCountries.CityId,
						 UnionCountries.Country,
						 Countries.CountryId 
		FROM 
			(SELECT Country, CityId 
				FROM Employees 
				WHERE CityId IS NOT NULL 
			UNION 
			SELECT Country, CityId 
				FROM Suppliers 
				WHERE CityId IS NOT NULL 
			UNION 
			SELECT Country, CityId 
				FROM Customers 
				WHERE CityId IS NOT NULL 
			UNION 
			SELECT ShipCountry, ShipCityId 
				FROM Orders 
				WHERE ShipCityId IS NOT NULL) UnionCountries 
		JOIN Countries ON
			Countries.Name = UnionCountries.Country)
		) CitiesInCountries
WHERE 
    Cities.CityId = CitiesInCountries.CityId

--15.Drop column City and ShipCity from Employees, Suppliers, Customers and Orders tables
ALTER TABLE Suppliers
DROP COLUMN City

ALTER TABLE Employees
DROP COLUMN City

ALTER TABLE Orders
DROP COLUMN ShipCity

ALTER TABLE Customers
DROP COLUMN City

--16.Drop column Country and ShipCountry from Employees, Customers, Suppliers and Orders tables
ALTER TABLE Orders
DROP COLUMN ShipCountry

ALTER TABLE Customers
DROP COLUMN Country

ALTER TABLE Employees
DROP COLUMN Country

ALTER TABLE Suppliers
DROP COLUMN Country











					