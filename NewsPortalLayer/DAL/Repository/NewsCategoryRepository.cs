using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NewsCategoryRepository : IRepository<Category, int>
    {
        NewsPortalEntities db;

        public NewsCategoryRepository(NewsPortalEntities db)
        {
            this.db = db;
        }

        public bool Add(Category e)
        {
            db.Categories.Add(e);
            return (db.SaveChanges() > 0);
        }

        public bool Delete(int id)
        {
            var c = db.Categories.FirstOrDefault(e => e.id == id);
            db.Categories.Remove(c);
            return (db.SaveChanges() > 0);
        }

        public bool Edit(Category e)
        {
            var c = db.Categories.FirstOrDefault(en => en.id == e.id);
            db.Entry(c).CurrentValues.SetValues(e);
            return (db.SaveChanges() > 0) ;
        }

        public List<Category> Get()
        {
            return db.Categories.ToList();
        }

        public Category Get(int id)
        {
            return db.Categories.FirstOrDefault(e => e.id == id);
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
