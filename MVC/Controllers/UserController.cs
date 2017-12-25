﻿using MVC.Models;
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
        public ActionResult ShowAllSales(int? manager, string product )
        {
            using (IBridgeToBLL db = new BridgeToBLL())
            {
                IEnumerable<SaleViewModel> sales = db.GetSales();
                IList<ManagerViewModel> managers = db.GetManagers().ToList();
                managers.Insert(0, new ManagerViewModel { ManagerID = 0, LastName="Все" } );

                DateTime date = new DateTime();
                if (manager!=0 && manager!=null)
                {
                    sales = sales.Where(x =>x.ManagerId == manager);
                    
                }
                if (!String.IsNullOrEmpty(product) && !product.Equals("Любой"))
                {
                    sales = sales.Where(x => x.Product == product);
                }
                //if(date != null)
                //{
                //    sales = sales.Where(x => x.Date.Day == date.Day && x.Date.Month == date.Month && x.Date.Year == date.Year);
                //}
                IList<string> products = sales.Select(x=>x.Product).Distinct().ToList();
                products.Insert(0, "Любой");
                IList<DateTime> dates = sales.Select(x => x.Date).Distinct().ToList();

                //ViewBag.Sales = db.GetSales();
                FilterModel filter = new FilterModel
                {
                    Sales = sales,
                    Managers = new SelectList(managers, "ManagerId", "LastName"),
                    Products = new SelectList(products),
                    Dates = new SelectList(dates)
                };
                return View(filter);
            }
            
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

        [HttpPost]
        public ActionResult ProductSearch(string product)
        {
            using (IBridgeToBLL db = new BridgeToBLL())
            {

                return PartialView(db.FilterByProduct(product));

            }
        }

        [HttpPost]
        public ActionResult DateSearch(DateTime date)
        {
            using (IBridgeToBLL db = new BridgeToBLL())
            {

                return PartialView(db.FilterByDate(date));

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