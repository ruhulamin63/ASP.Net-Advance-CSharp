using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Project.Models
{
    public class Sellers
    {
        SqlConnection conn;
        public Sellers() { }
        public Sellers(SqlConnection conn)
        {
            this.conn = conn;
        }

        public List<Salesman> getAllSalesman()
        {
            conn.Open();
            string query = string.Format("SELECT * FROM Salesman");
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Salesman> salesmanlist=new List<Salesman>();
            Salesman salesman = null;
            while (reader.Read())
            {
                salesman = new Salesman();
                salesman.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                salesman.Name = reader.GetString(reader.GetOrdinal("Name")).Trim();
                salesman.Username = reader.GetString(reader.GetOrdinal("Username")).Trim();
                salesman.Password = "*****"; //reader.GetString(reader.GetOrdinal("Password")).Trim();
                salesmanlist.Add(salesman);
            }
            conn.Close();
            return salesmanlist;
        }

        public bool addSalesMan(dynamic salesman)
        {
            conn.Open();
            string query = string.Format("INSERT INTO Salesman VALUES('{0}', '{1}', '{2}')", salesman.name, salesman.username, salesman.password);
            SqlCommand cmd = new SqlCommand(query, conn);
            int res = cmd.ExecuteNonQuery();
            conn.Close();
            if (res > 0) return true;
            return false;
        }

        public bool updateSalesman(dynamic salesman)
        {
            conn.Open();
            string query = string.Format("UPDATE Salesman SET Name='{0}', Username='{1}', Password='{2}' WHERE Id={3}", salesman.name, salesman.username, salesman.password, salesman.id);
            SqlCommand cmd = new SqlCommand(query, conn);
            int res = cmd.ExecuteNonQuery();
            conn.Close();
            if (res > 0) return true;
            return false;
        }

        public Salesman searchSalesman(string username)
        {
            conn.Open();
            string query = string.Format("SELECT * FROM Salesman WHERE Username='{0}'", username);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Salesman salesman = null;
            while (reader.Read())
            {
                salesman = new Salesman();
                salesman.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                salesman.Name = reader.GetString(reader.GetOrdinal("Name")).Trim();
                salesman.Username = reader.GetString(reader.GetOrdinal("Username")).Trim();
                salesman.Password = reader.GetString(reader.GetOrdinal("Password")).Trim();
            }
            conn.Close();
            return salesman;
        }

        public bool deleteSalesman(int id)
        {
            conn.Open();
            string query = string.Format("DELETE FROM Salesman WHERE Id='{0}'", id);
            SqlCommand cmd = new SqlCommand(query, conn);
            int res = cmd.ExecuteNonQuery();
            conn.Close();
            if (res > 0) return true;
            return false;
        }
    }
}
