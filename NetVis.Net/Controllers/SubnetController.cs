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
    public class SubnetController : Controller
    {
        private ISubnetRepository subnetRepository;
        private ISiteRepository siteRepository = new SiteRepository(new NetVisEntities());

        public SubnetController()
        {
            this.subnetRepository = new SubnetRepository(new NetVisEntities());
        }

        public SubnetController(ISubnetRepository subnetRepository)
        {
            this.subnetRepository = subnetRepository;
        }
        //
        // GET: /Subnet/

        public ViewResult Index()
        {
            return View(subnetRepository.GetSubnets());
        }

        //
        // GET: /Subnet/Details/5

        public ViewResult Details(int id)
        {
            Subnet subnet = subnetRepository.GetSubnetByID(id);
            return View(subnet);
        }

        //
        // GET: /Subnet/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            ViewBag.SiteId = new SelectList(siteRepository.GetSites(), "SiteId", "Name");
            return View();
        }

        //
        // POST: /Subnet/Create
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Create(Subnet subnet)
        {
            if (ModelState.IsValid)
            {
                subnetRepository.InsertSubnet(subnet);
                subnetRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.SiteId = new SelectList(siteRepository.GetSites(), "SiteId", "Name", subnet.SiteId);
            return View(subnet);
        }

        //
        // GET: /Subnet/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            Subnet subnet = subnetRepository.GetSubnetByID(id);
            ViewBag.SiteId = new SelectList(siteRepository.GetSites(), "SiteId", "Name", subnet.SiteId);
            return View(subnet);
        }

        //
        // POST: /Subnet/Edit/5
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Edit(Subnet subnet)
        {
            if (ModelState.IsValid)
            {
                subnetRepository.UpdateSubnet(subnet);
                subnetRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.SiteId = new SelectList(siteRepository.GetSites(), "SiteId", "Name", subnet.SiteId);
            return View(subnet);
        }

        //
        // GET: /Subnet/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            Subnet subnet = subnetRepository.GetSubnetByID(id);
            return View(subnet);
        }

        //
        // POST: /Subnet/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Subnet subnet = subnetRepository.GetSubnetByID(id);
            subnetRepository.DeleteSubnet(id);
            subnetRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            subnetRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}