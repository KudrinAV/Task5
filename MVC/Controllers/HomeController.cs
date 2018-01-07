using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.IsInRole("admin")) return RedirectToAction("Index", "Admin");
            if (User.IsInRole("user")) return RedirectToAction("Index", "User");
            return View();
        }
    }
}