using BlogUsingEF.DAL.Entities;
using BlogUsingEF.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;

namespace BlogUsingEF.DAL.Repositories
{
    //Implementation IRepository which typed Tag.
    class TagRepository : IRepository<Tag>
    {
        private BlogContext db;

        public TagRepository(BlogContext context)
        {
            this.db = context;
        }
        public void Create(Tag item)
        {
            db.Tags.Add(item);
        }

        public void Delete(int id)
        {
            Tag tag = db.Tags.Find(id);
            if (tag != null)
                db.Tags.Remove(tag);
        }

        public Tag GetById(int id)
        {
            return db.Tags.Find(id);
        }

        public IEnumerable<Tag> GetList()
        {
            return db.Tags;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Tag item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}

