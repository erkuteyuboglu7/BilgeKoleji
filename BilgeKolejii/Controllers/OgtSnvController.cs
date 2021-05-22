using BilgeKolejii.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeKolejii.Controllers
{
    public class OgtSnvController : Controller
    {
        BilgeKolejiEntities db = new BilgeKolejiEntities();

        // GET: OgtSnv
        public ActionResult Index()
        {
            var snv = db.Sinavlar.ToList();
            return View(snv);
        }

        [HttpGet]
        public ActionResult YeniSinav()
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
        public ActionResult YeniSinav(Sinavlar p1)
        {
            var ogr = db.Ogrenciler.Where(m => m.Id == p1.Ogrenciler.Id).FirstOrDefault();
            p1.Ogrenciler = ogr;
            db.Sinavlar.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SIL(int id)
        {
            var snv = db.Sinavlar.Find(id);
            db.Sinavlar.Remove(snv);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SinavGetir(int id)
        {
            var snv = db.Sinavlar.Find(id);
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
            return View("SinavGetir", snv);
        }


        public ActionResult Guncelle(Sinavlar p1)
        {
            var snv = db.Sinavlar.Find(p1.SınavId);
            var ogr = db.Ogrenciler.Where(m => m.Id == p1.Ogrenciler.Id).FirstOrDefault();
            snv.OgrenciId = ogr.Id;
            snv.BransId = p1.BransId;
            snv.Sınav1 = p1.Sınav1;
            snv.Sınav2 = p1.Sınav2;
            snv.Proje = p1.Proje;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}