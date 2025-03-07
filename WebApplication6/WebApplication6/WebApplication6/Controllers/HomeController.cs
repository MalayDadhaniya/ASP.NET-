using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    using System.Web.Mvc;

    namespace FoodWebsiteMVC.Controllers
    {
        public class HomeController : Controller
        {

            public ActionResult Index()
            {
                return View();
            }

            public ActionResult About()
            {
                return View();
            }

            public ActionResult Contact()
            {
                return View();
            }
        }
    }
}