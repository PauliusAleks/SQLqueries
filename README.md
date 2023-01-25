# Assignment2 SQL

## SQL Scripts and SQL Data Reading 
Second assignment in Noroff .NET course. Data Persistence and Access module

## Description

#### Part one
In the first part of this assignment contained in the SqlScripts folder there are several SQLQuerys
that when run in their specified order will create a Superheroes database. We also created a script with
all the different querys in one script. This way you dont have to run all the querys seperatly.

### Part two
In the second part of this assignment we have created models for the different tables in a database 
called Chinook. We have manipulated the data via SQLQuerys using the SQLClient NuGet package and created
methods for accessing different values in the Customer table. This can be done via the Id and a specific name.
There is also methods for returning a set of customers using the OFFSET and FETCH NEXT ROWS ONLY from SQL Server, adding and updating customers.
For the last methods in this part we created repositorys for each data structure that was gonna be used for fetching the data.
This includes CustomerCountry which is used to return the number of customers in each country.
CustomerSpender is used to return what customers have the largest total in the invoice table.
And finally the CustomerGenre is used for a given customers favorite genre.


## Usage
The Querys can be run in a DBMS to create the databse and the C# code is run in visual studio

## Technologies
* C#
* .NET
* SQL Client
* Microsoft SQL Server Management Studio


## Contributers
* Paulius Aleksandravicius
* Erik Aardal

