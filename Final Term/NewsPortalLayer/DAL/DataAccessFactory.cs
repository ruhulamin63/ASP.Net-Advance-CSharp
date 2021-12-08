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
        static NewsPortalEntities db;

        static DataAccessFactory()
        {
            db = new NewsPortalEntities();
        }

        public static IRepository<News, int> NewsDataAccess()
        {
            return new NewsRepository(db);
        }

        public static IRepository<Category, int> NewsCategoryDataAccess()
        {
            return new NewsCategoryRepository(db);
        }

        public static IRepository<React, int> ReactDataAccess()
        {
            return new ReactRepository(db);
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
