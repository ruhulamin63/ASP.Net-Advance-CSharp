using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Controllers
{
    class TicketsController
    {
        public static Database db = new Database();
        public static bool boolTicket(dynamic ticket)
        {
            if (ticket.name.Length == 0 || ticket.phone.Length == 0 || ticket.source.Equals("Source") || ticket.destination.Equals("To") ||
                ticket.coach.Equals("Coach") || ticket.type.Length == 0 || ticket.time.Equals("Time") || ticket.author.Length==0 || ticket.seat.Length==0)
            { 
                MessageBox.Show("Fill all the required fields", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //Customer Adding
            var hasCus = CustomerController.searchCustomer(ticket.phone);
            if (hasCus == null) { bool customeradd = CustomerController.addCustomer(ticket); }

            //Coach Reservation
            var reservation = new
            {
                ticket.coach,
                ticket.source,
                ticket.destination,
                ticket.date,
                ticket.time,
                seats = ticket.booked,
                booked = ticket.booked.Split(',').Length,
                available = 40 - ticket.booked.Split(',').Length
            };
            //if (ticket.booked.Length == 0) { bool reserve = ReservationController.cancelReservation(reservation); }
            var hasCoach = ReservationController.getSingleCoachReservation(reservation);
            if (hasCoach == null) { bool reserve = ReservationController.addCoachReservation(reservation); }
            else { bool reserve = ReservationController.updateCoachReservation(reservation); }

            return db.Tickets.bookTicket(ticket);
        }
        public static List<Ticket> getAllTickets()
        {
            return db.Tickets.getAllTickets();
        }
        public static bool cancelTicket(int ticketId)
        {
            if (ticketId == 0)
            {
                MessageBox.Show("Select a ticket first", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            var ticket = searchTicketById(ticketId);
            var reservation = new
            {
                coach = ticket.Coach,
                source = ticket.Source,
                destination = ticket.Destination,
                date = ticket.Date,
                time = ticket.Time,
                seats = ticket.Seat,
                //booked = ticket.Booked.Split(',').Length,
                //available = 40 - ticket.Booked.Split(',').Length
            };
            var hasCoach = ReservationController.getSingleCoachReservation(reservation);
            char[] separator = { ',' };
            string[] bookedSeats = hasCoach.Seats.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            string[] cancelSeats = ticket.Seat.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            List<string> newSeats = new List<string>();
            foreach(var s in bookedSeats)
            {
                newSeats.Add(s.Trim());
            }
            foreach(var bs in bookedSeats)
            {
                foreach(var cs in cancelSeats)
                {
                    if (bs.Trim().Equals(cs.Trim()))
                    {
                        newSeats.Remove(cs.Trim());
                    }
                }
            }
            string seats = string.Join(", ", newSeats);
            var newReservation = new
            {
                coach = hasCoach.Coach.Trim(),
                source = hasCoach.Source.Trim(),
                destination = hasCoach.Destination.Trim(),
                date = hasCoach.Date.Trim(),
                time = hasCoach.Time.Trim(),
                seats = seats.Trim(),
                booked = newSeats.Count,
                available = 40 - newSeats.Count
            };
             
            if (newReservation.booked == 0) { bool res = ReservationController.cancelReservation(reservation); }
            else
            {
                if (hasCoach == null) { bool reserve = ReservationController.addCoachReservation(newReservation); }
                else { bool reserve = ReservationController.updateCoachReservation(newReservation); }
            }

            return db.Tickets.cancelTicket(ticketId);
        }

        public static Ticket searchTicketById(int id)
        {
            return db.Tickets.searchTicketById(id);
        }
        public static bool updateTicket(dynamic ticket)
        {
            if (ticket.id == 0)
            {
                MessageBox.Show("Select a ticket first", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (ticket.name.Length == 0 || ticket.phone.Length == 0 || ticket.source.Equals("Source") || ticket.destination.Equals("To") ||
                ticket.coach.Equals("Coach") || ticket.type.Length == 0 || ticket.time.Equals("Time") || ticket.author.Length == 0 || ticket.seat.Length == 0)
            {
                MessageBox.Show("Fill all the required fields", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //Coach Update
            var reservation = new
            {
                ticket.coach,
                ticket.source,
                ticket.destination,
                ticket.date,
                ticket.time,
                seats = ticket.booked,
                booked = ticket.booked.Split(',').Length,
                available = 40 - ticket.booked.Split(',').Length
            };
            var hasCoach = ReservationController.getSingleCoachReservation(reservation);
            if (hasCoach == null) { bool reserve = ReservationController.addCoachReservation(reservation); }
            else { bool reserve = ReservationController.updateCoachReservation(reservation); }

            return db.Tickets.updateTicket(ticket);
        }
    }
}
