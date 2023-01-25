using Assignment2_BackEnd.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_BackEnd.DataAccess
{
    internal class CustomerRepository : ICustomerRepository
    {
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
                        command.Parameters.AddWithValue("@CustomerId", customerId);
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
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
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
                        command.Parameters.AddWithValue("@Country", customer.Country);
                        command.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        command.Parameters.AddWithValue("@Phone", customer.Phone);
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
                        command.Parameters.AddWithValue("@Country", customer.Country);
                        command.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        command.Parameters.AddWithValue("@Phone", customer.Phone);
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
