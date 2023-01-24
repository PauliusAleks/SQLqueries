USE [SuperheroesDb];
DROP TABLE IF EXISTS [SuperheroLinkingPower];

CREATE TABLE [SuperheroLinkingPower](
[SuperheroId] INT FOREIGN KEY REFERENCES [Superhero]([Id]),
[PowerId] INT FOREIGN KEY REFERENCES Power([Id]),
PRIMARY KEY ([SuperheroId],[PowerId])
);
