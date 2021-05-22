using BilgeKolejii.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeKolejii.Controllers
{
    public class HomeController : Controller
    {
        BilgeKolejiEntities db = new BilgeKolejiEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Education()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }
    }
}