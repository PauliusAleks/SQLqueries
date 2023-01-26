using Assignment2_BackEnd.Models;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_BackEnd.DataAccess
{
    /// <summary>
    /// This class is used to retrieve data from the database by invoking the methods implemented
    /// from ICustomerRepository interface(also IRepository).
    /// This Repository can be only used to work with Customer, CustomerCountry, CustomerSpender
    /// and CustomerGenre models.
    /// </summary>
    internal class CustomerRepository : ICustomerRepository
    {
        /// <summary>
        /// A method to return a list of all records in Customer table from the database.
        /// (1) Creates an SQL query to access wanted columns to return all records.
        /// (2) Creates a connection with the Database defined in ConnectionHelper and open it.
        /// (3) Creates a command that runs the SQL query in the database.
        /// (4) Creates an SqlDataReater and executes it on created command.
        /// (5) Reader reads every record and the values are added to a new Customer for each record.
        ///   * reader.IsDBNull(x) ? "NULL" : reader.GetString(x) is used to handle columnds that allow NULL values.
        /// (6) Adds Customer to the list.   
        /// (7) Prints Exception message if something goes wrong.
        /// (8) Returns the list with all records.
        /// </summary>
        /// <returns>IEnumerable list of Customer objects.</returns>
        public IEnumerable<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();
            string sqlQuery = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer();
                                customer.CustomerId = reader.GetInt32(0); // Customer Id is set to an int retrieved from 1st column(CustomerId) 
                                customer.FirstName = reader.GetString(1); // Customer FirstName is set to a string retrieved from 2st column(FirstName)
                                customer.LastName = reader.GetString(2); // Customer LastName is set to a string value retrieved from 3rd column(LastName)
                                customer.Country = reader.IsDBNull(3) ? "NULL" : reader.GetString(3); // Customer Country is set to a string retrieved from 4th column(Country)
                                customer.PostalCode = reader.IsDBNull(4) ? "NULL" : reader.GetString(4); // Customer PostalCode is set to a string retrieved from 5th column(PostalCode)
                                customer.Phone = reader.IsDBNull(5) ? "NULL" : reader.GetString(5); // Customer Phone is set to a string retrieved from 6th column(Phone)
                                customer.Email = reader.GetString(6); // Customer Email is set to a string retrieved from 7th column(Email)
                                customers.Add(customer); //Adds the values retrieved from the database to the Customer type list that is returned
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customers;
        }

        /// <summary>
        /// A method to find a Customer with given Id in Customer table from the database.
        /// (1) Creates an SQL query to find a record where its CustomerId matches given Id
        /// (2) Creates a connection with the Database defined in ConnectionHelper and open it.
        /// (3) Creates a command that runs the SQL query in the database with given parameters.
        /// (4) Creates an SqlDataReater and executes it on created command.
        /// (5) Reader reads the customer that matches the given Id.
        ///   * reader.IsDBNull(x) ? "NULL" : reader.GetString(x) is used to handle columnds that allow NULL values.
        /// (6) Creates customer with values found in the database.   
        /// (7) Prints Exception message if something goes wrong.
        /// (8) Returns the cutomer.  
        /// </summary>
        /// <param name="customerId">Finding Customer using its PK</param>
        /// <returns>Customer</returns>
        public Customer GetById(int customerId)
        {
            Customer customer = new Customer();
            string sqlQuery = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer " +
                              "WHERE CustomerId = @CustomerId";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", customerId); //Used AddWithValue method to secure the program against SQL injection.
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.IsDBNull(3) ? "NULL" : reader.GetString(3);
                                customer.PostalCode = reader.IsDBNull(4) ? "NULL" : reader.GetString(4);
                                customer.Phone = reader.IsDBNull(5) ? "NULL" : reader.GetString(5);
                                customer.Email = reader.GetString(6);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customer;
        }

        /// <summary>
        /// A method to find a Customer with given Name in Customer table from the database.
        /// (1) Creates an SQL query to find a record where its FirstName and LastName matches given Name
        /// (2) Creates a connection with the Database defined in ConnectionHelper and open it.
        /// (3) Creates a command that runs the SQL query in the database with given parameters.
        /// (4) Creates an SqlDataReater and executes it on created command.
        /// (5) Reader reads the customer that matches the given Name.
        ///   * reader.IsDBNull(x) ? "NULL" : reader.GetString(x) is used to handle columnds that allow NULL values.
        /// (6) Creates customer with values found in the database.   
        /// (7) Prints Exception message if something goes wrong.
        /// (8) Returns the cutomer. 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns>Customer</returns>
        public Customer GetCustomerByName(string firstName, string lastName)
        {
            Customer customer = new Customer();
            string sqlQuery = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer " +
                              $"WHERE FirstName LIKE @FirstName " +
                              $"AND LastName LIKE @LastName";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", firstName.IsNullOrEmpty() ? "NULL" : firstName);
                        command.Parameters.AddWithValue("@LastName", lastName.IsNullOrEmpty() ? "NULL" : lastName);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.IsDBNull(3) ? "NULL" : reader.GetString(3);
                                customer.PostalCode = reader.IsDBNull(4) ? "NULL" : reader.GetString(4);
                                customer.Phone = reader.IsDBNull(5) ? "NULL" : reader.GetString(5);
                                customer.Email = reader.GetString(6);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customer;
        }

        /// <summary>
        /// A method to return a page of records in Customer table from the database.
        /// (1) Creates an SQL query to access wanted columns to return a page records using limit and offset.
        /// (2) Creates a connection with the Database defined in ConnectionHelper and open it.
        /// (3) Creates a command that runs the SQL query in the database with given parameters.
        /// (4) Creates an SqlDataReater and executes it on created command.
        /// (5) Reader reads given amount of records after skipping offset and and the values are added to a new Customer for each record.
        ///   * reader.IsDBNull(x) ? "NULL" : reader.GetString(x) is used to handle columnds that allow NULL values.
        /// (6) Adds Customer to the list.   
        /// (7) Prints Exception message if something goes wrong.
        /// (8) Returns the list with records. 
        /// </summary>
        /// <param name="limit">Used FETCH NEXT ROWS ONLY, since using LIMIT was not possible in SERVER SQL</param>
        /// <param name="offset">ROWS to skip</param>
        /// <returns>IEnumerable list of customers</returns>
        public IEnumerable<Customer> GetPageOfCustomers(int limit, int offset)
        {
            List<Customer> customers = new List<Customer>();
            string sqlQuery = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer " +
                              "ORDER BY CustomerId " +
                             $"OFFSET @Offset ROWS " +
                             $"FETCH NEXT @Limit ROWS ONLY";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Limit", limit);
                        command.Parameters.AddWithValue("@Offset", offset);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer();
                                customer.CustomerId = reader.GetInt32(0);
                                customer.FirstName = reader.GetString(1);
                                customer.LastName = reader.GetString(2);
                                customer.Country = reader.IsDBNull(3) ? "NULL" : reader.GetString(3);
                                customer.PostalCode = reader.IsDBNull(4) ? "NULL" : reader.GetString(4);
                                customer.Phone = reader.IsDBNull(5) ? "NULL" : reader.GetString(5);
                                customer.Email = reader.GetString(6);
                                customers.Add(customer);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customers;
        }

        /// <summary>
        /// /// A method to add a Customer to the database based on the Customer model datastructure
        /// (1) Creates an SQL query to insert a record with FirstName, LastName, Country, PostalCode, Phone and Email
        /// (2) Creates a connection with the Database defined in ConnectionHelper and open it.
        /// (3) Creates a command that runs the SQL query in the database with given parameters.
        ///   * Customer.x.IsNullOrEmpty() ? "NULL" : Customer.x is used to handle columnds that allow NULL values. This field sets the value to the string "NULL" if the value is null.
        /// (4) Uses command.Parameters.AddWithValue() to insert the values to the fields of a customer table
        /// (5) Executes the query and sets the success variable to true if the values are correct
        /// (6) Returns the bool variable success that is false until the command is executed correctly. 
        /// </summary>
        /// <param name="customer">Customer type with values to insert to the database</param>
        /// <returns>true or false based on if the record is inserted correctly</returns>
        public bool Add(Customer customer)
        {
            bool success = false;
            string sqlQuery = "INSERT INTO Customer (FirstName, LastName, Country, PostalCode, Phone, Email)" +
                             $"VALUES (@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        command.Parameters.AddWithValue("@LastName", customer.LastName);
                        command.Parameters.AddWithValue("@Country", customer.Country.IsNullOrEmpty() ? "NULL" : customer.Country);
                        command.Parameters.AddWithValue("@PostalCode", customer.PostalCode.IsNullOrEmpty() ? "NULL" : customer.PostalCode);
                        command.Parameters.AddWithValue("@Phone", customer.Phone.IsNullOrEmpty() ? "NULL" : customer.Phone);
                        command.Parameters.AddWithValue("@Email", customer.Email);
                        success = command.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return success;
        }

        /// <summary>
        /// A method to update a record in the Database.
        /// (1) Creates an SQL query to update values of a record that matches given customer's Id.
        /// (2) Creates a connection with the Database defined in ConnectionHelper and open it.
        /// (3) Creates a command that runs the SQL query in the database with given parameters.
        ///   * AddWithValue("@X", customer.X.IsNullOrEmpty() ? "NULL" : customer.X) used to add NULL string instead of null.
        /// (4) Updates Customer.
        /// (5) If affected rows is more than 1, returns true, else false.
        /// (6) Prints Exception message if something goes wrong.
        /// </summary>
        /// <param name="customer">Customer to update</param>
        /// <returns>Bool value(true if succeeded, false if not)</returns>
        public bool Update(Customer customer)
        {
            bool success = false;
            string sqlQuery = $"UPDATE Customer SET FirstName = @FirstName , LastName = @LastName ," +
                              $"Country = @Country , PostalCode = @PostalCode , Phone = @Phone , Email = @Email" +
                              $" WHERE CustomerId = @CustomerId";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                        command.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        command.Parameters.AddWithValue("@LastName", customer.LastName);
                        command.Parameters.AddWithValue("@Country", customer.Country.IsNullOrEmpty() ? "NULL" : customer.Country);
                        command.Parameters.AddWithValue("@PostalCode", customer.PostalCode.IsNullOrEmpty() ? "NULL" : customer.PostalCode);
                        command.Parameters.AddWithValue("@Phone", customer.Phone.IsNullOrEmpty() ? "NULL" : customer.Phone);
                        command.Parameters.AddWithValue("@Email", customer.Email);
                        success = command.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return success;
        }

        /// <summary>
        /// A method to delete a record from the database.
        /// (1) Creates an SQL query to delete a record that matches given customer's Id.
        /// (2) Creates a connection with the Database defined in ConnectionHelper and open it.
        /// (3) Creates a command that runs the SQL query in the database with given parameters
        /// (4) Deletes Customer.
        /// (5) If affected rows is more than 1, returns true, else false.
        /// (6) Prints Exception message if something goes wrong. 
        /// </summary>
        /// <param name="customer">Customer to delete</param>
        /// <returns>bool value</returns>
        public bool Delete(Customer customer)
        {
            bool success = false;
            string sqlQuery = $"DELETE FROM Customer WHERE CustomerId = @customerId";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                        success = command.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return success;
        }

        /// <summary>
        /// A method to find every country in the customer table, and amount of customers in each of them.
        /// (1) Creates an SQL query find every country, count customers in them, group them by country.
        /// (2) Creates a connection with the Database defined in ConnectionHelper and open it.
        /// (3) Creates a command that runs the SQL query in the database.
        /// (4) Creates an SqlDataReater and executes it on created command.
        /// (5) Reader reads and gives values to the customer country model, Countries and amount of customers in each of them.
        /// (6) Adds CustomerCountry object to the list.   
        /// (7) Prints Exception message if something goes wrong.
        /// (8) Returns the list with records. 
        /// </summary>
        /// <returns>List of CustomerCountry objects</returns>
        public IEnumerable<CustomerCountry> GetCountriesWithNumberOfCustomers()
        {
            List<CustomerCountry> allCountriesWithCustomerNumber = new List<CustomerCountry>();
            string sqlQuery = "SELECT Country, COUNT(*) FROM Customer " +
                              "GROUP BY Country " +
                              "ORDER BY COUNT(*) DESC";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerCountry customerCountry = new CustomerCountry();
                                customerCountry.Country = reader.IsDBNull(0) ? "NULL" : reader.GetString(0);
                                customerCountry.NumberOfCustomers = reader.GetInt32(1);
                                allCountriesWithCustomerNumber.Add(customerCountry);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return allCountriesWithCustomerNumber;
        }

        /// <summary>
        /// /// A method to fetch the Customers with the highest sum of total invoices
        /// (1) Creates an SQL query to get the sum of the Total column from the invoice table and join it to a Customer
        /// (2) Creates a connection with the Database defined in ConnectionHelper and open it.
        /// (3) Creates a command that runs the SQL query in the database with given parameters.
        /// (4) Creates a temp CustomerSpender object to add the data from the database to a list of highest spenders
        /// (5) Gets the id and the total from Invoice and adds it to the list to be returned
        /// (6) Prints Exception message if something goes wrong.
        /// (7) Returns a list of the customers who are the highest spenders as a CustomerSpender list
        /// </summary>
        /// <returns>List of type CustomerSpender based on the CustomerSpender model</returns>
        public IEnumerable<CustomerSpender> GetHighestSpenders()
        {
            List<CustomerSpender> customerSpenders = new List<CustomerSpender>();
            string sqlQuery = "SELECT Customer.CustomerId, SUM(Invoice.Total) FROM Customer " +
                              "INNER JOIN Invoice " +
                              "ON Customer.CustomerId = Invoice.CustomerId " +
                              "GROUP BY Customer.CustomerId " +
                              "ORDER BY SUM(Invoice.Total) DESC";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerSpender customerSpender = new CustomerSpender();
                                customerSpender.Customer = GetById(reader.GetInt32(0));
                                customerSpender.Total = (double)reader.GetDecimal(1);
                                customerSpenders.Add(customerSpender);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customerSpenders;
        }

        /// <summary>
        /// A method to find favorite genre(top 2 if a tie) of a given costumer.
        /// (1) Creates an SQL query that matches each tables primary keys and gets names of genres that customer has bought and counts the quantity of them.
        /// (2) Creates a connection with the Database defined in ConnectionHelper and open it.
        /// (3) Creates a command that runs the SQL query in the database with given parameters.
        /// (4) Creates an SqlDataReater and executes it on created command.
        /// (5) Reader reads and CustomerGenre model's parameters are assigned a value, name and quantity.
        /// (6) Adds CustomerGenre object to the list.   
        /// (7) Prints Exception message if something goes wrong.
        /// (8) Returns the list with records.  
        /// </summary>
        /// <param name="customer">customer who's favorite genres are found</param>
        /// <returns>list of customer's favorite genrè/genres - list because there might be 2 records.</returns>
        public IEnumerable<CustomerGenre> GetFavoriteGenre(Customer customer)
        {
            List<CustomerGenre> resultList = new List<CustomerGenre>();
            string sqlQuery = "SELECT Genre.Name, COUNT(Genre.Name) as 'QuanityGenresBought' FROM Customer " +
                              "INNER JOIN Invoice " +
                              "ON Customer.CustomerId = Invoice.CustomerId " +
                              "INNER JOIN InvoiceLine " +
                              "ON Invoice.InvoiceId = InvoiceLine.InvoiceId " +
                              "INNER JOIN Track " +
                              "ON InvoiceLine.TrackId = Track.TrackId " +
                              "INNER JOIN Genre " +
                              "ON Track.GenreId = Genre.GenreId " +
                              "WHERE Customer.CustomerId = @CustomerId " +
                              "GROUP BY Genre.Name " +
                              "ORDER BY COUNT(Genre.Name) DESC ";
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerGenre customerGenre = new CustomerGenre();
                                string genreName = reader.IsDBNull(0) ? "NULL" : reader.GetString(0);
                                int quanitityFavoriteGenreRecordsBought = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                                customerGenre.GenreName = genreName;
                                customerGenre.QuanitityFavoriteGenreRecordsBought = quanitityFavoriteGenreRecordsBought;
                                resultList.Add(customerGenre);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return resultList;
        }
    }
}
