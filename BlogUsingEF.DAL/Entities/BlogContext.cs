using BlogUsingEF.DAL.Entities;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlogUsingEF.DAL.Entities
{
    public class BlogContext : IdentityDbContext<ApplicationUser>
    {
        public BlogContext(string connectionString)
            : base(connectionString)
        {
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Guestbook> Guestbooks { get; set; }
        public DbSet<Anket> Ankets { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
        public class BlogDbInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
        {
        }

}
