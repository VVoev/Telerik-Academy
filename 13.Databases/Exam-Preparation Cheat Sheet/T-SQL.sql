--1. 
CREATE DATABASE People

USE PEOPLE

CREATE TABLE Persons(
	Id int PRIMARY KEY IDENTITY,
	FirstName nvarchar(50), 
	LastName nvarchar(50),
	SSN nvarchar(50),	
)
GO

CREATE TABLE Accounts(
	Id int PRIMARY KEY IDENTITY,
	Balance money NOT NULL,
	PersonId int FOREIGN KEY REFERENCES Persons(Id)
)
GO

INSERT INTO Persons VALUES
('Ivan', 'Ivanov', 'asdf123'),
('Petar', 'Petrov', 'asfa13243'),
('Georgi', 'Georgiev', 'asdfas123')
GO

INSERT INTO Accounts VALUES
(1000, 1),
(2000, 2),
(3000, 3)
GO

--2.
CREATE PROC usp_GetPeopleWithBalanceMoreThan(@minBalance money)
AS 
	SELECT p.FirstName, p.LastName, a.Balance  FROM Persons p 
	JOIN Accounts a ON a.PersonId = p.Id
	WHERE a.Balance > @minBalance
GO

EXECUTE usp_GetPeopleWithBalanceMoreThan 1000
GO

--3.
CREATE FUNCTION ufn_CalulateSumForInteres(@currentSum money, @yealyInterest money, @numberOfMonths int)
	RETURNS money
BEGIN
	DECLARE @monthlyInterest money
	SET @monthlyInterest = @yealyInterest / 12 / 100
	DECLARE @resultSum money
	SET @resultSum = @currentSum * (1 + @monthlyInterest)
	RETURN @resultSum
END
GO

--4.
CREATE PROCEDURE usp_UpdateBalanceForGivenInterestRateForAMonth(@accountId int, @interestRate money)
AS
	DECLARE @numberOfMonths int
	SET @numberOfMonths = 1

	UPDATE Accounts
	SET Balance = dbo.ufn_CalulateSumForInteres(Balance, @interestRate, @numberOfMonths)
	WHERE Id = @accountId
GO

EXECUTE usp_UpdateBalanceForGivenInterestRateForAMonth 1, 120
GO

--5.
CREATE PROCEDURE usp_WithdrawMoney(@accountId int, @money money)
AS 
	BEGIN TRAN
		UPDATE Accounts
		SET Balance = Balance - @money
		WHERE Id = @accountId
	COMMIT TRAN
GO

CREATE PROCEDURE usp_DepositMoney(@accountId int, @money money)
AS 
	BEGIN TRAN
		UPDATE Accounts
		SET Balance = Balance + @money
		WHERE Id = @accountId
	COMMIT TRAN
GO

EXEC usp_DepositMoney 1, 1 
SELECT * FROM Accounts
GO

EXEC usp_WithdrawMoney 1, 1
SELECT * FROM Accounts
GO

--6.
CREATE TABLE Logs(
	Id int PRIMARY KEY IDENTITY,
	AccountId int FOREIGN KEY REFERENCES Accounts(Id),
	OldSum money NOT NULL,
	NewSum money NOT NULL
)
GO

CREATE TRIGGER TR_Account_Update ON Accounts FOR UPDATE
AS 
	DECLARE @oldSum money
	
	SELECT @oldSum = Balance FROM deleted

	INSERT INTO Logs(AccountId, OldSum, NewSum)
		SELECT Id AS [AccountId], @oldSum AS [OldSum], Balance AS [NewSum]
		FROM inserted	 
GO

-- testing the trigger
UPDATE Accounts
SET Balance = 22
WHERE Id = 1
GO

USE TelerikAcademy
--7.
CREATE FUNCTION ufn_CanBeComprisedOf(@matchLetters nvarchar(200), @text nvarchar(200))
RETURNS BIT 
BEGIN 
	DECLARE @currentLetter nvarchar(1)
	DECLARE @index int
	DECLARE @textLength int

	SET  @textLength = LEN(@text)
	SET @index = 1
	WHILE (@index <= @textLength)
		BEGIN
			SET @currentLetter = SUBSTRING(@text, @index, 1)

			IF (CHARINDEX(@currentLetter, @matchLetters) <= 0)
				BEGIN
					RETURN 0
				END
			SET @index = @index + 1
		END
	RETURN 1
END 	
GO


CREATE FUNCTION ufn_GetNamesComprisedOf(@pattern nvarchar(50))
RETURNS TABLE 
AS 
	RETURN SELECT * FROM 
	(SELECT FirstName AS [Name] FROM Employees
		UNION 
		SELECT MiddleName AS [Name] FROM Employees
		UNION
		SELECT LastName AS [Name] FROM Employees
		UNION 
		SELECT Name AS [Name] FROM Towns) Names
	WHERE dbo.ufn_CanBeComprisedOf(@pattern, [Name]) = 1
	AND [Name] IS NOT NULL
GO

SELECT * FROM dbo.ufn_GetNamesComprisedOf('oistmiahf')

--8.
DECLARE Emp1 CURSOR READ_ONLY FOR 
SELECT e.FirstName, e.LastName, t.Name
FROM Employees e
JOIN Addresses a ON e.AddressID = a.AddressID
JOIN Towns t ON a.TownID = t.TownID

OPEN Emp1
	BEGIN
		DECLARE @firstName nvarchar(50), @lastName nvarchar(50), @town nvarchar(50)

		FETCH NEXT FROM Emp1 INTO @firstName, @lastName, @town

		WHILE @@FETCH_STATUS = 0
			BEGIN
					DECLARE Emp2 CURSOR READ_ONLY FOR 
					SELECT e.FirstName, e.LastName, t.Name
					FROM Employees e
					JOIN Addresses a ON e.AddressID = a.AddressID
					JOIN Towns t ON a.TownID = t.TownID
				OPEN Emp2
					BEGIN
						DECLARE @firstName2 nvarchar(50), @lastName2 nvarchar(50), @town2 nvarchar(50)

						FETCH NEXT FROM Emp2 INTO @firstName2, @lastName2, @town2

						WHILE @@FETCH_STATUS = 0
							BEGIN
								IF (@town = @town2 AND @firstName <> @firstName2 AND @lastName <> @lastName2)
									BEGIN
										PRINT @firstName + ' ' + @lastName + ', ' + @firstName2 + ' ' + @lastName2 + ' -> ' + @town
									END
								FETCH NEXT FROM Emp2 INTO @firstName2, @lastName2, @town2
							END
					END
				CLOSE Emp2
				DEALLOCATE Emp2

				FETCH NEXT FROM Emp1 INTO @firstName, @lastName, @town
			END
	END
CLOSE Emp1
DEALLOCATE Emp1