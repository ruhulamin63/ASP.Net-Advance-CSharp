using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class TokenModel
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string access_token { get; set; }
        public Nullable<System.DateTime> CreatedAt { get; set; }
        public Nullable<System.DateTime> ExpiredAt { get; set; }
    }
}
