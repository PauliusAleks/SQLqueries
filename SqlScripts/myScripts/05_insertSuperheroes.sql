-- Using the database SuperheroesDb
USE [SuperheroesDb];

-- Query for inserting values into the Superhero table
-- All fields contain varchar and id is auto incremented
INSERT INTO [Superhero] ([Name], [Alias], [Origin])
VALUES
 ('Hero1','Alias1','Origin1'),
 ('Hero2','Alias2','Origin2'),
 ('Hero3','Alias3','Origin3');
