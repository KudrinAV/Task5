using MVC.Models;
using PresentationLayer.Bridge;
using PresentationLayer.Interfaces;
using PresentationLayer.ViewModels;
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
        [Authorize(Roles = "user")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "user")]
        public ActionResult ShowAllSales()
        {
            using (IBridgeToBLL db = new BridgeToBLL())
            {
                ViewBag.Sales = db.GetSales();
            }
            return View();
        }

        // Get : CreateUser
        [Authorize(Roles = "user")]
        public ActionResult CreateSale()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "user")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSale(SaleModel model)
        {
            if (ModelState.IsValid)
            {
                using (IBridgeToBLL db = new BridgeToBLL())
                {

                    if (db.CreateSale(new SaleViewModel(DateTime.Now, model.Client, model.Product, model.Price, 1))) return RedirectToAction("ShowAllSales", "Admin");
                    else ModelState.AddModelError("", "Пользователя с таким логином уже есть");
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult ManagerSearch(string name)
        {
            using (IBridgeToBLL db = new BridgeToBLL())
            {
                
                return PartialView(db.FilterByManager(name));
               
            }
        }

        [Authorize(Roles = "user")]
        public ActionResult ShowAllManagers()
        {
            using (IBridgeToBLL db = new BridgeToBLL())
            {
                ViewBag.Managers = db.GetManagers();
            }
            return View();
        }
    }
}