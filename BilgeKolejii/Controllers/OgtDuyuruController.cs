using BilgeKolejii.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeKolejii.Controllers
{
    public class OgtDuyuruController : Controller
    {
        BilgeKolejiEntities db = new BilgeKolejiEntities();
        // GET: OgtDuyuru
        public ActionResult Index()
        {
            var dy = db.Duyurular.ToList();
            return View(dy);
        }

        [HttpGet]
        public ActionResult YeniDuyuru()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniDuyuru(Duyurular p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniDuyuru");
            }
            db.Duyurular.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SIL(int id)
        {
            var dy = db.Duyurular.Find(id);
            db.Duyurular.Remove(dy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DuyuruGetir(int id)
        {
            var dy = db.Duyurular.Find(id);
            return View("DuyuruGetir", dy);
        }


        public ActionResult Guncelle(Duyurular p1)
        {
            var dy = db.Duyurular.Find(p1.Id);
            dy.Id = p1.Id;
            dy.DuyuruYapanOgt = p1.DuyuruYapanOgt;
            dy.Sube = p1.Sube;
            dy.Duyuru = p1.Duyuru;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}