using Assignment2SQL.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2SQL.Repository
{
    public class CustomerSpenderRepository : ICustomerSpenderRepository
    {
        public List<CustomerSpender> GetCustomerSpenders()
        {
            List<CustomerSpender> customer = new List<CustomerSpender>();

            string sql = "SELECT SUM(Invoice.Total), Invoice.CustomerId, Customer.CustomerId, Customer.FirstName " +
                "FROM Invoice " +
                "INNER JOIN Customer ON Invoice.CustomerId = Customer.CustomerId " +
                "GROUP BY Customer.CustomerId, Invoice.CustomerId, Customer.FirstName " +
                "ORDER BY SUM(Invoice.Total) DESC;";
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
                                CustomerSpender temp = new CustomerSpender();
                                
                                temp.Total = (double) reader.GetDecimal(0);
                                temp.CustomerId = reader.GetInt32(1);
                                temp.CustomerFirstName = reader.GetString(3);

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
