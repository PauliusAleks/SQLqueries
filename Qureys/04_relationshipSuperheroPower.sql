-- Query for altering relationships between Superhero and Power--
USE SuperheroesDb;

CREATE TABLE SuperheroPower (
Superhero_ID INT NOT NULL,
Power_ID INT NOT NULL,
FOREIGN KEY (Superhero_ID) REFERENCES Superhero(ID),
FOREIGN KEY (Power_ID) REFERENCES [Power](ID),
PRIMARY KEY (Superhero_ID, Power_ID)
);