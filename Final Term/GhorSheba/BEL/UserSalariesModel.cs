using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class UserSalariesModel
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public int salary_amount { get; set; }
        public string message { get; set; }
        public int user_id { get; set; }

        public System.DateTime last_paid { get; set; }
        public int Due { get; set; }
    }
}
