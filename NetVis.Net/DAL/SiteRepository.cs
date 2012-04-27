using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using NetVis.Net.Models;

namespace NetVis.Net.DAL
{
        public class SiteRepository : ISiteRepository
        {
            private NetVisEntities context;

            public SiteRepository(NetVisEntities context)
            {
                this.context = context;
            }

            public IEnumerable<Site> GetSites()
            {
                return context.Sites.ToList();
            }

            public IEnumerable<Site> GetSitesAndSubnets()
            {
                return context.Sites.Include("Subnets").ToList();
                
            }

            public Site GetSiteByID(int ID)
            {
                Site site = context.Sites.Include("Contacts").Include("Subnets").Single((s => s.SiteId == ID));
                return site;
            }

            public void InsertSite(Site Site)
            {
                context.Sites.Add(Site);
            }

            public void DeleteSite(int SiteID)
            {
                Site Site = context.Sites.Find(SiteID);
                context.Sites.Remove(Site);
            }

            public void UpdateSite(Site Site)
            {
                context.Entry(Site).State = EntityState.Modified;
            }

            public void Save()
            {
                context.SaveChanges();
            }

            private bool disposed = false;
            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
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