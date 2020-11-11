using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace PlantAppSE.DBConn
{
    public class DBConn
    {
        public static SqlConnection connect()
        {
            SqlConnection connection = null;
            try
            {
                // Build connection string
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                /*builder.DataSource = @"localhost\sqlexpress";   // update me
                builder.IntegratedSecurity = true;
                builder.InitialCatalog = "PlantApp";*/


                //LOCAL
                //                builder.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PlantAppLocal"].ConnectionString;
                //PRODUCTION
                //                builder.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PlantAppProd"].ConnectionString;
                builder.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PlantApp"].ConnectionString;
                // Connect to SQL
                Console.Write("Connecting to SQL Server ... ");
                connection = new SqlConnection(builder.ConnectionString);
                connection.Open();
                Console.WriteLine("Done.");

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;

            }
            return connection;
        }
    }
}