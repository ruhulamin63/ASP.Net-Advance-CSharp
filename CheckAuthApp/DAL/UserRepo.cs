using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRepo : IRepository<User, int>
    {
        BlogsEntities db;
        public UserRepo(BlogsEntities db)
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
            db.Users.Remove(db.Users.FirstOrDefault(e => e.Id == id));
            return (db.SaveChanges() > 0);
        }

        public bool Edit(User e)
        {
            var u = db.Users.FirstOrDefault(en => en.Id == e.Id);
            db.Entry(u).CurrentValues.SetValues(e);
            return (db.SaveChanges() > 0);
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.FirstOrDefault(e => e.Id == id);
        }
    }
}
