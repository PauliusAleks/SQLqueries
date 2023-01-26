using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2_BackEnd.DataAccess
{
    /// <summary>
    /// This class is used to generate a connection string by setting proper values to SqlConnectionStringBuilder parameters
    /// like DataSource(Server Name), InitialCatalog(Database Name) and IntegratedSecurity(Authentication).
    /// TrustServerCertificate was set to true, to avoid an error that occurs during the login process to the server.
    /// </summary>
    public class ConnectionHelper
    {
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = "N-NO-01-04-4753\\SQLEXPRESS";
            connectionStringBuilder.InitialCatalog = "Chinook";
            connectionStringBuilder.IntegratedSecurity = true;
            connectionStringBuilder.TrustServerCertificate = true;
            return connectionStringBuilder.ToString();
        }
    }
}
