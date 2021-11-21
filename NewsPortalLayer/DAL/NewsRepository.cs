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

        public void Add(News e)
        {
            db.News.Add(e);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var e = db.News.FirstOrDefault(en => en.id == id);
            db.News.Remove(e);
            db.SaveChanges();
        }

        public void Edit(News e)
        {
            var p = db.News.FirstOrDefault(en => en.id == e.id);
            db.Entry(p).CurrentValues.SetValues(e);
            db.SaveChanges();
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
