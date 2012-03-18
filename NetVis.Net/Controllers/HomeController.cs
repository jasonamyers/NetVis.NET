using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetVis.Net.Models;

namespace NetVis.Net.Controllers
{
    public class HomeController : Controller
    {
        private NetVisEntities db = new NetVisEntities();


        public ActionResult Index()
        {
            List<Site> sites = db.Sites.Include("Subnets").ToList();
            ViewBag.ListSites = sites;
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
