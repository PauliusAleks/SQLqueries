using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2SQL.Model;
using Microsoft.Data.SqlClient;

namespace Assignment2SQL.Repository
{
    public class ConnectionHelper
    {
        public static string GetConnectionString()
        {
            //ConnectionStringBuilder - Created connection string builder
            SqlConnectionStringBuilder connectStringBuilder = new SqlConnectionStringBuilder();
            connectStringBuilder.DataSource = "DESKTOP-V18G98H\\SQLEXPRESS";
            connectStringBuilder.InitialCatalog = "Chinook";
            connectStringBuilder.IntegratedSecurity = true;
            return connectStringBuilder.ConnectionString;
        }
    }
}
