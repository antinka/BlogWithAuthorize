using BlogUsingEF.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BlogUsingEF.Models;
using BlogUsingEF.BLL.DTO;
using Microsoft.AspNet.Identity;

namespace BlogUsingEF.Controllers
{
    public class HomeController : Controller
    {
        // For working with db.
        IArticleServiceAddGetArticleComment articleService;
        ICommentServices commentServices;
        public HomeController(IArticleServiceAddGetArticleComment articleService, ICommentServices commentServices)
        {
            this.articleService = articleService;
            this.commentServices = commentServices;
        }

        //Return all article 200symbols.
        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ArticleView, ArticleDTO>());
            IMapper mapper = config.CreateMapper();
            return View(mapper.Map<IEnumerable<ArticleDTO>, List<ArticleView>>(articleService.GetArticles()));
        }

        //Voting on index page in left bar.
        public ActionResult Vote(string resultVoting)
        {
            return PartialView();
        }

        //Delete choosen article.
         public ActionResult DetailsArticle(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ArticleView, ArticleDTO>());
            IMapper mapper = config.CreateMapper();
            return View(mapper.Map<IEnumerable<ArticleDTO>, List<ArticleView>>(articleService.GetArticles()).Where(art=>art.Id==id));
        }

        //Return  article which has choosen tag.
        public ActionResult SearchForTag(string tag)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ArticleView, ArticleDTO>());
            IMapper mapper = config.CreateMapper();
            List<ArticleDTO> listArticle = new List<ArticleDTO>();
            foreach (var article in articleService.GetArticles())
            {
                if (article.Tags!=""&& article.Tags !=null )
                {
                    string[] tags = article.Tags.Split('#');
                    foreach (string takeTag in tags)
                    {
                        if (takeTag.Trim() != "")
                        {
                            if (takeTag == tag)
                            {
                                listArticle.Add(articleService.GetArticlesById(article.Id));
                                break;
                            }
                        }
                    }
                }
            }
            return View("Index", mapper.Map<IEnumerable<ArticleDTO>, List<ArticleView>>(listArticle));
        }
    }
}