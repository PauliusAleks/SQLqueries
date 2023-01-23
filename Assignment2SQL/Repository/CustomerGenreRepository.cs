using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2SQL.Model;
using Microsoft.Data.SqlClient;

namespace Assignment2SQL.Repository
{
    public class CustomerGenreRepository : ICustomerGenreRepository
    {
        public CustomerGenre GetCustomerGenres()
        {
            CustomerGenre customer = new CustomerGenre();

            string sql = "SELECT MAX(Invoice.Total), Invoice.CustomerId, Customer.CustomerId, Customer.FirstName " +
                "FROM Invoice " +
                "INNER JOIN Customer ON Invoice.CustomerId = Customer.CustomerId " +
                "GROUP BY Customer.CustomerId, Invoice.CustomerId, Customer.FirstName " +
                "ORDER BY MAX(Invoice.Total) DESC;";
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
                                customer.Genre = reader.GetString(0);
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
