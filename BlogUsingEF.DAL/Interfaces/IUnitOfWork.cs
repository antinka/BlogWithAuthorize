using BlogUsingEF.DAL.Entities;
using BlogUsingEF.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogUsingEF.DAL.Interfaces
{
    //For simple using db.
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Article> Articles { get; }
        IRepository<Comment> Comments { get; }
        IRepository<Tag> Tags { get; }
        IRepository<Guestbook> Guestbooks { get; }
        IRepository<Anket> Ankets { get; }
        ApplicationUserManager ApplicationUserManager { get; }
        ApplicationRoleManager ApplicationRoleManager { get; }
     
        Task SaveAsync();
    }
}
