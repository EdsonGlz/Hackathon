using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;

namespace PlantAppSE
{
    public class LoginOps : DBConn.DBConn
    {
        public static bool validateUsers(string user, string pass)
        {
            if (user.Contains(";") | user.Contains("'") | user.Contains("\"") |
                pass.Contains(";") | pass.Contains("'") | pass.Contains("\""))
            {
                return false;
            }
            try
            {
                SqlConnection conn = connect();
                string query = "SELECT Usuario FROM Usuario WHERE @username = Usuario.Usuario AND @pass= Usuario.Password;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@username", user);
                cmd.Parameters.AddWithValue("@pass", pass);
                cmd.Connection = conn;
                SqlDataReader reader = cmd.ExecuteReader();
                string u = "";
                while (reader.Read())
                {
                    u = reader[0].ToString();
                }

                if (u != "")
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return false;
        }


    }


}