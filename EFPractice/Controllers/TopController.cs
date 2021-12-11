using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EFPractice.Models;

namespace EFPractice.Controllers
{
    public class TopController : Controller
    {
        private DB_128040_practiceEntities db = new DB_128040_practiceEntities();

        // GET: Top
        public ActionResult Index()
        {
            var movies = db.Movies.OrderByDescending(m => m.imdb_score).Take(10);
            return View(movies);
        }

        // GET: Top/Details/5
        public ActionResult Movies(int? id)
        {
            if (id == null)
            {
                var mv= db.Movies.OrderByDescending(m => m.imdb_score).Take(10);
                return View(mv);
            }
            var movies = db.Movies.OrderByDescending(m => m.imdb_score).Take((int)id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            return View(movies);
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
