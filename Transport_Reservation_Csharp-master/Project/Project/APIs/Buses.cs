using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Project.Models
{
    public class Buses
    {
        SqlConnection conn;
        public Buses(SqlConnection conn)
        {
            this.conn = conn;
        }

        public List<Bus> getAllBus()
        {
            conn.Open();
            string query = string.Format("SELECT * FROM Buses");
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Bus> buslist = new List<Bus>();
            Bus bus = null;
            while (reader.Read())
            {
                bus = new Bus();
                bus.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                bus.Coach = reader.GetString(reader.GetOrdinal("Coach")).Trim();
                bus.Type = reader.GetString(reader.GetOrdinal("BusType")).Trim();
                bus.Time = reader.GetString(reader.GetOrdinal("Time")).Trim();
                buslist.Add(bus);
            }
            conn.Close();
            return buslist;
        }
        public bool addBus(dynamic bus)
        {
            conn.Open();
            string query = string.Format("INSERT INTO Buses VALUES('{0}', '{1}', '{2}')", bus.type, bus.coach, bus.time);
            SqlCommand cmd = new SqlCommand(query, conn);
            int res = cmd.ExecuteNonQuery();
            conn.Close();
            if (res > 0) return true;
            return false;
        }
        public Bus SearchBus(string coach)
        {
            conn.Open();
            string query = string.Format("SELECT * FROM Buses WHERE Coach='{0}'", coach);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Bus bus = null;
            while (reader.Read())
            {
                bus = new Bus();
                bus.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                bus.Coach = reader.GetString(reader.GetOrdinal("Coach")).Trim();
                bus.Type = reader.GetString(reader.GetOrdinal("BusType")).Trim();
                bus.Time = reader.GetString(reader.GetOrdinal("Time"));
            }
            conn.Close();
            return bus;
        }
        public bool updateBus(dynamic bus)
        {
            conn.Open();
            string query = string.Format("UPDATE Buses SET Coach='{0}', BusType='{1}', Time='{2}' WHERE Id={3}", bus.coach, bus.type, bus.time, bus.id);
            SqlCommand cmd = new SqlCommand(query, conn);
            int res = cmd.ExecuteNonQuery();
            conn.Close();
            if (res > 0) return true;
            return false;
        }
        public bool deleteBus(int id)
        {
            conn.Open();
            string query = string.Format("DELETE FROM Buses WHERE Id={0}", id);
            SqlCommand cmd = new SqlCommand(query, conn);
            int res = cmd.ExecuteNonQuery();
            conn.Close();
            if (res > 0) return true;
            return false;
        }
    }
}
