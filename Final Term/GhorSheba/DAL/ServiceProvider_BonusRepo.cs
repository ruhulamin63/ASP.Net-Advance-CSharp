using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ServiceProvider_BonusRepo : ServiceProviderIRepository<ServiceProvider_Bonus, int>
    {
        ShebaDbEntities db;
        public ServiceProvider_BonusRepo(ShebaDbEntities db)
        {
            this.db = db;
        }
        public void Add(ServiceProvider_Bonus e)
        {
            db.ServiceProvider_Bonus.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(ServiceProvider_Bonus e)
        {
            throw new NotImplementedException();
        }

        public List<ServiceProvider_Bonus> Get()
        {
            throw new NotImplementedException();
        }

        public ServiceProvider_Bonus Get(int id)
        {
            return db.ServiceProvider_Bonus.FirstOrDefault(e => e.id == id);
        }
    }
}
