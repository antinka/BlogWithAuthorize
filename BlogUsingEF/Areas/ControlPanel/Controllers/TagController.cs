using AutoMapper;
using BlogUsingEF.BLL.DTO;
using BlogUsingEF.BLL.Interfaces;
using BlogUsingEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogUsingEF.Areas.ControlPanel.Controllers
{
    public class TagController : Controller
    {
        //For work with db.
        IArticleServiceAddGetArticleComment articleService;
        ITagServices tagServices;
        public TagController(IArticleServiceAddGetArticleComment articleService, ITagServices tagServices)
        {
            this.articleService = articleService;
            this.tagServices = tagServices;
        }
        //Add new tags in db.
        [HttpGet]
        public ActionResult AddTag()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTag(string tags)
        {
            TagDTO tagDTO = new TagDTO();
            string[] arrTag = tags.Split('#');
            foreach (string tag in arrTag)
            {
                if (tag.Trim() != "")
                {
                    tagDTO.Text = tag;
                    tagServices.AddNewTag(tagDTO);
                }
            }
            return RedirectToAction("Index", "Article");
        }
        
    }
}