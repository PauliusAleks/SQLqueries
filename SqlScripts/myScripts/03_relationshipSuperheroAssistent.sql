-- Using the database SuperheroesDb
USE [SuperheroesDb];

-- Query for altering the relationship between a Superhero and an Assistant
-- Adding a foreign key to Assistant for a one to many relationship 
ALTER TABLE [Assistant]
ADD [HeroId] INT FOREIGN KEY REFERENCES [Superhero]([Id])