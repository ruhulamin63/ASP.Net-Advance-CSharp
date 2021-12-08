using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class CommentModel
    {
        public int id { get; set; }
        public int news_id { get; set; }
        public string comment1 { get; set; }
        public int user_id { get; set; }
    }
}
