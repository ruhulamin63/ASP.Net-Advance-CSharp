using Product_MS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Product_MS.Models.Tables
{
    public class Users
    {
        SqlConnection conn;

        public Users(SqlConnection conn)
        {
            this.conn = conn;
        }

        public User Authenticate(string Username, string Password)
        {
            User user = null;

            conn.Open();
            string query = string.Format("select * from users where Username='{0}' and Password='{1}'", Username, Password);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                user = new User()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Username = reader.GetString(reader.GetOrdinal("Username")),
                    Password = reader.GetString(reader.GetOrdinal("Password"))
                };
            }
            conn.Close();
            return user;
        }

        public string GetUserType(string username)
        {
            string type = "Admin";

            conn.Open();
            string query = string.Format("select Type from users where Username='{0}'", username);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                type = reader.GetString(reader.GetOrdinal("Type"));
            }
            conn.Close();
            return type;
        }

    }
}