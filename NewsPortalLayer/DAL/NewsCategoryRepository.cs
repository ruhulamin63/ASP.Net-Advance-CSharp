using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NewsCategoryRepository : IRepository<News_category, int>
    {
        NewsPortalDbEntities db;

        public NewsCategoryRepository(NewsPortalDbEntities db)
        {
            this.db = db;
        }

        public bool Add(News_category e)
        {
            db.News_category.Add(e);
            return (db.SaveChanges() > 0);
        }

        public bool Delete(int id)
        {
            var c = db.News_category.FirstOrDefault(e => e.id == id);
            db.News_category.Remove(c);
            return (db.SaveChanges() > 0);
        }

        public bool Edit(News_category e)
        {
            var c = db.News_category.FirstOrDefault(en => en.id == e.id);
            db.Entry(c).CurrentValues.SetValues(e);
            return (db.SaveChanges() > 0) ;
        }

        public List<News_category> Get()
        {
            return db.News_category.ToList();
        }

        public News_category Get(int id)
        {
            return db.News_category.FirstOrDefault(e => e.id == id);
        }
    }
}
