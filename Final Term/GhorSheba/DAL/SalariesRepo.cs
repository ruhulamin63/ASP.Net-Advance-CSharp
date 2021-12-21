using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SalariesRepo : AdminIRepository<Salary, int>
    {
        ShebaDbEntities db;
        public SalariesRepo(ShebaDbEntities db)
        {
            this.db = db;
        }
        public void Add(Salary e)
        {
            db.Salaries.Add(e);
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
            var p = db.Salaries.FirstOrDefault(en => en.user_id == e.user_id);
            db.Entry(p).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Salary> Get()
        {
            return db.Salaries.ToList();
        }

        public Salary Get(int id)
        {
            return db.Salaries.FirstOrDefault(e => e.user_id == id);
        }
    }
}
