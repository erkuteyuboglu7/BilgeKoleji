using BilgeKolejii.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BilgeKolejii.Controllers
{
    public class OgtDersController : Controller
    {
        BilgeKolejiEntities db = new BilgeKolejiEntities();
        // GET: OgtDers
        public ActionResult Index()
        {
            var br = db.Brans.ToList();
            return View(br);
        }

    }
}