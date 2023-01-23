using Assignment2_BackEnd.Models;
using Assignment2_BackEnd.Models.CustomerModel;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_BackEnd.Repositories.CustomerGenreRepository
{
    public class CustomerGenreRepository : ICustomerGenreRepository
    {
        public List<string> GetFavoriteGenre(Customer customer)
        {
            List<string> resultList = new List<string>();
            string sqlQuery = "SELECT Genre.Name FROM Customer " +
                              "INNER JOIN Invoice " +
                              "ON Customer.CustomerId = Invoice.CustomerId " +
                              "INNER JOIN InvoiceLine " +
                              "ON Invoice.InvoiceId = InvoiceLine.InvoiceId " +
                              "INNER JOIN Track " +
                              "ON InvoiceLine.TrackId = Track.TrackId " +
                              "INNER JOIN Genre " +
                              "ON Track.GenreId = Genre.GenreId " +
                              $"WHERE Customer.CustomerId = {customer.CustomerId} " +
                              "GROUP BY Genre.Name " +
                              "ORDER BY COUNT(Genre.name) DESC ";
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
                                resultList.Add(reader.GetString(0));
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
