using Beginner.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Beginner.Controllers
{
    public class ChuckController : Controller
    {
        // GET: Chuck
        public ActionResult Index()
     
        {
            RandomChuck joke;
            using ( var client= new HttpClient())
            {
                string json = client.GetStringAsync("https://api.chucknorris.io/jokes/random").Result;
                joke = JsonConvert.DeserializeObject<RandomChuck>(json);
            }
            return View(joke);
        }
    }
}