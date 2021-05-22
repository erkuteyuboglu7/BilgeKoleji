using BilgeKolejii.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeKolejii.Controllers
{
    [Authorize]
    public class OgrencilerController : Controller
    {
        // GET: Ogrenciler
        BilgeKolejiEntities db = new BilgeKolejiEntities();

        public ActionResult Sinavlar()
        {
            var br = db.Brans.ToList();
            var snv = db.Sinavlar.ToList();            
            return View(snv);
        }

        public ActionResult Devamsizlik()
        {
            var dvm = db.Yoklama.ToList();
            return View(dvm);
        }

        public ActionResult Dersler()
        {
            var ders = db.Brans.ToList();
            return View(ders);
        }

        public ActionResult Mesaj()
        {
            return View();
        }

        public ActionResult Etkinlik()
        {
            var etk = db.Etkinlikler.ToList();
            return View(etk);
        }

        public ActionResult Duyurular()
        {
            var dy = db.Duyurular.ToList();
            return View(dy);
        }
    }
}