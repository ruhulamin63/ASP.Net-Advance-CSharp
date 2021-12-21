using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SerBonusRepo : ServiceProviderIRepository<Bonu, int>
    {
        ShebaDbEntities db;
        public SerBonusRepo(ShebaDbEntities db)
        {
            this.db = db;
        }
        public void Add(Bonu e)
        {
            db.Bonus.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Bonu e)
        {
            throw new NotImplementedException();
        }

        public List<Bonu> Get()
        {
            throw new NotImplementedException();
        }

        public Bonu Get(int id)
        {
            return db.Bonus.FirstOrDefault(e => e.id == id);
        }
    }
}
