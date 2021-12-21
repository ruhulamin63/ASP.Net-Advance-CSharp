using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SerReviewRepo : ServiceProviderIRepository<Review, int>
    {
        ShebaDbEntities db;
        public SerReviewRepo(ShebaDbEntities db)
        {
            this.db = db;
        }
        public void Add(Review e)
        {
            db.Reviews.Add(e);
            db.SaveChanges();
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
    }
}
