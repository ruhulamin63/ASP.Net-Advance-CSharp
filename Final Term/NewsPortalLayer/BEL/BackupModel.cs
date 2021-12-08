using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class BackupModel
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string date { get; set; }
        public string backup_file { get; set; }
    }
}
