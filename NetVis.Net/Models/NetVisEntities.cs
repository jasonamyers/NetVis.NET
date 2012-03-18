using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NetVis.Net.Models
{
    public class NetVisEntities : DbContext
    {
        public DbSet<Subnet> Subnets { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Ip> Ips { get; set; }
    }
}