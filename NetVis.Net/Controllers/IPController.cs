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
    public class IPController : Controller
    {
        private NetVisEntities db = new NetVisEntities();

        //
        // GET: /IP/

        public ViewResult Index()
        {
            var ips = db.Ips.Include(i => i.Subnet);
            return View(ips.ToList());
        }

        //
        // GET: /IP/Details/5

        public ViewResult Details(int id)
        {
            Ip ip = db.Ips.Find(id);
            return View(ip);
        }

        //
        // GET: /IP/Create

        public ActionResult Create()
        {
            ViewBag.SubnetId = new SelectList(db.Subnets, "SubnetId", "Network");
            return View();
        } 

        //
        // POST: /IP/Create

        [HttpPost]
        public ActionResult Create(Ip ip)
        {
            if (ModelState.IsValid)
            {
                db.Ips.Add(ip);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.SubnetId = new SelectList(db.Subnets, "SubnetId", "Network", ip.SubnetId);
            return View(ip);
        }
        
        //
        // GET: /IP/Edit/5
 
        public ActionResult Edit(int id)
        {
            Ip ip = db.Ips.Find(id);
            ViewBag.SubnetId = new SelectList(db.Subnets, "SubnetId", "Network", ip.SubnetId);
            return View(ip);
        }

        //
        // POST: /IP/Edit/5

        [HttpPost]
        public ActionResult Edit(Ip ip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubnetId = new SelectList(db.Subnets, "SubnetId", "Network", ip.SubnetId);
            return View(ip);
        }

        //
        // GET: /IP/Delete/5
 
        public ActionResult Delete(int id)
        {
            Ip ip = db.Ips.Find(id);
            return View(ip);
        }

        //
        // POST: /IP/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Ip ip = db.Ips.Find(id);
            db.Ips.Remove(ip);
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