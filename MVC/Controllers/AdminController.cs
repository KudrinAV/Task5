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
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // Get : CreateUser
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                using(IBridgeToBLL db = new BridgeToBLL())
                {
                    
                    if(db.CreateUser(model.Login, model.Password)) return RedirectToAction("Index", "Admin");
                    else ModelState.AddModelError("", "Пользователя с таким логином уже есть");
                }
            }
            return View(model);
        }

        //Get: ShowAllUsers
        public ActionResult ShowAllUsers()
        {
            using(IBridgeToBLL db = new BridgeToBLL())
            {
                ViewBag.Users = db.GetUsers();
            }
            return View();
        }

        public ActionResult EditUser(string login)
        {
            EditUserModel m = new EditUserModel();
            m.OldLogin = login;
            return View(m);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(EditUserModel user)
        {
            if (ModelState.IsValid)
            {
                using (IBridgeToBLL db = new BridgeToBLL())
                {
                    if (db.EditUser(user.OldLogin, user.NewLogin, user.NewPassword)) return RedirectToAction("ShowAllUsers", "Admin");
                    else ModelState.AddModelError("", "Неудалось изменить аккаунт");
                }
            }
            
            return View();
        }


       
        public ActionResult DeleteUser(string login)
        {
            using (IBridgeToBLL db = new BridgeToBLL())
            {
                if (db.DeleteUser(login)) return RedirectToAction("ShowAllUsers", "Admin");
            }
            return View();
        }

        public ActionResult ShowAllManagers()
        {
            using (IBridgeToBLL db = new BridgeToBLL())
            {
                ViewBag.Managers = db.GetManagers();
            }
            return View();
        }

        // Get : CreateUser
        public ActionResult CreateManager()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateManager(ManagerModel model)
        {
            if (ModelState.IsValid)
            {
                using (IBridgeToBLL db = new BridgeToBLL())
                {

                    if (db.CreateManager(model.Name)) return RedirectToAction("Index", "Admin");
                    else ModelState.AddModelError("", "Пользователя с таким логином уже есть");
                }
            }
            return View(model);
        }



        public ActionResult EditManager(string name)
        {
            EditManagerModel m = new EditManagerModel();
            m.OldName = name;
            return View(m);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditManager(EditManagerModel user)
        {
            if (ModelState.IsValid)
            {
                using (IBridgeToBLL db = new BridgeToBLL())
                {
                    if (db.EditManager(user.OldName, user.NewName)) return RedirectToAction("ShowAllManagers", "Admin");
                    else ModelState.AddModelError("", "Неудалось изменить аккаунт");
                }
            }

            return View();
        }



        public ActionResult DeleteManager(string name)
        {
            using (IBridgeToBLL db = new BridgeToBLL())
            {
                if (db.DeleteManager(name)) return RedirectToAction("ShowAllManagers", "Admin");
            }
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

        // Get : CreateUser
        public ActionResult CreateSale()
        {
            return View();
        }

        [HttpPost]
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



        public ActionResult EditSale(int Id)
        {
            EditSaleModel m = new EditSaleModel();
            m.Id = Id;
            return View(m);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSale(EditSaleModel sale)
        {
            if (ModelState.IsValid)
            {
                using (IBridgeToBLL db = new BridgeToBLL())
                {
                    if (db.EditSale(sale.Id,new SaleViewModel(DateTime.Now, sale.Client,sale.Product, sale.Price, (int) db.GetManagerId(sale.ManagerName)))) return RedirectToAction("ShowAllSales", "Admin");
                    else ModelState.AddModelError("", "Неудалось изменить аккаунт");
                }
            }

            return View();
        }



        public ActionResult DeleteSale(int Id)
        {
            using (IBridgeToBLL db = new BridgeToBLL())
            {
                if (db.DeleteSale(Id)) return RedirectToAction("ShowAllSales", "Admin");
            }
            return View();
        }
    }
    
}