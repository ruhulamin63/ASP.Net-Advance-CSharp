using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class EditServiceProviderModel
    {
        public int id { get; set; }
        public int user_id { get; set; }
        [Required]
        public string fullname { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string work_status { get; set; }
        [Required]
        public string id_status { get; set; }
    }
}
