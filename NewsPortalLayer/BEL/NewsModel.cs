using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class NewsModel
    {
        public int id { get; set; }
        public int category_id { get; set; }
        public string news_title { get; set; }
        public string date_posted { get; set; }
        public string date_updated { get; set; }
        public string comment_status { get; set; }
        public int author_id { get; set; }
        public string status { get; set; }

        public virtual UserModel User { get; set; }
        public virtual List<CommentModel> Comments { get; set; }
        public virtual List<SubscriberModel> Subscriber { get; set; }
    }
}
