using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Project.Models
{
    public class Authentication
    {
        SqlConnection conn;

        public Authentication() { }
        public Authentication(SqlConnection conn)
        {
            this.conn = conn;
        }

        public AuthModel Authenticate(string name, string password, string role)
        {
            conn.Open();
            string query = string.Format("SELECT * FROM {0} WHERE Username='{1}' AND Password='{2}'", role, name, password);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            AuthModel authModel = null;
            while (reader.Read())
            {
                authModel = new AuthModel();
                authModel.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                authModel.Name = reader.GetString(reader.GetOrdinal("Name"));
                authModel.Username = reader.GetString(reader.GetOrdinal("Username"));
                authModel.Password = reader.GetString(reader.GetOrdinal("Password"));
                authModel.Role = role;
            }
            conn.Close();
            return authModel;
        }
        
    }
}
