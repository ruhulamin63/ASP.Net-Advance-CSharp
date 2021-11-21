using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        static NewsPortalDbEntities db;

        static DataAccessFactory()
        {
            db = new NewsPortalDbEntities();
        }

        public static IRepository<News, int> ProductDataAccess()
        {
            return new NewsRepository(db);
        }

        public static IRepository<News_category, int> NewsCategoryDataAccess()
        {
            return new NewsCategoryRepository(db);
        }

        public static IRepository<Subscriber, int> SubscriberDataAccess()
        {
            return new SubscriberRepository(db);
        }
    }
}
