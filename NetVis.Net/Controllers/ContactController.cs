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
    public class ContactController : Controller
    {
        private IContactRepository contactRepository;
        private ISiteRepository siteRepository = new SiteRepository(new NetVisEntities());

        public ContactController()
        {
            this.contactRepository = new ContactRepository(new NetVisEntities());
        }

        public ContactController(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        //
        // GET: /Contact/

        public ViewResult Index()
        {
            return View(contactRepository.GetContacts());
        }

        //
        // GET: /Contact/Details/5

        public ViewResult Details(int id)
        {
            Contact contact = contactRepository.GetContactByID(id);
            return View(contact);
        }

        //
        // GET: /Contact/Create

        public ActionResult Create()
        {
            ViewBag.SiteID = new SelectList(siteRepository.GetSites(), "SiteId", "Name");
            
            return View();
        } 

        //
        // POST: /Contact/Create

        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contactRepository.InsertContact(contact);
                contactRepository.Save();
                return RedirectToAction("Index");  
            }
            ViewBag.SiteID = new SelectList(siteRepository.GetSites(), "SiteId", "Name");
            
            return View(contact);
        }
        
        //
        // GET: /Contact/Edit/5
 
        public ActionResult Edit(int id)
        {
            Contact contact = contactRepository.GetContactByID(id);
            ViewBag.SiteID = new SelectList(siteRepository.GetSites(), "SiteId", "Name");
            
            return View(contact);
        }

        //
        // POST: /Contact/Edit/5

        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contactRepository.UpdateContact(contact);
                contactRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.SiteID = new SelectList(siteRepository.GetSites(), "SiteId", "Name");
            
            return View(contact);
        }

        //
        // GET: /Contact/Delete/5
 
        public ActionResult Delete(int id)
        {
            Contact contact = contactRepository.GetContactByID(id);
            return View(contact);
        }

        //
        // POST: /Contact/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Contact contact = contactRepository.GetContactByID(id);
            contactRepository.DeleteContact(id);
            contactRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            contactRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}