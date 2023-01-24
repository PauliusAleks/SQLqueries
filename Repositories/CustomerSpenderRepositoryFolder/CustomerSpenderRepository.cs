using Assignment2_BackEnd.Models;
using Assignment2_BackEnd.Repositories.CustomerRepositoryFolder;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_BackEnd.Repositories.CustomerSpenderRepositoryFolder
{
    public class CustomerSpenderRepository : ICustomerSpenderRepository
    {
        public List<CustomerSpender> GetHighestSpenders()
        {
            ICustomerRepository customerRepository = new CustomerRepository();
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
                                customerSpender.Customer = customerRepository.GetCustomerById(reader.GetInt32(0));
                                customerSpender.Total = (double)reader.GetDecimal(1);
                                customerSpenders.Add(customerSpender);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            return customerSpenders;
        }
    }
}
