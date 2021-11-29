using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class ReactModel
    {
        public int id { get; set; }
        public int news_id { get; set; }
        public string reacts { get; set; }
        public int user_id { get; set; }
    }
}
