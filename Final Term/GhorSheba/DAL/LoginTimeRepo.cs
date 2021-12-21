using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoginTimeRepo : AdminIRepository<Login_Time, int>
    {
        ShebaDbEntities db;
        public LoginTimeRepo(ShebaDbEntities db)
        {
            this.db = db;
        }
        public void Add(Login_Time e)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var e = db.Login_Time.FirstOrDefault(en => en.user_id == id);
            db.Login_Time.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Login_Time e)
        {
            throw new NotImplementedException();
        }

        public List<Login_Time> Get()
        {
            return db.Login_Time.ToList();
        }

        public Login_Time Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
