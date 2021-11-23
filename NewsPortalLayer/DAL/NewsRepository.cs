using BEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NewsRepository : IRepository<News, int>
    {
        NewsPortalDbEntities db;

        public NewsRepository(NewsPortalDbEntities db)
        {
            this.db = db;
        }

        public bool Add(News e)
        {
            db.News.Add(e);
            return (db.SaveChanges() > 0);
        }

        public bool Delete(int id)
        {
            var e = db.News.FirstOrDefault(en => en.id == id);
            db.News.Remove(e);
            return (db.SaveChanges() > 0);
        }

        public bool Edit(News e)
        {
            var p = db.News.FirstOrDefault(en => en.id == e.id);
            db.Entry(p).CurrentValues.SetValues(e);
            return (db.SaveChanges() > 0) ;
        }

        public List<News> Get()
        {
            return db.News.ToList();
        }

        public News Get(int id)
        {
            return db.News.FirstOrDefault(e => e.id == id);
        }
    }
}
