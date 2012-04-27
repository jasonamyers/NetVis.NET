using System;
using System.Collections.Generic;
using NetVis.Net.Models;

namespace NetVis.Net.DAL
{
    public interface ISiteRepository : IDisposable
    {
        IEnumerable<Site> GetSites();
        IEnumerable<Site> GetSitesAndSubnets();
        Site GetSiteByID(int ID);
        void InsertSite(Site Site);
        void DeleteSite(int SiteID);
        void UpdateSite(Site Site);
        void Save();
    }
}