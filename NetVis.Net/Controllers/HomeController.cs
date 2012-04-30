using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NetVis.Net.DAL;
using NetVis.Net.Models;

namespace NetVis.Net.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ISiteRepository siteRepository;

        public HomeController()
        {
            siteRepository = new SiteRepository(new NetVisEntities());
        }

        public HomeController(ISiteRepository siteRepository)
        {
            this.siteRepository = siteRepository;
        }


        public ActionResult Index()
        {
            List<Site> sites = siteRepository.GetSitesAndSubnets().ToList();
            ViewBag.ListSites = sites;
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
