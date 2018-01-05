using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogUsingEF.DAL.Repositories;
using BlogUsingEF.DAL;
using BlogUsingEF.DAL.Entities;
using BlogUsingEF.DAL.Interfaces;
using BlogUsingEF.Models;
using BlogUsingEF.BLL.DTO;
using AutoMapper;
using BlogUsingEF.BLL.Interfaces;

namespace BlogUsingEF.Controllers
{
    public class UserController : Controller
    {
        IUserServicesAddEnter userService;
        public UserController(IUserServicesAddEnter serv)
        {
            userService = serv;
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }  
        // add new user where userName unic
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(UserView user)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<UserView, UserDTO>());
                IMapper mapper = config.CreateMapper();
                try { 
                    UserDTO userDetails = userService.AddNewUser(mapper.Map<UserView, UserDTO>(user));
                    if (userDetails != null)
                    {
                        Session["UserId"] = userDetails.Id.ToString();
                        Session["UserName"] = userDetails.UserName.ToString();
                        return RedirectToAction("Welcom");
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "exist");
                }
               
            }
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserView user)
        {
            // search user which try to login and put id and userName in relevant session
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserView, UserDTO>());
            IMapper mapper = config.CreateMapper();
            try
            { 
                UserDTO userDetails = userService.EnterToSystem(mapper.Map<UserView, UserDTO>(user));
                if (userDetails != null)
                {
                  
                    Session["UserName"] = userDetails.UserName.ToString();
                    Session["UserId"] = userDetails.Id.ToString();
                    return RedirectToAction("Welcom");
                }
            }
            catch
            { // if such user didnt find
                 ModelState.AddModelError("", "error");
            }
            return View();
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Welcom");
        }
        public ActionResult Welcom()
        {
            return View();
        }
    }
}