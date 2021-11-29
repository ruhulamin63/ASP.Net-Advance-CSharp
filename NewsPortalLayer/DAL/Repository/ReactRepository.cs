using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReactRepository : IRepository<React, int>
    {
        NewsPortalEntities db;

        public ReactRepository(NewsPortalEntities db)
        {
            this.db = db;
        }

        public bool Add(React e)
        {
            db.Reacts.Add(e);
            return (db.SaveChanges() > 0) ;
        }

        public bool Delete(int id)
        {
            var e = db.Reacts.FirstOrDefault(en => en.id == id);
            db.Reacts.Remove(e);
            return (db.SaveChanges() > 0) ;
        }

        public bool Edit(React e)
        {
            var p = db.Reacts.FirstOrDefault(en => en.id == e.id);
            db.Entry(p).CurrentValues.SetValues(e);
            return (db.SaveChanges() > 0) ;
        }

        public List<React> Get()
        {
            return db.Reacts.ToList();
        }

        public React Get(int id)
        {
            return db.Reacts.FirstOrDefault(e => e.id == id);
        }

        public List<News> GetByCategory(int id)
        {
            throw new NotImplementedException();
        }

        public List<News> GetByDate(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public List<News> GetByDateCategory(DateTime dateTime, string category)
        {
            throw new NotImplementedException();
        }
    }
}
