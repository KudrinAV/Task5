using PresentationLayer.Bridge;
using PresentationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLayer.Controllers
{
    public class HomeController : Controller
    {
        IBridgeToBLL testBridge;

        public HomeController()
        {
            testBridge = new BridgeToBLL(); 
        }

        public ActionResult Index()
        {
            

            return View(testBridge.GetSales());
        }
    }
}