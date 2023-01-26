--Queries to create tables and give them columns.
use [SuperheroesDb];

CREATE TABLE [Superhero](
[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
[Name] NVARCHAR (30) UNIQUE NOT NULL,
[Alias] NVARCHAR (30) NOT NULL,
[Origin] NVARCHAR (50) NOT NULL
);

CREATE TABLE [Assistant](
[Id] INT not null IDENTITY(1,1) PRIMARY KEY,
[Name] NVARCHAR (30) UNIQUE NOT NULL 
);

CREATE TABLE [Power](
[Id] INT not null IDENTITY(1,1) PRIMARY KEY,
[Name] NVARCHAR (30) UNIQUE NOT NULL,
[Description] NVARCHAR (150) NOT NULL
);