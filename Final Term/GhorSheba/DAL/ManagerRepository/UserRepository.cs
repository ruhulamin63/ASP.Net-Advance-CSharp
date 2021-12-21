using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UserRepository : ManagerInterface<User, int>
    {
        ShebaDbEntities db;

        public UserRepository(ShebaDbEntities db)
        {
            this.db = db;
        }

        public void Add(User e)
        {
            //User user = null;

            User user = new User()
            {
                fullname = e.fullname,
                email = e.email,
                password = e.password,
                usertype = e.usertype,
                verification_status = e.verification_status,
                id_status = e.id_status,
                created_at = DateTime.Now,
            };
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.Users.FirstOrDefault(en => en.id == id);
            db.Users.Remove(e);
            db.SaveChanges();
        }

        public void Edit(User e)
        {
            var p = db.Users.FirstOrDefault(en => en.id == e.id);
            db.Entry(p).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.FirstOrDefault(e => e.id == id);
        }

        /*public List<Booking> GetByCustomerId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetByOrderDate(DateTime order_date)
        {
            throw new NotImplementedException();
        }

        public List<Booking> GetByOrderDateCustomerId(DateTime order_date, int id)
        {
            throw new NotImplementedException();
        }*/

        public User AssignServices(int id)
        {
            throw new NotImplementedException();
        }
    }
}
