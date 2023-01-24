using Assignment2_BackEnd.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_BackEnd.Repositories.CustomerCountryRepositoryFolder
{
    public class CustomerCountryRepository : ICustomerCountryRepository
    {
        public List<CustomerCountry> GetCountryNames()
        {
            List<CustomerCountry> countriesWithCustomerNumbers = new List<CustomerCountry>();
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
                                countriesWithCustomerNumbers.Add(customerCountry);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return countriesWithCustomerNumbers;
        }
    }
}
