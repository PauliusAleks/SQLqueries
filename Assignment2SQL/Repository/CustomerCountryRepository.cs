using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2SQL.Model;
using Microsoft.Data.SqlClient;

namespace Assignment2SQL.Repository
{
    public class CustomerCountryRepository : ICustomerCountryRepository
    {
        public List<CustomerCountry> GetCustomersInCountry()
        {
            List<CustomerCountry> customer = new List<CustomerCountry>();

            string sql = "SELECT COUNT(Country), Country FROM Customer " +
                "GROUP BY Country " +
                "ORDER BY COUNT(Country) DESC;";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.GetConnectionString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerCountry temp = new CustomerCountry();
                                temp.NumberOfCostumers = reader.GetInt32(0);
                                temp.Country = reader.IsDBNull(1) ? "NULL" : reader.GetString(1); 

                                customer.Add(temp);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customer;
        }
    }
}
