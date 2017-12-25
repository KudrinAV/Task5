using PresentationLayer.Bridge;
using PresentationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowAllSales()
        {
            using (IBridgeToBLL db = new BridgeToBLL())
            {
                ViewBag.Sales = db.GetSales();
            }
            return View();
        }

        [HttpPost]
        public ActionResult ManagerSearch(string Name)
        {
            return PartialView();
        }
    }
}