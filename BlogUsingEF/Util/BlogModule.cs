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
            Bind<IArticleServiceAddGetArticleComment>().To<ArticleService>();
            Bind<IAnketService>().To<AnketServices>();
            Bind<IGuestbookServices>().To<GuestbookServices>();
            Bind<ICommentServices>().To<CommentServices>();
            Bind<ITagServices>().To<TagServices>();
        }
    }
}