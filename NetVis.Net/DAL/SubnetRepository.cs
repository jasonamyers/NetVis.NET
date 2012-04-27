using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using NetVis.Net.Models;

namespace NetVis.Net.DAL
{
    public class SubnetRepository : ISubnetRepository
    {
        private NetVisEntities context;

        public SubnetRepository(NetVisEntities context)
        {
            this.context = context;
        }

        public IEnumerable<Subnet> GetSubnets()
        {
            var subnets = context.Subnets.Include(s => s.Site);
            return subnets;
        }

        public Subnet GetSubnetByID(int ID)
        {
            Subnet subnet = context.Subnets.Include("Ips").Include("Site").Single(s => s.SubnetId == ID);
            return subnet;
        }

        public void InsertSubnet(Subnet Subnet)
        {
            context.Subnets.Add(Subnet);
        }

        public void DeleteSubnet(int SubnetID)
        {
            Subnet Subnet = context.Subnets.Find(SubnetID);
            context.Subnets.Remove(Subnet);
        }

        public void UpdateSubnet(Subnet Subnet)
        {
            context.Entry(Subnet).State = EntityState.Modified;
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