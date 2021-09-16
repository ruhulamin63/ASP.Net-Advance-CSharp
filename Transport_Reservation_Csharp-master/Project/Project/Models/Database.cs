using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Project.APIs;

namespace Project.Models
{
    public class Database
    {
        public Authentication Authentication { get; set; }
        public Managers Managers { get; set; }
        public Sellers Sellers { get; set; }
        public Tickets Tickets { get; set; }
        public Customers Customers { get; set; }
        public Buses Buses { get; set; }
        public Admins Admins { get; set; }
        public Reservations Reservations { get; set; }
        public Database()
        {
            string connectionString = @"Server=LAPTOP-LSE8ACET\SQL_SERVER;Database=TransportReservation;User Id=sa;Password=12345;";
            SqlConnection conn = new SqlConnection(connectionString);

            Authentication = new Authentication(conn);
            Managers = new Managers(conn);
            Sellers = new Sellers(conn);
            Tickets = new Tickets(conn);
            Customers = new Customers(conn);
            Buses = new Buses(conn);
            Admins = new Admins(conn);
            Reservations = new Reservations(conn);
        }
    }
}
