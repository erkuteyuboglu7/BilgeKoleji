using BilgeKolejii.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeKolejii.Controllers
{
    public class OgtDvmController : Controller
    {
        BilgeKolejiEntities db = new BilgeKolejiEntities();
        // GET: OgtDvm
        public ActionResult Index()
        {
            var yk = db.Yoklama.ToList();
            return View(yk);
        }

        [HttpGet]
        public ActionResult YeniYoklama()
        {
            List<SelectListItem> degerler = (from i in db.Ogrenciler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Ad + " " + i.Soyad,
                                                 Value = i.Id.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult YeniYoklama(Yoklama p1)
        {
            var ogr = db.Ogrenciler.Where(m => m.Id == p1.Ogrenciler.Id).FirstOrDefault();
            p1.Ogrenciler = ogr;
            db.Yoklama.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SIL(int id)
        {
            var yk = db.Yoklama.Find(id);
            db.Yoklama.Remove(yk);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YoklamaGetir(int id)
        {
            var yk = db.Yoklama.Find(id);
            List<SelectListItem> degerler = (from i in db.Ogrenciler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Ad + " " + i.Soyad,
                                                 Value = i.Id.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            //var br = db.Brans.Find(id);
            //List<SelectListItem> brn = (from b in db.Brans.ToList()
            //                            select new SelectListItem
            //                            {
            //                                Text = b.BransAdi,
            //                                Value = b.Id.ToString()
            //                            }).ToList();
            //ViewBag.brns = brn;
            return View("YoklamaGetir", yk);
        }


        public ActionResult Guncelle(Yoklama p1)
        {
            var yk = db.Yoklama.Find(p1.Id);
            yk.DersPlanId = p1.DersPlanId;
            var ogr = db.Ogrenciler.Where(m => m.Id == p1.Ogrenciler.Id).FirstOrDefault();
            yk.OgrenciId = ogr.Id;
            yk.Katilim = p1.Katilim;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}