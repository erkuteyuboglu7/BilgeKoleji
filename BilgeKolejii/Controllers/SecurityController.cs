using BilgeKolejii.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BilgeKolejii.Controllers
{
    public class SecurityController : Controller
    {
        BilgeKolejiEntities db = new BilgeKolejiEntities();
        // GET: Security
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Ogrenciler ogrenciler)
        {
            var ogrenci = db.Ogrenciler.FirstOrDefault(x => x.TCNo == ogrenciler.TCNo && x.OkulNo == ogrenciler.OkulNo);
            if (ogrenci != null)
            {
                FormsAuthentication.SetAuthCookie(ogrenci.Ad, false);
                return RedirectToAction("Sinavlar", "Ogrenciler");
            }
            else
            {
                ViewBag.Mesaj = "Tekrar Deneyiniz";
                return View();
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}