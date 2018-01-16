using AutoMapper;
using BlogUsingEF.BLL.DTO;
using BlogUsingEF.BLL.Interfaces;
using BlogUsingEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogUsingEF.Controllers
{
    public class GuestBookController : Controller
    {
        // For working with db.
        IGuestbookServices guestbookServices;
        public GuestBookController( IGuestbookServices guestbookServices)
        {
            this.guestbookServices = guestbookServices;
        }

        //Return all message in guest book + you can add new message.
        [HttpGet]
        public ActionResult Guest()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GuestbookView, GuestbookDTO>());
            IMapper mapper = config.CreateMapper();
            ViewBag.Guestbooks = mapper.Map<IEnumerable<GuestbookDTO>, List<GuestbookView>>(guestbookServices.GetGuestbook());
            return View();
        }
        [HttpPost]
        public ActionResult Guest(GuestbookView gb)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GuestbookView, GuestbookDTO>());
            IMapper mapper = config.CreateMapper();
            mapper.Map<GuestbookView, GuestbookDTO>(gb);
            guestbookServices.AddToGuestbook(mapper.Map<GuestbookView, GuestbookDTO>(gb));
            return RedirectToAction("Guest");
        }
    }
}