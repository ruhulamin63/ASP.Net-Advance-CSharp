using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class SalariesModel
    {
        public int id { get; set; }
        public int salary_amount { get; set; }
        public string message { get; set; }
        public int user_id { get; set; }
        public System.DateTime created_at { get; set; }
        public System.DateTime updated_at { get; set; }
    }
}
