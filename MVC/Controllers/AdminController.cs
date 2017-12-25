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
    }
    


}