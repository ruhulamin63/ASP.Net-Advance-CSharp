using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SubscriberRepository : IRepository<Subscriber, int>
    {
        NewsPortalDbEntities db;

        public SubscriberRepository(NewsPortalDbEntities db)
        {
            this.db = db;
        }

        public void Add(Subscriber e)
        {
            db.Subscribers.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.Subscribers.FirstOrDefault(en => en.id == id);
            db.Subscribers.Remove(e);
            db.SaveChanges();
        }

        public void Edit(Subscriber e)
        {
            var p = db.Subscribers.FirstOrDefault(en => en.id == e.id);
            db.Entry(p).CurrentValues.SetValues(e);
            db.SaveChanges();
        }

        public List<Subscriber> Get()
        {
            return db.Subscribers.ToList();
        }

        public Subscriber Get(int id)
        {
            return db.Subscribers.FirstOrDefault(e => e.id == id);
        }
    }
}
