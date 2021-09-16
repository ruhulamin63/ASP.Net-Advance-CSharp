using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controllers
{
    public class ReservationController
    {
        public static Database db= new Database();

        public static List<Reservation> getAllReservations()
        {
            return db.Reservations.getAllReservations();
        }
        public static bool addCoachReservation(dynamic reservation)
        {
            return db.Reservations.addCoachReservation(reservation);
        }
        public static Reservation getSingleCoachReservation(dynamic reservation)
        {
            return db.Reservations.getSingleCoachReservation(reservation);
        }
        public static bool updateCoachReservation(dynamic reservation)
        {
            return db.Reservations.updateCoachReservation(reservation);
        }
        public static bool cancelReservation(dynamic reservation)
        {
            return db.Reservations.cancelReservation(reservation);
        }
    }
}
