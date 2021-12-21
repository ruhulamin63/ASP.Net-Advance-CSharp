using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReviewRepo : AdminIRepository<Review, int>
    {
        ShebaDbEntities db;
        public ReviewRepo(ShebaDbEntities db)
        {
            this.db = db;
        }
        public void Add(Review e)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var e = db.Reviews.FirstOrDefault(en => en.customer_id == id);
            db.Reviews.Remove(e);
            db.SaveChanges();
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
            throw new NotImplementedException();
        }
    }
}
