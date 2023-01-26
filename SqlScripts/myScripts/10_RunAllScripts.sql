--Script to run all of the queries created in part 1 of the assignment 2.
GO
CREATE DATABASE [SuperheroesDb];

GO
CREATE TABLE [Superhero](
[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
[Name] NVARCHAR (30) UNIQUE NOT NULL,
[Alias] NVARCHAR (30) NOT NULL,
[Origin] NVARCHAR (50) NOT NULL
);
GO
CREATE TABLE [Assistant](
[Id] INT not null IDENTITY(1,1) PRIMARY KEY,
[Name] NVARCHAR (30) UNIQUE NOT NULL 
);
GO
CREATE TABLE [Power](
[Id] INT not null IDENTITY(1,1) PRIMARY KEY,
[Name] NVARCHAR (30) UNIQUE NOT NULL,
[Description] NVARCHAR (150) NOT NULL
);

GO
ALTER TABLE [Assistant]
ADD [HeroId] INT FOREIGN KEY REFERENCES [Superhero]([Id])

GO
CREATE TABLE [SuperheroLinkingPower](
[SuperheroId] INT FOREIGN KEY REFERENCES [Superhero]([Id]),
[PowerId] INT FOREIGN KEY REFERENCES Power([Id]),
PRIMARY KEY ([SuperheroId],[PowerId])
);

GO
INSERT INTO [Superhero] ([Name], [Alias], [Origin])
VALUES
	('Hero1','Alias1','Origin1'),
	('Hero2','Alias2','Origin2'),
	('Hero3','Alias3','Origin3');

 GO
INSERT INTO [Assistant] ([Name], [HeroId])
VALUES
	('Assistant1',1),
	('Assistant2',2),
	('Assistant3',3);

GO
INSERT INTO [Power]([Name],[Description])
VALUES
	('Power1','Description1'),
	('Power2','Description2'),
	('Power3','Description3'),
	('Power4','Description4');
GO
INSERT INTO [SuperheroLinkingPower]([SuperheroId], [PowerId])
VALUES
	(1,1),
	(1,2),
	(1,3),
	(2,2),
	(3,3);

GO
UPDATE [Superhero]
SET [Name] = 'SuperSuperHero1'
WHERE [id] = 1;

GO
DELETE FROM [Assistant] WHERE Name = 'Assistant2'
