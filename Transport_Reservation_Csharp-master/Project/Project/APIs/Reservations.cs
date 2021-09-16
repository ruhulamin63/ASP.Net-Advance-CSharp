using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Project.Models;

namespace Project.APIs
{
    public class Reservations
    {
        SqlConnection conn;
        public Reservations(SqlConnection conn)
        {
            this.conn = conn;
        }

        public List<Reservation> getAllReservations()
        {
            conn.Open();
            string query = string.Format("SELECT * FROM Reservation ORDER BY CONVERT(DATETIME, DATE) DESC");
            SqlCommand cmd = new SqlCommand(query, conn);
            List<Reservation> reservationList = new List<Reservation>();
            Reservation reservation = null;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                reservation = new Reservation();
                reservation.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                reservation.Coach = reader.GetString(reader.GetOrdinal("Coach")).Trim();
                reservation.Source = reader.GetString(reader.GetOrdinal("Source")).Trim();
                reservation.Destination = reader.GetString(reader.GetOrdinal("Destination")).Trim();
                reservation.Date = reader.GetString(reader.GetOrdinal("Date")).Trim();
                reservation.Time = reader.GetString(reader.GetOrdinal("Time")).Trim();
                reservation.Seats = reader.GetString(reader.GetOrdinal("Seats")).Trim();
                reservation.Booked = reader.GetInt32(reader.GetOrdinal("Booked"));
                reservation.Available = reader.GetInt32(reader.GetOrdinal("Available"));
                reservationList.Add(reservation);
            }
            conn.Close();
            return reservationList;
        }

        public bool addCoachReservation(dynamic reservation)
        {
            conn.Open();
            string query = string.Format("INSERT INTO Reservation VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", reservation.coach, reservation.source, reservation.destination, reservation.date, reservation.time, reservation.seats, reservation.booked, reservation.available);
            SqlCommand cmd = new SqlCommand(query, conn);
            int res = cmd.ExecuteNonQuery();
            conn.Close();
            if (res > 0) return true;
            return false;
        }

        public bool updateCoachReservation(dynamic reservation)
        {
            conn.Open();
            string query = string.Format("UPDATE Reservation SET Seats='{0}', Booked='{1}', Available='{2}' WHERE Coach='{3}' AND Source='{4}' AND Destination='{5}' AND Date='{6}' AND Time='{7}'", reservation.seats, reservation.booked, reservation.available, reservation.coach, reservation.source, reservation.destination, reservation.date, reservation.time);
            SqlCommand cmd = new SqlCommand(query, conn);
            int res = cmd.ExecuteNonQuery();
            conn.Close();
            if (res > 0) return true;
            return false;
        }

        public Reservation getSingleCoachReservation(dynamic reservation)
        {
            conn.Open();
            string query = string.Format("SELECT * FROM Reservation WHERE Coach='{0}' AND Source='{1}' AND Destination='{2}' AND Date='{3}' AND Time='{4}'", reservation.coach, reservation.source, reservation.destination, reservation.date, reservation.time);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Reservation reservationData = null;
            while (reader.Read())
            {
                reservationData = new Reservation();
                reservationData.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                reservationData.Coach = reader.GetString(reader.GetOrdinal("Coach")).Trim();
                reservationData.Source = reader.GetString(reader.GetOrdinal("Source")).Trim();
                reservationData.Destination = reader.GetString(reader.GetOrdinal("Destination")).Trim();
                reservationData.Date = reader.GetString(reader.GetOrdinal("Date")).Trim();
                reservationData.Time = reader.GetString(reader.GetOrdinal("Time")).Trim();
                reservationData.Seats = reader.GetString(reader.GetOrdinal("Seats")).Trim();
                reservationData.Booked = reader.GetInt32(reader.GetOrdinal("Booked"));
                reservationData.Available = reader.GetInt32(reader.GetOrdinal("Available"));
            }
            conn.Close();
            return reservationData;
        }
        public bool cancelReservation(dynamic reservation)
        {
            conn.Open();
            string query = string.Format("DELETE FROM Reservation WHERE Coach='{0}' AND Source='{1}' AND Destination='{2}' AND Date='{3}' AND Time='{4}'", reservation.coach, reservation.source, reservation.destination, reservation.date, reservation.time);
            SqlCommand cmd = new SqlCommand(query, conn);
            int res = cmd.ExecuteNonQuery();
            conn.Close();
            if (res > 0) return true;
            return false;
        }
    }
}
