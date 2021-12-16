using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ManagerRepository
{
    public class SalaryRepository : Salary_Interface<Salary, int>
    {
        ShebaDbEntities db;

        public SalaryRepository(ShebaDbEntities db)
        {
            this.db = db;
        }

        public void Add(Salary e, int id)
        {
            var data = db.Salaries.FirstOrDefault(en => en.user_id == id);

            Salary t = null;

            //var u = db.Users.FirstOrDefault(e => e.Username == user.Username && e.Password == user.Password);

            if (t == null)
            {
                t = new Salary()
                {
                    user_id = id,
                    salary_amount = 5000,
                    message = "non-changeable",
                    created_at = DateTime.Now
                };
                db.Salaries.Add(t);
            }
            
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.Salaries.FirstOrDefault(en => en.id == id);
            db.Salaries.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Salary e)
        {
            var p = db.Salaries.FirstOrDefault(en => en.id == e.id);
            db.Entry(p).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Salary> Get()
        {
            return db.Salaries.ToList();
        }

        public Salary Get(int id)
        {
            return db.Salaries.FirstOrDefault(e => e.id == id);
        }

        public List<Booking> GetByCustomerId(int id)
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
        }
    }
}
