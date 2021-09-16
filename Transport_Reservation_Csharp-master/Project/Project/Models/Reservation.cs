using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string Coach { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Seats { get; set; }
        public int Booked { get; set; }
        public int Available { get; set; }
    }
}
