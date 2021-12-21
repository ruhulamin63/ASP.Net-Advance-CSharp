using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class ServiceProviderRepository : ManagerServiceProviderInterface<ServiceProvider, int>
    {
        ShebaDbEntities db;

        public ServiceProviderRepository(ShebaDbEntities db)
        {
            this.db = db;
        }

        public void Add(ServiceProvider e)
        {
            db.ServiceProviders.Add(e);
            db.SaveChanges();
        }

        public void Edit(ServiceProvider e)
        {
            var p = db.ServiceProviders.FirstOrDefault(en => en.id == e.id);
            db.Entry(p).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.ServiceProviders.FirstOrDefault(en => en.id == id);
            db.ServiceProviders.Remove(e);
            db.SaveChanges();
        }

        public List<ServiceProvider> Get()
        {
            return db.ServiceProviders.ToList();
        }

        public ServiceProvider Get(int id)
        {
            return db.ServiceProviders.FirstOrDefault(e => e.id == id);
        }

        //=================================================================

        public List<ServiceProvider> ConfirmBookedService(int id)
        {
            var sp = (from data in db.ServiceProviders
                      where data.work_status == "available"
                      select data).ToList();

            if (sp.Count > 0)
            {
                return sp;
            }
            else
            {
                return null;
            }

            //return db.ServiceProviders.ToList();
        }

      /*  public ServiceProvider AssignServices(int id)
        {
            //return db.ServiceProviders.FirstOrDefault(e => e.id == id);

            var cs = new ServiceProvider()
            {
                booking_id = bId,
                service = sp_id
            };
            db.ServiceProviders.Add(cs);
            db.SaveChanges();
        }*/

    }
}
