using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Coach { get; set; }
        public string Seat { get; set; }
        public string Bustype { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Phone { get; set; }
        public string Author { get; set; }
    }
}
