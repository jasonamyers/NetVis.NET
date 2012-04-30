using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetVis.Net.DAL;
using NetVis.Net.Models;

namespace NetVis.Net.Controllers
{
    [Authorize]
    public class SiteController : Controller
    {
        private ISiteRepository siteRepository;

        public SiteController()
        {
            this.siteRepository = new SiteRepository(new NetVisEntities());
        }

        public SiteController(ISiteRepository siteRepository)
        {
            this.siteRepository = siteRepository;
        }

        //
        // GET: /Site/

        public ViewResult Index()
        {
            return View(siteRepository.GetSites());
        }

        //
        // GET: /Site/Details/5

        public ViewResult Details(int id)
        {
            return View(siteRepository.GetSiteByID(id));
        }

        //
        // GET: /Site/Create

        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Site/Create

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Create(Site site)
        {
            if (ModelState.IsValid)
            {
                siteRepository.InsertSite(site);
                siteRepository.Save();
                return RedirectToAction("Index");  
            }

            return View(site);
        }
        
        //
        // GET: /Site/Edit/5

        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            Site site = siteRepository.GetSiteByID(id);
            return View(site);
        }

        //
        // POST: /Site/Edit/5

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Edit(Site site)
        {
            if (ModelState.IsValid)
            {
                siteRepository.UpdateSite(site);
                siteRepository.Save();
                return RedirectToAction("Index");
            }
            return View(site);
        }

        //
        // GET: /Site/Delete/5

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            Site site = siteRepository.GetSiteByID(id);
            return View(site);
        }

        //
        // POST: /Site/Delete/5

        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Site site = siteRepository.GetSiteByID(id);
            siteRepository.DeleteSite(id);
            siteRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            siteRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}