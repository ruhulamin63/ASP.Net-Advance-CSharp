using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Add_To_Card_for_Product_Application.Models
{
    public class Database
    {
        SqlConnection conn;
        public Products Products { get; set; }

        public Database()
        {
            string connString = @"Server=DESKTOP-JOQNJEJ\SQLEXPRESS; Database=Order; Password=needhelp; Integrated Security=true";
            conn = new SqlConnection(connString);
            Products = new Products(conn);
            //Students = new Students(conn);
            //Departments = new Departments(conn);

        }
    }
}