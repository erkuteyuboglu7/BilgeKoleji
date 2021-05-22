using BilgeKolejii.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeKolejii.Controllers
{

    public class OgtEtkController : Controller
    {
        BilgeKolejiEntities db = new BilgeKolejiEntities(); 
        // GET: OgtEtk
        public ActionResult Index()
        {
            var et = db.Etkinlikler.ToList();
            return View(et);
        }

        [HttpGet]
        public ActionResult YeniEtkinlik()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniEtkinlik(Etkinlikler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniEtkinlik");
            }
            db.Etkinlikler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SIL(int id)
        {
            var et = db.Etkinlikler.Find(id);
            db.Etkinlikler.Remove(et);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EtkinlikGetir(int id)
        {
            var et = db.Etkinlikler.Find(id);
            return View("EtkinlikGetir", et);
        }


        public ActionResult Guncelle(Etkinlikler p1)
        {
            var et = db.Etkinlikler.Find(p1.Id);
            et.Id = p1.Id;
            et.Etkinlik = p1.Etkinlik;
            et.Tarih = p1.Tarih;
            et.Yer = p1.Yer;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}