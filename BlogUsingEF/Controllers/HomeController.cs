using BlogUsingEF.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BlogUsingEF.Models;
using BlogUsingEF.BLL.DTO;

namespace BlogUsingEF.Controllers
{
    public class HomeController : Controller
    {
        // for working with db
        IArticleServiceAddGetArticleComment articleService;
        IAnketServices anketServices;
        IGuestbookServices guestbookServices;
        IUserServicesAddEnter userService;
        public HomeController(IArticleServiceAddGetArticleComment articleService, IAnketServices anketServices, IGuestbookServices guestbookServices, IUserServicesAddEnter userService)
        {
            this.articleService = articleService;
            this.anketServices = anketServices;
            this.guestbookServices = guestbookServices;
            this.userService = userService;
        }

        public ActionResult Index()
        {
            //return all article 200symbols 
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ArticleView, ArticleDTO >());
            IMapper mapper = config.CreateMapper();
            return View(mapper.Map<IEnumerable<ArticleDTO>, List<ArticleView>>(articleService.GetArticles()));
        }
        public ActionResult Vote(string resultVoting)
        {
            //Voting on index page in left bar
            return PartialView();
        }
      public ActionResult detailsArticle(int id)
        {
            //return all article  + add comment to it and view they
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ArticleView, ArticleDTO>());
            IMapper mapper = config.CreateMapper();
            return View(mapper.Map<IEnumerable<ArticleDTO>, List<ArticleView>>(articleService.GetArticles()).Where(art=>art.Id==id));
        }
        public ActionResult SearchForTag(string tag)
        {
            //return  article which has this tag
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ArticleView, ArticleDTO>());
            IMapper mapper = config.CreateMapper();

            List<ArticleDTO> listArticle=new List<ArticleDTO>();
            foreach (var article in articleService.GetArticles())
            {
                    string[] tags = article.Tags.Split('#');
                    foreach (string takeTag in tags)
                    {
                        if (takeTag.Trim() != "")
                        {
                            if(takeTag==tag)
                            {
                            listArticle.Add(articleService.GetArticlesById(article.Id));
                            break;
                            }
                        }
                    }
            }
            return View("Index", mapper.Map<IEnumerable<ArticleDTO>, List<ArticleView>>(listArticle));
        }
         public ActionResult ViewMyArrticle()
        {
            //return all article which own login user and present for him delete it
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ArticleView, ArticleDTO>());
            IMapper mapper = config.CreateMapper();
            return View(mapper.Map<IEnumerable<ArticleDTO>, List<ArticleView>>(articleService.GetArticles()).Where(u => u.UserId== Int32.Parse((string)(Session["UserId"]))));
        }
       [HttpGet]
        public ActionResult AddArticle()
        {
            return View();
        }
        //add article where userId take from session data
        [HttpPost]
        public ActionResult AddArticle(ArticleView article,string tags)
        {
            ArticleView art = new ArticleView();
            art.Text = article.Text;
            art.Title = article.Title;
            art.Tags = tags;
            string idUser = ((string)(Session["UserId"]));
            int userid=Int32.Parse(idUser);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ArticleView, ArticleDTO>());
            IMapper mapper = config.CreateMapper();
            ArticleDTO articleDTO = mapper.Map<ArticleView, ArticleDTO>(art);
            articleService.AddNewArticle(articleDTO, userid);
            return RedirectToAction("Index");
        }
        // delete the article and all comment which it has
        public ActionResult DeleteArticle(int id)
        {
            articleService.DeleteArticle(id);
      
            return RedirectToAction("Index");
        }
     //return all comment which has the article 
        public ActionResult ViewComment(int id)
        {
            ArticleDTO articleDTO = articleService.GetArticlesById(id);
            ViewBag.NameArticle = articleDTO.Title;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CommentView, CommentDTO>());
            IMapper mapper = config.CreateMapper();
            return View(mapper.Map<IEnumerable<CommentDTO>, List<CommentView>>(articleService.GetComments()).Where(u => u.ArticleId==id));
        }
        //add comment to choosen article 
        [HttpGet]
        public ActionResult AddComment(int id)
        {
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddComment(CommentView coment,int IdArticle)
        {
            string idUser = ((string)(Session["UserId"]));
            int userid = Int32.Parse(idUser);

            var config = new MapperConfiguration(cfg => cfg.CreateMap<CommentView, CommentDTO>());
            IMapper mapper = config.CreateMapper();
            CommentDTO commentDTO = mapper.Map<CommentView, CommentDTO>(coment);
            articleService.AddNewComment(commentDTO, IdArticle, userid);

            return RedirectToAction("Index");

        }
        // take anket and save it
        public ActionResult Anket(string Name, string Gender, string[] Operator, string UseCodeOperatop)
        {
            if (Name != null && Name != "" && Gender != null && Gender != "" && Operator.Length != 0)
            {
                anketServices.AddNewAnket( Name,  Gender, Operator,  UseCodeOperatop);
                return View("ResultAnket");
            }
            else
                return View();
        }

        [HttpGet]
        public ActionResult Guest()
        {

            //return all article 
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GuestbookView, GuestbookDTO>());
            IMapper mapper = config.CreateMapper();
            ViewBag.Guestbooks = mapper.Map<IEnumerable<GuestbookDTO>, List<GuestbookView>>(guestbookServices.GetGuestbook());
            return View();
        }
        [HttpPost]
        public ActionResult Guest(GuestbookView gb)
        {
            // show guest book(review)+ add new review
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GuestbookView, GuestbookDTO>());
            IMapper mapper = config.CreateMapper();
             mapper.Map<GuestbookView, GuestbookDTO>(gb);
            guestbookServices.AddToGuestbook(mapper.Map<GuestbookView, GuestbookDTO>(gb));
            return RedirectToAction("Guest");
        }
    }
}