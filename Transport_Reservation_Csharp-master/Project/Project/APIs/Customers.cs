using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Project.Models
{
    public class Customers
    {
        SqlConnection conn;
        public Customers(SqlConnection conn)
        {
            this.conn = conn;
        }

        public bool addCustomer(dynamic customer)
        {
            conn.Open();
            string query = string.Format("INSERT INTO Customers VALUES('{0}', '{1}')", customer.name, customer.phone);
            SqlCommand cmd = new SqlCommand(query, conn);
            int res = cmd.ExecuteNonQuery();
            conn.Close();
            if (res > 0) return true;
            return false;
        }
        public Customer searchCustomer(string phone)
        {
            conn.Open();
            string query = string.Format("SELECT * FROM Customers WHERE Phone='{0}'", phone);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Customer customer = null;
            while (reader.Read())
            {
                customer = new Customer();
                customer.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                customer.Name = reader.GetString(reader.GetOrdinal("Name")).Trim();
                customer.Phone = reader.GetString(reader.GetOrdinal("Phone")).Trim();
            }
            conn.Close();
            return customer;
        }
        public List<Customer> getAllCustomer()
        {
            conn.Open();
            string query = string.Format("SELECT * FROM Customers");
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Customer> customerlist = new List<Customer>();
            Customer customer = null;
            while (reader.Read())
            {
                customer = new Customer();
                customer.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                customer.Name = reader.GetString(reader.GetOrdinal("Name")).Trim();
                customer.Phone = reader.GetString(reader.GetOrdinal("Phone")).Trim();
                customerlist.Add(customer);
            }
            conn.Close();
            return customerlist;
        }
        public bool deleteCustomer(int cusId)
        {
            conn.Open();
            string query = string.Format("DELETE FROM Customers WHERE Id={0}", cusId);
            SqlCommand cmd = new SqlCommand(query, conn);
            int res = cmd.ExecuteNonQuery();
            conn.Close();
            if (res > 0) return true;
            return false;
        }
        public bool updateCustomer(dynamic customer)
        {
            conn.Open();
            string query = string.Format("UPDATE Customers SET Name='{0}', Phone='{1}' WHERE Id={2}", customer.name, customer.phone, customer.id);
            SqlCommand cmd = new SqlCommand(query, conn);
            int res = cmd.ExecuteNonQuery();
            conn.Close();
            if (res > 0) return true;
            return false;
        }
    }
}
