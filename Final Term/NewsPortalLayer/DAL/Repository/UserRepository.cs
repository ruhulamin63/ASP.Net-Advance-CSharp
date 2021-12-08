using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UserRepository : IRepository<User, int>
    {
        NewsPortalEntities db;

        public UserRepository(NewsPortalEntities db)
        {
            this.db = db;
        }

        public bool Add(User e)
        {
            db.Users.Add(e);
            return (db.SaveChanges() > 0);
        }

        public bool Delete(int id)
        {
            var e = db.Users.FirstOrDefault(en => en.id == id);
            db.Users.Remove(e);
            return (db.SaveChanges() > 0);
        }

        public bool Edit(User e)
        {
            var p = db.Users.FirstOrDefault(en => en.id == e.id);
            db.Entry(p).CurrentValues.SetValues(e);
            return (db.SaveChanges() > 0);
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.FirstOrDefault(e => e.id == id);
        }

        public List<News> GetByCategory(int id)
        {
            throw new NotImplementedException();
        }

        public List<News> GetByDate(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public List<News> GetByDateCategory(DateTime dateTime, string category)
        {
            throw new NotImplementedException();
        }
    }
}
