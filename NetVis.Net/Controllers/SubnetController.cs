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
    public class SubnetController : Controller
    {
        private NetVisEntities db = new NetVisEntities();

        //
        // GET: /Subnet/

        public ViewResult Index()
        {
            var subnets = db.Subnets.Include(s => s.Site);
            return View(subnets.ToList());
        }

        //
        // GET: /Subnet/Details/5

        public ViewResult Details(int id)
        {
            //List<Ip> ips = db.Ips.Where(i => i.SubnetId==id).ToList();
            //ViewBag.ListIps = ips;
            Subnet subnet = db.Subnets.Include("Ips").Include("Site").Single(s => s.SubnetId == id);
            return View(subnet);
        }

        //
        // GET: /Subnet/Create

        public ActionResult Create()
        {
            ViewBag.SiteId = new SelectList(db.Sites, "SiteId", "Name");
            return View();
        } 

        //
        // POST: /Subnet/Create

        [HttpPost]
        public ActionResult Create(Subnet subnet)
        {
            if (ModelState.IsValid)
            {
                db.Subnets.Add(subnet);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.SiteId = new SelectList(db.Sites, "SiteId", "Name", subnet.SiteId);
            return View(subnet);
        }
        
        //
        // GET: /Subnet/Edit/5
 
        public ActionResult Edit(int id)
        {
            Subnet subnet = db.Subnets.Find(id);
            ViewBag.SiteId = new SelectList(db.Sites, "SiteId", "Name", subnet.SiteId);
            return View(subnet);
        }

        //
        // POST: /Subnet/Edit/5

        [HttpPost]
        public ActionResult Edit(Subnet subnet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subnet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SiteId = new SelectList(db.Sites, "SiteId", "Name", subnet.SiteId);
            return View(subnet);
        }

        //
        // GET: /Subnet/Delete/5
 
        public ActionResult Delete(int id)
        {
            Subnet subnet = db.Subnets.Find(id);
            return View(subnet);
        }

        //
        // POST: /Subnet/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Subnet subnet = db.Subnets.Find(id);
            db.Subnets.Remove(subnet);
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