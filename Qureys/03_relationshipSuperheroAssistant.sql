-- Query for altering relationships between Superhero and Assistant--

--Adds a column for foreign key 
ALTER TABLE Assistant
ADD Superhero_ID INT NOT NULL;

--Adds a foreign key for a Superhero in Assistant
ALTER TABLE Assistant
ADD FOREIGN KEY (Superhero_ID) REFERENCES Superhero(ID);