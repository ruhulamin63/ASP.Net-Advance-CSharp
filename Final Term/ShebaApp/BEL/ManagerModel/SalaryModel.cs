using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL.ManagerModel
{
    public class SalaryModel
    {
        public int id { get; set; }
        public int salary_amount { get; set; }
        public string message { get; set; }
        public int user_id { get; set; }
    }
}
