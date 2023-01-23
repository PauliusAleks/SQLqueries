using Assignment2_BackEnd.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_BackEnd.Repositories.CustomerRepositoryFolder
{
    internal class CustomerRepository : ICustomerRepository
    {
        public bool AddCustomer(Customer customer)
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
        public bool DeleteCustomer(Customer customer)
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
                Console.WriteLine(ex.Message); ;
            }
            return success;
        }
        public List<Customer> GetAllCustomers()
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
        public Customer GetCustomerById(int customerId)
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
            catch (Exception)
            {
                throw;
            }
            return customer;
        }
        public Customer GetCustomerByName(string firstName, string lastName)
        {
            Customer customer = new Customer();
            string sqlQuery = "SELECT CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer " +
                              $"WHERE FirstName LIKE @FirstName " +
                              $"AND LastName LIKE @LastName";
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
            return customer;
        }
        public List<Customer> GetPageOfCustomers(int limit, int offset)
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
        public bool UpdateCustomer(Customer customer)
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
    }
}
