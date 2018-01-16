using BlogUsingEF.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogUsingEF.Controllers
{
    public class AnketController : Controller
    {
        // For working with db.
        IAnketService anketServices;
        public AnketController(IAnketService anketServices)
        {
            this.anketServices = anketServices;
        }

        // GET: Anket
        // Take anket and save it.
        public ActionResult Anket(string Name, string Gender, string[] Operator, string UseCodeOperatop)
        {
            if (Name != null && Name != "" && Gender != null && Gender != "" && Operator.Length != 0)
            {
                anketServices.AddNewAnket(Name, Gender, Operator, UseCodeOperatop);
                return View("ResultAnket");
            }
            else
                return View();
        }
    }
}