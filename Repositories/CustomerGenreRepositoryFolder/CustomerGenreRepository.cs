using Assignment2_BackEnd.Models;
using Assignment2_BackEnd.Repositories.CustomerRepositoryFolder;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_BackEnd.Repositories.CustomerGenreRepositoryFolder
{
    public class CustomerGenreRepository : ICustomerGenreRepository
    {
        public List<CustomerGenre> GetFavoriteGenre(Customer customer)
        {
            List<CustomerGenre> resultList = new List<CustomerGenre>();
            string sqlQuery = "SELECT Genre.Name, SUM(InvoiceLine.Quantity) as 'QuanityRecordsBought' FROM Customer " +
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
                              "ORDER BY SUM(InvoiceLine.Quantity) DESC ";
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
