using AutoMapper;
using BlogUsingEF.BLL.DTO;
using BlogUsingEF.BLL.Interfaces;
using BlogUsingEF.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogUsingEF.Areas.ControlPanel.Controllers
{
    public class ArticleController : Controller
    {// For working with db.
        IArticleServiceAddGetArticleComment articleService;
        ITagServices tagServices;
        public ArticleController(IArticleServiceAddGetArticleComment articleService, ITagServices tagServices)
        {
            this.articleService = articleService;
            this.tagServices = tagServices;
        }
         // GET: admin/Admin
         //Show all article.
         public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ArticleView, ArticleDTO>());
            IMapper mapper = config.CreateMapper();
            return View(mapper.Map<IEnumerable<ArticleDTO>, List<ArticleView>>(articleService.GetArticles()));
        }
        //Add neew article.
        [HttpGet]
        public ActionResult AddArticle()
        {
            return View();
        }

         [HttpPost]
         public ActionResult AddArticle(ArticleView article)
         {
             ArticleView art = new ArticleView();
             art.Text = article.Text;
             art.Title = article.Title;
            art.Tags = "#";
             string userid = User.Identity.GetUserId();
             var config = new MapperConfiguration(cfg => cfg.CreateMap<ArticleView, ArticleDTO>());
             IMapper mapper = config.CreateMapper();
             ArticleDTO articleDTO = mapper.Map<ArticleView, ArticleDTO>(art);
             articleService.AddNewArticle(articleDTO, userid);
             return RedirectToAction("Index");
         } 
        // Delete the article and all comment which it has.
        public ActionResult DeleteArticle(int id)
        {
            articleService.DeleteArticle(id);
            return RedirectToAction("Index");
        }
        //Add string of choosen tags to current article.
        [HttpGet]
        public ActionResult AddTagToArticle(int id)
        {
            SelectList tags = new SelectList(tagServices.GetTags(), "Text", "Text");
            ViewBag.tags = tags;
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddTagToArticle(int idArticle, string[] Text)
        {
            string tags = string.Empty;
            foreach (string c in Text)
            {
                tags += "#";
                tags += c;
            }
            articleService.AddTagsToArticle(idArticle, tags);
            return RedirectToAction("Index");
        }
        //Return  article which has this tag.
        public ActionResult SearchForTag(string tag)
        {
            
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ArticleView, ArticleDTO>());
            IMapper mapper = config.CreateMapper();
            List<ArticleDTO> listArticle = new List<ArticleDTO>();
            foreach (var article in articleService.GetArticles())
            {
                if (article.Tags != "" && article.Tags != null)
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