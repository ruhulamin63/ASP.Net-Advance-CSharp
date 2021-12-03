using Product_MS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lecture_3.Models.Tables
{
    public class Orders
    {
        SqlConnection conn;
        public Orders(SqlConnection conn)
        {
            this.conn = conn;
        }
        public List<Order> Get()
        {
            conn.Open();
            string query = "select * from atp_lab_task.Products, atp_lab_task.Orders where atp_lab_task.Products.Id=atp_lab_task.Orders.ProductId";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Order> orders = new List<Order>();
            Product p;
            Order s;
            while (reader.Read())
            {
                s = new Order();
                s.Products = new List<Product>();
                p = new Product()
                {
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                   /* Price = (float)reader.GetDouble(reader.GetOrdinal("Amount"))*/
                };
              /*  s.OrderId = reader.GetString(reader.GetOrdinal("OrderId"));*/
                s.Products.Add(p);
                orders.Add(s);
            }
            conn.Close();
            return orders;
        }
        public int Place(string orderId, int productId, float amount)
        {
            conn.Open();
            string query = String.Format("insert into Orders values ('{0}',{1},{2})", orderId, productId, amount);
            SqlCommand cmd = new SqlCommand(query, conn);
            int r = cmd.ExecuteNonQuery();
            conn.Close();
            return r;
        }
    }
}