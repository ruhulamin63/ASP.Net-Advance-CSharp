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
            string query = String.Format("insert into products values ('{0}','{1}','{2}','{3}', '{4}')", p.Id, p.Name, p.Qty, p.Price, p.Descs);
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
                    Descs = reader.GetString(reader.GetOrdinal("Descs")),

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
                    Descs = reader.GetString(reader.GetOrdinal("Descs")),
                };
            }
            conn.Close();

            return p;
        }

        ///*
        public void Update(Product p)
        {
            conn.Open();
            string query = String.Format("update products set Name='{0}', Qty={1}, Price={2}, Descs='{3}' where Id={4}", p.Name, p.Qty, p.Price, p.Descs, p.Id);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();

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