using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Project.Models
{
    public class Managers
    {
        SqlConnection conn;

        public Managers() { }
        public Managers(SqlConnection conn)
        {
            this.conn = conn;
        }

        public bool addManager(dynamic manager)
        {
            conn.Open();
            string query = string.Format("INSERT INTO Managers VALUES ('{0}', '{1}', '{2}')", manager.name, manager.username, manager.password);
            SqlCommand cmd = new SqlCommand(query, conn);
            var result = cmd.ExecuteNonQuery();
            conn.Close();
            if (result > 0) return true;
            return false;
        }

        public List<Manager> getAllManager()
        {
            conn.Open();
            string query = string.Format("SELECT * FROM Managers");
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Manager> managerlist = new List<Manager>();
            Manager manager = null;
            while (reader.Read())
            {
                manager = new Manager();
                manager.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                manager.Name = reader.GetString(reader.GetOrdinal("Name")).Trim();
                manager.Username = reader.GetString(reader.GetOrdinal("Username")).Trim();
                manager.Password = "*****";
                managerlist.Add(manager);
            }
            conn.Close();
            return managerlist;
        }

        public Manager getManager(string username)
        {
            conn.Open();
            string query = string.Format("SELECT * FROM Managers WHERE Username='{0}'", username);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Manager manager = null;
            while (reader.Read())
            {
                manager = new Manager();
                manager.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                manager.Name = reader.GetString(reader.GetOrdinal("Name")).Trim();
                manager.Username = reader.GetString(reader.GetOrdinal("Username")).Trim();
                manager.Password = reader.GetString(reader.GetOrdinal("Password")).Trim();
            }
            conn.Close();
            return manager;
        }

        public bool updateManager(dynamic manager)
        {
            conn.Open();
            string query = string.Format("UPDATE Managers SET Name='{0}', Username='{1}', Password='{2}' WHERE Id={3}", manager.name, manager.username, manager.password, manager.id);
            SqlCommand cmd = new SqlCommand(query, conn);
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            if (result > 0) return true;
            return false;
        }

        public bool deleteManager(int id)
        {
            conn.Open();
            string query = string.Format("DELETE FROM Managers WHERE Id={0}", id);
            SqlCommand cmd = new SqlCommand(query, conn);
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            if (result > 0) return true;
            return false;
        }
    }
}
