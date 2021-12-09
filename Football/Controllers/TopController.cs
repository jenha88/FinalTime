using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Football.Models;

namespace Football.Controllers
{
    public class TopController : Controller
    {
        private DB_128040_practiceEntities db = new DB_128040_practiceEntities();

        // GET: Top
        public ActionResult Index()
        {
            var animes = db.Animes.OrderByDescending(x => x.rating).Take(10);
            return View(animes);
        }

        public ActionResult Animes(int? number)
        {
            if (number == null)
            {
                var A= db.Animes.OrderByDescending(x => x.rating).Take(10);
                return View(A);

            }
            
            var animes = db.Animes.OrderByDescending(x => x.rating).Take((int)number);
            if (animes == null)
            {
                return HttpNotFound();
            }
            return View(animes);
        }  



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
