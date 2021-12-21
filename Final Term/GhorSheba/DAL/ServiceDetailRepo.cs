using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ServiceDetailRepo : ServiceProviderIRepository<Service, int>
    {
        ShebaDbEntities db;
        public ServiceDetailRepo(ShebaDbEntities db)
        {
            this.db = db;
        }
        public void Add(Service e)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Service e)
        {
            throw new NotImplementedException();
        }

        public List<Service> Get()
        {
            return db.Services.ToList();
        }

        public Service Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
