USE [SuperheroesDb];

INSERT INTO [Power]([Name],[Description])
VALUES
	('Power1','Description1'),
	('Power2','Description2'),
	('Power3','Description3'),
	('Power4','Description4');

INSERT INTO [SuperheroLinkingPower]([SuperheroId], [PowerId])
VALUES
	(1,1),
	(1,2),
	(1,3),
	(2,2),
	(3,3);