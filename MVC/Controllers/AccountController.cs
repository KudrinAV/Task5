using MVC.Models;
using PresentationLayer.Bridge;
using PresentationLayer.Interfaces;
using PresentationLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC.Controllers
{
    public class AccountController : Controller
    {
        //Get method
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {  
                using (IBridgeToBLL db = new BridgeToBLL())
                {
                    if (db.CheckUser(model.Login, model.Password))
                    {
                        FormsAuthentication.SetAuthCookie(model.Login , true);
                        return RedirectToAction("Index", "Home");
                    }
                    else ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");

                }
            }

            return View(model);
        }

        
       
        [Authorize(Roles="admin, user")]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }


}