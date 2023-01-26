-- Using the database SuperheroesDb
USE [SuperheroesDb];

-- Query for inserting values into the Power table
-- Values are varchar and id is auto incremented
INSERT INTO [Power]([Name],[Description])
VALUES
	('Power1','Description1'),
	('Power2','Description2'),
	('Power3','Description3'),
	('Power4','Description4');

-- Query for assigning a Power to a Superhero in the SuperheroLinkingPower table
-- Values are ids from the Superhero table and ids from the Power table
-- Both columns are foreign keys and make up a composite key that is used as primary key for the table
INSERT INTO [SuperheroLinkingPower]([SuperheroId], [PowerId])
VALUES
	(1,1),
	(1,2),
	(1,3),
	(2,2),
	(3,3);