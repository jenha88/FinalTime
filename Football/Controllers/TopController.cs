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
        public ActionResult Animes()
        {
            var animes = db.Animes.OrderByDescending(x => x.name).Take(10);
            return View(animes);
        }

        // GET: Top/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anime anime = db.Animes.Find(id);
            if (anime == null)
            {
                return HttpNotFound();
            }
            return View(anime);
        }
        public ActionResult Animes(int? id)
        {
            if (number == null)
            {
                var movies = db.Animes.OrderByDescending(x => x.name).Take(10);
                return View(movies);

            }
            Anime anime = db.Animes.Find(id);
            var animes = db.Animes.OrderByDescending(x => x.name).Take((int)number);
            if (anime == null)
            {
                return HttpNotFound();
            }
            return View(anime);
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
