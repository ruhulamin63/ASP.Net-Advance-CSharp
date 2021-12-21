using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ServiceProviderBonus : AdminIRepository<ServiceProvider_Bonus, int>
    {
        ShebaDbEntities db;
        public ServiceProviderBonus(ShebaDbEntities db)
        {
            this.db = db;
        }

        public void Add(ServiceProvider_Bonus e)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var e = db.ServiceProvider_Bonus.FirstOrDefault(en => en.service_provider_id == id);
            db.ServiceProvider_Bonus.Remove(e);
            db.SaveChanges();
        }

        public void Edit(ServiceProvider_Bonus e)
        {
            throw new NotImplementedException();
        }

        public List<ServiceProvider_Bonus> Get()
        {
            return db.ServiceProvider_Bonus.ToList();
        }

        public ServiceProvider_Bonus Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
