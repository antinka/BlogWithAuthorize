using BlogUsingEF.DAL.Entities;
using BlogUsingEF.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogUsingEF.DAL.Repositories
{
    public class AnketRepository : IRepository<Anket>
    {
        private BlogContext db;

        public AnketRepository(BlogContext context)
        {
            this.db = context;
        }
        public void Create(Anket item)
        {
            db.Ankets.Add(item);
        }

        public void Delete(int id)
        {
            Anket anket = db.Ankets.Find(id);
            if (anket != null)
                db.Ankets.Remove(anket);
        }

        public Anket GetById(int id)
        {
            return db.Ankets.Find(id);
        }

        public IEnumerable<Anket> GetList()
        {
            return db.Ankets;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Anket item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}