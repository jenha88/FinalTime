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
    public class SpotifiesController : Controller
    {
        private DB_128040_practiceEntities db = new DB_128040_practiceEntities();

        // GET: Spotifies
        public ActionResult Index()
        {
            var spots = db.Spotifies.OrderByDescending(x => x.Popularity).Take(10);

            return View(db.Spotifies.ToList());
        }

        // GET: Spotifies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spotify spotify = db.Spotifies.Find(id);
            if (spotify == null)
            {
                return HttpNotFound();
            }
            return View(spotify);
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
