using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using NetVis.Net.Models;

namespace NetVis.Net.DAL
{
    public class ContactRepository : IContactRepository
    {
        private NetVisEntities context;

        public ContactRepository(NetVisEntities context)
        {
            this.context = context;
        }

        public IEnumerable<Contact> GetContacts()
        {
            var contacts = context.Contacts.Include(c => c.Site);
            return contacts.ToList();
        }

        public Contact GetContactByID(int ID)
        {
            return context.Contacts.Include("Site").Single(c => c.ContactId  == ID);
        }

        public void InsertContact(Contact contact)
        {
            context.Contacts.Add(contact);
        }

        public void DeleteContact(int contactID)
        {
            Contact contact = context.Contacts.Find(contactID);
            context.Contacts.Remove(contact);
        }

        public void UpdateContact(Contact contact)
        {
            context.Entry(contact).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}