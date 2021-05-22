using BilgeKolejii.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeKolejii.Controllers
{
    public class OgtGirisController : Controller
    {
        BilgeKolejiEntities db = new BilgeKolejiEntities();
        // GET: OgtGiris
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Ogretmenler ogretmenler)
        {
            var ogretmen = db.Ogretmenler.FirstOrDefault(x => x.Ad == ogretmenler.Ad && x.Sifre == ogretmenler.Sifre);
            if(ogretmen != null)
            {
                return RedirectToAction("Index", "OgtSnv");
            }
            else
            {
                ViewBag.Mesaj = "Tekrar Deneyiniz";
                return View();
            }
        }
    }
}