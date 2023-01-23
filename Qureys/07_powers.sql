--Query for inserting Powers and assigning these to Superheroes--
USE SuperheroesDb;

--Inserts Flying--
INSERT INTO [Power] (Power_Name, [Description])
VALUES ('Flying', 'Superhero can fly');
--Inserts Super Strength--
INSERT INTO [Power] (Power_Name, [Description])
VALUES ('Super Strength', 'Superhero can punch really hard');
--Inserts SuperSpeed--
INSERT INTO [Power] (Power_Name, [Description])
VALUES ('Super Speed', 'Superhero can run really fast');
--Inserts Invisibility--
INSERT INTO [Power] (Power_Name, [Description])
VALUES ('Invisibility', 'Superhero can turn invisible');

--Assigning Flying to superman--
INSERT INTO SuperheroPower (Superhero_ID, Power_ID)
VALUES (1,1)
--Assigning Super Strength to superman--
INSERT INTO SuperheroPower (Superhero_ID, Power_ID)
VALUES (1,2)
--Assigning Super Speed to superman--
INSERT INTO SuperheroPower (Superhero_ID, Power_ID)
VALUES (1,3)
--Assigning Flying to Batman--
INSERT INTO SuperheroPower (Superhero_ID, Power_ID)
VALUES (2,1)