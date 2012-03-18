using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetVis.Net.Models;

namespace NetVis.Net.Controllers
{ 
    public class SiteController : Controller
    {
        private NetVisEntities db = new NetVisEntities();

        //
        // GET: /Site/

        public ViewResult Index()
        {
            return View(db.Sites.ToList());
        }

        //
        // GET: /Site/Details/5

        public ViewResult Details(int id)
        {
            Site site = db.Sites.Include("Contacts").Include("Subnets").Single(s => s.SiteId == id);
//            Site site = db.Sites.Find(id);
            return View(site);
        }

        //
        // GET: /Site/Create

        
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Site/Create

        
        [HttpPost]
        public ActionResult Create(Site site)
        {
            if (ModelState.IsValid)
            {
                db.Sites.Add(site);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(site);
        }
        
        //
        // GET: /Site/Edit/5

        
        public ActionResult Edit(int id)
        {
            Site site = db.Sites.Find(id);
            return View(site);
        }

        //
        // POST: /Site/Edit/5
        
        
        [HttpPost]
        public ActionResult Edit(Site site)
        {
            if (ModelState.IsValid)
            {
                db.Entry(site).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(site);
        }

        //
        // GET: /Site/Delete/5

        
        public ActionResult Delete(int id)
        {
            Site site = db.Sites.Find(id);
            return View(site);
        }

        //
        // POST: /Site/Delete/5

        
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Site site = db.Sites.Find(id);
            db.Sites.Remove(site);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}