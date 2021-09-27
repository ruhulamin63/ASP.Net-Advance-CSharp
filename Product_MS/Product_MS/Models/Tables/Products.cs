using Product_MS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Product_MS.Models.Tables
{
    public class Products
    {
        SqlConnection conn;
        public Products(SqlConnection conn)
        {
            this.conn = conn;
        }

        public void Create(Product p)
        {
            conn.Open();
            string query = String.Format("insert into products values ('{0}','{1}','{2}','{3}', '{4}')", p.Id, p.Name, p.Qty, p.Price, p.Desc);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<Product> Get()
        {
            conn.Open();
            string query = "select * from products";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                Product p = new Product()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Qty = reader.GetInt32(reader.GetOrdinal("Qty")),
                    Price = reader.GetInt32(reader.GetOrdinal("Price")),
                    Desc = reader.GetString(reader.GetOrdinal("Desc")),

                };
                products.Add(p);
            }

            conn.Close();

            return products;
        }

        public Product Get(int id)
        {
            conn.Open();
            string query = String.Format("Select * from products where Id={0}", id);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            Product p = null;

            while (reader.Read())
            {
                p = new Product()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Qty = reader.GetInt32(reader.GetOrdinal("Qty")),
                    Price = reader.GetInt32(reader.GetOrdinal("Price")),
                    Desc = reader.GetString(reader.GetOrdinal("Desc")),
                };
            }
            conn.Close();

            return p;
        }

        ///*
        public void Update(Product p)
        {
            conn.Open();
            string query = String.Format("update products set Name={1}, Qty={2}, Price={3}, Desc={4} where Id={0}", p.Name, p.Qty, p.Price, p.Desc);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            conn.Close();
        }
        // */

        public Product Delete(int id)
        {
            conn.Open();
            string query = String.Format("delete from products where Id={0}",id);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            Product p = null;
          
            conn.Close();

            return p;
        }
    }
}