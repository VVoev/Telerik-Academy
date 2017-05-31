## Your task is to normalize the database and move the data to new tables. Please use only SQL Queries in order to fully understand them. You are not allowed to use Management studio and create or modify tables from there.

1. Create table Cities with (CityId, Name)

```sql
CREATE TABLE Cities
(
	CityId INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(15) 
)
```

2. Insert into Cities all the Cities from Employees, Suppliers, Customers tables (RESULT: 95 row(s) affected)

```sql
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
```

3. Add CityId into Employees, Suppliers, Customers tables which is Foreign Key to CityId in Cities

```sql
ALTER TABLE Employees
ADD CityId INT FOREIGN KEY REFERENCES Cities(CityId)

ALTER TABLE Suppliers
ADD CityId INT FOREIGN KEY REFERENCES Cities(CityId)

ALTER TABLE Customers
ADD CityId INT FOREIGN KEY REFERENCES Cities(CityId)
```

4. Update Employees, Suppliers, Customers tables with CityId which is in the Cities table

	- Employees (RESULT: 9 row(s) affected)

	- Suppliers (RESULT: 29 row(s) affected)

	- Customers (RESULT: 91 row(s) affected)

```sql
UPDATE Suppliers 
SET CityId = c.CityId
FROM (
    SELECT Name, CityId
    FROM Cities) c
WHERE 
    c.Name = Suppliers.City

UPDATE Employees 
SET CityId = c.CityId
FROM (
    SELECT Name, CityId
    FROM Cities) c
WHERE 
    c.Name = Employees.City

UPDATE Customers 
SET CityId = c.CityId
FROM (
    SELECT Name, CityId
    FROM Cities) c
WHERE 
    c.Name = Customers.City
```

5. Make the column Name in Cities Unique

```sql
ALTER TABLE Cities
ADD  UNIQUE (Name)
```

6. Now after looking at the database again we found there are Cities (ShipCity) in the Orders table as well :D (always read before start coding). Insert those cities please. (RESULT: 1 row(s) affected)


```sql
INSERT INTO Cities(Name)
	SELECT DISTINCT ShipCity
		FROM Orders
		WHERE ShipCity NOT IN (SELECT Name FROM Cities)
```

7. Add CityId column in Orders with Foreign Key to CityId in Cities

```sql
ALTER TABLE Orders
ADD CityId INT FOREIGN KEY REFERENCES Cities(CityId)
```

8. Now rename that column to be ShipCityId to be consistent (use stored procedure :) )

```sql
EXEC sp_RENAME 'Orders.CityId' , 'ShipCityId', 'COLUMN'
```


9. Update ShipCityId in Orders table with values from Cities table (RESULT: 830 row(s) affected)

```sql
UPDATE Orders
SET Orders.ShipCityId = c.CityId
FROM
	(SELECT CityId, Name 
	FROM Cities) c
WHERE c.Name = Orders.ShipCity
```

10. Create table Countries with columns CountryId and Name (Unique)

```sql
CREATE TABLE Countries
(
	CountryId INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(15) UNIQUE
)
```

11. Add CountryId to Cities with Foreign Key to CountryId in Countries

```sql
ALTER TABLE Cities
ADD CountryId int FOREIGN KEY REFERENCES Countries(CountryId)
```

12. Insert all the Countries from Employees, Customers, Suppliers and Orders (RESULT: 25 row(s) affected)

```sql
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
```

13. Update CountryId in Cities table with values from Countries table

```sql
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
```

14. Drop column City and ShipCity from Employees, Suppliers, Customers and Orders tables

```sql
ALTER TABLE Suppliers
DROP COLUMN City

ALTER TABLE Employees
DROP COLUMN City

ALTER TABLE Orders
DROP COLUMN ShipCity

ALTER TABLE Customers
DROP COLUMN City
```

```
In Customers table there is an error
(
	Msg 5074, Level 16, State 1, Line 91
The index 'City' is dependent on column 'City'.
Msg 4922, Level 16, State 9, Line 91
ALTER TABLE DROP COLUMN City failed because one or more objects access this column.
)
Think about that error :)
```

```sql
DROP INDEX Customers.City
ALTER TABLE Customers
DROP COLUMN City
```

15. Drop column Country and ShipCountry from Employees, Customers, Suppliers and Orders tables

```sql
ALTER TABLE Orders
DROP COLUMN ShipCountry

ALTER TABLE Customers
DROP COLUMN Country

ALTER TABLE Employees
DROP COLUMN Country

ALTER TABLE Suppliers
DROP COLUMN Country
```
