--1.List all superheroes in Earth
--In the format
--Id 	Name
--1 	Iron man
--2 	The Hulk
--3 	Thor

SELECT s.Id AS Id,s.name AS Name from Superheroes s,Planets p,PlanetSuperheroes ps
WHERE s.id =ps.Superhero_Id AND p.id = ps.Planet_Id and p.name = 'Earth'

--2.List all superheroes with their powers and powerTypes
--In the format
--Superhero 	Power
--Irom Man 	     Armored Suit (Tech)
--Irom Man 	     Genius (Intelligence)
--Groot 	     I am groot (Intelligence)

SELECT s.name as Superhero,p.Name + '('+pt.Name +')' AS [Power] from Superheroes s
JOIN PowerSuperheroes ps ON s.id = ps.Superhero_Id
JOIN Powers p ON p.id = ps.Power_Id
JOIN PowerTypes pt ON pt.id = p.PowerTypeId

--3.List the top 5 planets, sorted by count of superheroes with alignment 'Good', then by Planet Name
--In the format
--Planet 		Protectors
--Earth 		6
--Asgard 		1
--Apocalypse 	0  //There is no such planet
--Titan 		0 //There is no such planet

SELECT p.name AS [Planet],COUNT(s.id) AS Protectors from Superheroes s,Alignments a,Planets p,PlanetSuperheroes ps
WHERE s.id = ps.Superhero_Id AND p.id = ps.Planet_Id and s.Alignment_Id =a.Id AND a.Name = 'Good'
GROUP BY p.Name

--4.Create a stored procedure to edit superheroes Bio, by provided Superhero's Id and the new bio
--Name it usp_UpdateSuperheroBio
CREATE PROCEDURE usp_UpdateSuperheroBio(@accountId int, @newbio NVARCHAR(30))
AS
	BEGIN
		UPDATE Superheroes
		SET Bio = @newbio
		WHERE Id = @accountId
END

--TEST
--EXEC usp_UpdateSuperheroBio @accountId = 1
--,@newbio = 'nov chovek'
--SELECT * from Superheroes s
--SELECT * from Superheroes s


--5.Create a stored prodecure, that gives full information about a superhero, by provided Superhero's Id
--Name it usp_GetSuperheroInfo
--In the format
--Id 	Name 	Secret Identity 	Bio 	Alignment 	Planet 		Power
--1 	Groot 	Groot 				NULL 	Good 		Earth 		Super strength
--1 	Groot 	Groot 				NULL 	Good 		The Galaxy 	Super strength
--1 	Groot 	Groot 				NULL 	Good 		Earth 		Immortal
--1 	Groot 	Groot 				NULL 	Good 		The Galaxy 	Immortal
--1 	Groot 	Groot 				NULL 	Good 		Earth 		I am groot
--1 	Groot 	Groot 				NULL 	Good 		The Galaxy 	I am groot

--Query Answer   (Ebax go v querito....)
--SELECT s.name AS [Name],s.SecretIdentity as [Secret Identity],s.Bio AS [Bio],a.Name AS [Alignment],p.name as [Planet],p1.name AS [Power]
--from Superheroes s,Planets p,Alignments a,PlanetSuperheroes ps,PowerSuperheroes ps1,Powers p1
--WHERE s.Id =ps.Superhero_Id and p.id = ps.Planet_Id AND s.Alignment_Id = a.Id AND ps1.Superhero_Id = s.Id
--and p1.id = ps1.Power_Id
--AND s.id = 2

CREATE PROCEDURE usp_GetSuperheroInfo(@accountId int)
AS
	BEGIN
		SELECT s.name AS [Name],s.SecretIdentity as [Secret Identity],s.Bio AS [Bio],a.Name AS [Alignment],p.name as [Planet],p1.name AS [Power]
		from Superheroes s,Planets p,Alignments a,PlanetSuperheroes ps,PowerSuperheroes ps1,Powers p1
		WHERE s.Id =ps.Superhero_Id and p.id = ps.Planet_Id AND s.Alignment_Id = a.Id AND ps1.Superhero_Id = s.Id
		and p1.id = ps1.Power_Id
		AND s.id = @accountId
END

--TEST
--EXEC usp_GetSuperheroInfo23 @accountId = 1
--EXEC usp_GetSuperheroInfo23 @accountId = 2


--6.
--Currently working only for good heroes
--Create a stored procedure that prints the number of heroes with Good, Evil and Neutral alignment for each Planet
--Name it usp_GetPlanetsWithHeroesCount
--In the format

--Planet 		Good heroes 	Neutral heroes 	Evil heroes
--Earth 		6 					0 				4
--Asgard 		1 					0 				1
--Apocalypse 	0 					1 				1
--Titan 		0 					1 				1

SELECT p.name AS Planet,COUNT(s.Id) AS GoodHeroes FROM  Superheroes s,Alignments a,PlanetSuperheroes ps,Planets p
WHERE s.Alignment_Id = a.Id AND s.id = ps.Superhero_Id and p.id = ps.Planet_Id AND a.name = 'Good'
GROUP by p.name

CREATE PROCEDURE usp_GetPlanetsWithHeroesCount22
AS
	BEGIN
		SELECT p.name AS Planet,COUNT(s.Id) AS GoodHeroes FROM  Superheroes s,Alignments a,PlanetSuperheroes ps,Planets p
		WHERE s.Alignment_Id = a.Id AND s.id = ps.Superhero_Id and p.id = ps.Planet_Id AND a.name = 'Good'
		GROUP by p.name
END

EXEC usp_GetPlanetsWithHeroesCount22

--7.
--Create a stored procedure for creating a Superhero, with provided name, secret identity, bio, alignment, a planet and 3 powers (with their types)
--Powers, power types, planet and alignement should be reused, if they are already in the database




--8.Create a stored procedure that prints the number of powers by alignment of their superheroes
--Name it usp_PowersUsageByAlignment
--In the format


--The query...

--SELECT a.name,COUNT(a.id) AS PowerCount from Superheroes s,Alignments a,PowerSuperheroes ps,Powers p
--WHERE s.Alignment_Id = a.Id and s.id = ps.Superhero_Id AND p.id = ps.Power_Id and a.name = 'Good'
--GROUP BY a.Name
--UNION
--SELECT a.Name ,COUNT(a.id) AS Count from Superheroes s,Alignments a,PowerSuperheroes ps,Powers p
--WHERE s.Alignment_Id = a.Id and s.id = ps.Superhero_Id AND p.id = ps.Power_Id and a.name = 'Evil'
--GROUP BY a.Name


--Alignment 	Powers Count
-- Good 			15
-- Evil 			10

CREATE PROCEDURE usp_PowersUsageByAlignment
AS
		BEGIN
		SELECT a.name,COUNT(a.id) AS PowerCount from Superheroes s,Alignments a,PowerSuperheroes ps,Powers p
		WHERE s.Alignment_Id = a.Id and s.id = ps.Superhero_Id AND p.id = ps.Power_Id and a.name = 'Good'
		GROUP BY a.Name
		UNION
		SELECT a.Name ,COUNT(a.id) AS Count from Superheroes s,Alignments a,PowerSuperheroes ps,Powers p
		WHERE s.Alignment_Id = a.Id and s.id = ps.Superhero_Id AND p.id = ps.Power_Id and a.name = 'Evil'
		GROUP BY a.Name
END

EXEC usp_PowersUsageByAlignment















