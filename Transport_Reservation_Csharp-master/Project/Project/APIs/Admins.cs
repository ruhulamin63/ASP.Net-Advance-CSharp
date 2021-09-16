using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Project.Models
{
    public class Admins
    {
        SqlConnection conn;
        public Admins(SqlConnection conn)
        {
            this.conn = conn;
        }

        public bool addAdmin(dynamic admin)
        {
            conn.Open();
            string query = string.Format("INSERT INTO Admin VALUES('{0}', '{1}', '{2}')", admin.name, admin.username, admin.password);
            SqlCommand cmd = new SqlCommand(query, conn);
            int res = cmd.ExecuteNonQuery();
            conn.Close();
            if (res > 0) return true;
            return false;
        }

        public List<Admin> getAllAdmin()
        {
            conn.Open();
            string query = string.Format("SELECT * FROM Admin");
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Admin> adminlist = new List<Admin>();
            while (reader.Read())
            {
                Admin admin = new Admin();
                admin.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                admin.Name = reader.GetString(reader.GetOrdinal("Name")).Trim();
                admin.Username = reader.GetString(reader.GetOrdinal("Username")).Trim();
                //admin.Password = reader.GetString(reader.GetOrdinal("Password")).Trim();
                admin.Password = "*****";
                adminlist.Add(admin);
            }
            conn.Close();
            return adminlist;
        }
        public Admin searchAdmin(string username)
        {
            conn.Open();
            string query = string.Format("SELECT * FROM Admin WHERE Username='{0}'", username);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Admin admin = null;
            while (reader.Read())
            {
                admin = new Admin();
                admin.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                admin.Name = reader.GetString(reader.GetOrdinal("Name")).Trim();
                admin.Username = reader.GetString(reader.GetOrdinal("Username")).Trim();
                admin.Password = reader.GetString(reader.GetOrdinal("Password")).Trim();
            }
            conn.Close();
            return admin;
        }
        public bool deleteAdmin(int id)
        {
            conn.Open();
            string query = string.Format("DELETE FROM Admin WHERE Id={0}", id);
            SqlCommand cmd = new SqlCommand(query, conn);
            int res = cmd.ExecuteNonQuery();
            conn.Close();
            if (res > 0) return true;
            return false;
        }

        public bool updateAdmin(dynamic admin)
        {
            conn.Open();
            string query = string.Format("UPDATE Admin SET Name='{0}', Username='{1}', Password='{2}' WHERE Id={3}", admin.name, admin.username, admin.password, admin.id);
            SqlCommand cmd = new SqlCommand(query, conn);
            int res = cmd.ExecuteNonQuery();
            conn.Close();
            if (res > 0) return true;
            else return false;
        }
    }
}
