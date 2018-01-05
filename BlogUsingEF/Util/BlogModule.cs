using BlogUsingEF.BLL.Interfaces;
using BlogUsingEF.BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogUsingEF.Util
{
    public class BlogModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserServicesAddEnter>().To<UserService>();
            Bind<IArticleServiceAddGetArticleComment>().To<ArticleService>();
            Bind<IAnketServices>().To<AnketServices>();
            Bind<IGuestbookServices>().To<GuestbookServices>();
        }
    }
}