USE [SuperheroesDb];

ALTER TABLE [Assistant]
ADD [HeroId] INT FOREIGN KEY REFERENCES [Superhero]([Id])