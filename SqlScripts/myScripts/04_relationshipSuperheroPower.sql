--Used to use correct Database
USE [SuperheroesDb];
--Creating linking table for many to many relationship between hero and superpower.
--using their PK to create FK and making them UNIQUE.
CREATE TABLE [SuperheroLinkingPower](
[SuperheroId] INT FOREIGN KEY REFERENCES [Superhero]([Id]),
[PowerId] INT FOREIGN KEY REFERENCES Power([Id]),
PRIMARY KEY ([SuperheroId],[PowerId])
);
