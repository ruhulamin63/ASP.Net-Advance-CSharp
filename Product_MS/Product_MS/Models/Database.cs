using Product_MS.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Product_MS.Models
{
    public class Database
    {
        SqlConnection conn;
        public Products Products { get; set; }
        public Products Orders { get; set; }
        public Users Users { get; set; }

        public Database()
        {
            string connString = @"Server=DESKTOP-JOQNJEJ\SQLEXPRESS; Database=Product; Password=needhelp; Integrated Security=true";
            conn = new SqlConnection(connString);
            Products = new Products(conn);
            Users = new Users(conn);
            //Students = new Students(conn);
            //Departments = new Departments(conn);

        }
    }
}