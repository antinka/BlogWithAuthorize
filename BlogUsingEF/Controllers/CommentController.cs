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

namespace BlogUsingEF.Controllers
{
    public class CommentController : Controller
    {
        // For working with db.
        IArticleServiceAddGetArticleComment articleService;
        ICommentServices commentServices;
        public CommentController(IArticleServiceAddGetArticleComment articleService, ICommentServices commentServices)
        {
            this.articleService = articleService;
            this.commentServices = commentServices;
        }

        // Show all comment to current article.
        public ActionResult ViewComment(int id)
        {
            ArticleDTO articleDTO = articleService.GetArticlesById(id);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CommentView, CommentDTO>());
            IMapper mapper = config.CreateMapper();
            ViewBag.NameArticle = articleDTO.Title;
            return View(mapper.Map<IEnumerable<CommentDTO>, List<CommentView>>(commentServices.GetComments()).Where(u => u.ArticleId == id));
        }

        //Add comment to choosen article.
        [HttpGet]
        public ActionResult AddComment(int id)
        {
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddComment(CommentView coment, int IdArticle)
        {
            string userid = User.Identity.GetUserId();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CommentView, CommentDTO>());
            IMapper mapper = config.CreateMapper();
            CommentDTO commentDTO = mapper.Map<CommentView, CommentDTO>(coment);
            commentServices.AddNewComment(commentDTO, IdArticle, userid);
            return RedirectToAction("Index");

        }
    }
}