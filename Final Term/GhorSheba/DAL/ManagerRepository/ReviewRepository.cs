using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ManagerRepository
{
    public class ReviewRepository : ManagerInterface<Review, int>
    {
        ShebaDbEntities db;

        public ReviewRepository(ShebaDbEntities db)
        {
            this.db = db;
        }

        public void Add(Review e)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Review e)
        {
            throw new NotImplementedException();
        }

        public List<Review> Get()
        {
            return db.Reviews.ToList();
        }

        public Review Get(int id)
        {
            return db.Reviews.FirstOrDefault(e => e.id == id);
        }

       /* public List<Booking> GetByCustomerId(int id)
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
        public Review AssignServices(int id)
        {
            throw new NotImplementedException();
        }
    }
}
