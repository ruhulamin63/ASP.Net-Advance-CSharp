using DAL.Repository;
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

        public static IRepository<News, int> NewsDataAccess()
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

        public static IRepository<User, int> UserDataAccess()
        {
            return new UserRepository(db);
        }

        public static IRepository<Comment, int> CommentDataAccess()
        {
            return new CommentRepository(db);
        }
    }
}
