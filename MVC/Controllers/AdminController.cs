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
    
    public class AdminController : Controller
    {
        // GET: Admin
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View();
        }

        // Get : CreateUser
        [Authorize(Roles = "admin")]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                using(IBridgeToBLL db = new BridgeToBLL())
                {
                    
                    if(db.CreateUser(model.ManagerName, model.Login, model.Password)) return RedirectToAction("Index", "Admin");
                    else ModelState.AddModelError("", "Пользователя с таким логином уже есть");
                }
            }
            return View(model);
        }

        //Get: ShowAllUsers
        [Authorize(Roles = "admin")]
        public ActionResult ShowAllUsers()
        {
            using(IBridgeToBLL db = new BridgeToBLL())
            {
                ViewBag.Users = db.GetUsers();
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult EditUser(string login)
        {
            EditUserModel m = new EditUserModel
            {
                OldLogin = login
            };
            return View(m);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult EditUser(EditUserModel user)
        {
            if(user.NewLogin == user.OldLogin && user.NewLogin!=null && user.NewPassword== null)
            {
                 ModelState.AddModelError("", "Вы ввели такое же имя");
                
            }
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


        [Authorize(Roles = "admin")]
        public ActionResult DeleteUser(string login)
        {
            using (IBridgeToBLL db = new BridgeToBLL())
            {
                if (db.DeleteUser(login)) return RedirectToAction("ShowAllUsers", "Admin");
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult ShowAllManagers()
        {
            using (IBridgeToBLL db = new BridgeToBLL())
            {
                ViewBag.Managers = db.GetManagers();
            }
            return View();
        }

        // Get : CreateUser
        [Authorize(Roles = "admin")]
        public ActionResult CreateManager()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
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


        [Authorize(Roles = "admin")]
        public ActionResult EditManager(string name)
        {
            EditManagerModel m = new EditManagerModel
            {
                OldName = name
            };
            return View(m);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult EditManager(EditManagerModel user)
        {
            if(user.OldName == user.NewName )
            {
                ModelState.AddModelError("", "Вы ввели такое же имя");
            }
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


        [Authorize(Roles = "admin")]
        public ActionResult DeleteManager(string name)
        {
            using (IBridgeToBLL db = new BridgeToBLL())
            {
                if (db.DeleteManager(name)) return RedirectToAction("ShowAllManagers", "Admin");
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult ShowAllSales(int? manager, string product, string date)
        {
            using (IBridgeToBLL db = new BridgeToBLL())
            {
                IEnumerable<SaleViewModel> sales = db.GetSales();


                if (manager != 0 && manager != null)
                {
                    sales = sales.Where(x => x.ManagerId == manager);

                }
                if (!String.IsNullOrEmpty(product) && !product.Equals("Любой"))
                {
                    sales = sales.Where(x => x.Product == product);
                }
                if (date != null && !date.Equals("Даты нет"))
                {
                    DateTime time;
                    DateTime.TryParse(date, out time);
                    sales = sales.Where(x => x.Date.Day == time.Day && x.Date.Month == time.Month && x.Date.Year == time.Year);
                }
                IList<ManagerViewModel> managers = db.GetManagers().ToList();
                managers.Insert(0, new ManagerViewModel { ManagerID = 0, LastName = "Все" });
                IList<string> products = sales.Select(x => x.Product).Distinct().ToList();
                products.Insert(0, "Любой");
                IList<DateTime> dates = sales.Select(x => x.Date).Distinct().ToList();
                IList<string> datesForFilter = new List<string>();
                foreach (var item in dates)
                {
                    datesForFilter.Add(String.Format("{0:d}", item));
                }
                datesForFilter.Insert(0, "Даты нет");
                FilterModel filter = new FilterModel
                {
                    Sales = sales,
                    Managers = new SelectList(managers, "ManagerId", "LastName"),
                    Products = new SelectList(products),
                    Dates = new SelectList(datesForFilter)
                };
                return View(filter);
            }

        }

        // Get : CreateUser
        [Authorize(Roles = "admin")]
        public ActionResult CreateSale()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSale(SaleModel model)
        {
            if (ModelState.IsValid)
            {
                using (IBridgeToBLL db = new BridgeToBLL())
                {

                    if (db.CreateSale(new SaleViewModel(DateTime.Now, model.Client, model.Product, model.Price, db.GetManagerIdForUser(User.Identity.Name)))) return RedirectToAction("ShowAllSales", "Admin");
                    else ModelState.AddModelError("", "Пользователя с таким логином уже есть");
                }
            }
            return View(model);
        }


        [Authorize(Roles = "admin")]
        public ActionResult EditSale(int Id)
        {
            EditSaleModel m = new EditSaleModel
            {
                Id = Id
            };
            return View(m);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult EditSale(EditSaleModel sale)
        {
            if (ModelState.IsValid)
            {
                using (IBridgeToBLL db = new BridgeToBLL())
                {
                    int? managerId = 0;
                    if (sale.ManagerName != null && db.GetManagerId(sale.ManagerName)!=null) managerId = db.GetManagerId(sale.ManagerName);
                    if (db.EditSale(sale.Id,new SaleViewModel(DateTime.Now, sale.Client,sale.Product, sale.Price,(int) managerId))) return RedirectToAction("ShowAllSales", "Admin");
                    else ModelState.AddModelError("", "Неудалось изменить аккаунт");
                }
            }

            return View();
        }


        [Authorize(Roles = "admin")]
        public ActionResult DeleteSale(int Id)
        {
            using (IBridgeToBLL db = new BridgeToBLL())
            {
                if (db.DeleteSale(Id)) return RedirectToAction("ShowAllSales", "Admin");
            }
            return View();
        }

        public JsonResult CheckName(string newName, string oldName)
        {
            var result = !(newName == oldName);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
    
}