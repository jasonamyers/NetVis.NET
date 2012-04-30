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
    public class IpController : Controller
    {
        private IIpRepository ipRepository;
        private ISubnetRepository subnetRepository = new SubnetRepository(new NetVisEntities());

        public IpController()
        {
            this.ipRepository = new IpRepository(new NetVisEntities());
        }

        public IpController(IIpRepository ipRepository)
        {
            this.ipRepository = ipRepository;
        }

        //
        // GET: /IP/

        public ViewResult Index()
        {
            return View(ipRepository.GetIps());
        }

        //
        // GET: /IP/Details/5

        public ViewResult Details(int id)
        {
            return View(ipRepository.GetIpByID(id));
        }

        //
        // GET: /IP/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            ViewBag.SubnetId = new SelectList(subnetRepository.GetSubnets(), "SubnetId", "Network");
            return View();
        }

        //
        // POST: /IP/Create
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Create(Ip ip)
        {
            if (ModelState.IsValid)
            {
                ipRepository.InsertIp(ip);
                ipRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.SubnetId = new SelectList(subnetRepository.GetSubnets(), "SubnetId", "Network", ip.SubnetId);
            return View(ip);
        }

        //
        // GET: /IP/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id)
        {
            Ip ip = ipRepository.GetIpByID(id);
            ViewBag.SubnetId = new SelectList(subnetRepository.GetSubnets(), "SubnetId", "Network", ip.SubnetId);
            return View(ip);
        }

        //
        // POST: /IP/Edit/5
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult Edit(Ip ip)
        {
            if (ModelState.IsValid)
            {
                ipRepository.UpdateIp(ip);
                ipRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.SubnetId = new SelectList(subnetRepository.GetSubnets(), "SubnetId", "Network", ip.SubnetId);
            return View(ip);
        }

        //
        // GET: /IP/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            Ip ip = ipRepository.GetIpByID(id);
            return View(ip);
        }

        //
        // POST: /IP/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Ip ip = ipRepository.GetIpByID(id);
            ipRepository.DeleteIp(id);
            ipRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            ipRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}