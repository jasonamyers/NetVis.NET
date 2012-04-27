using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using NetVis.Net.Models;

namespace NetVis.Net.DAL
{
    public class IpRepository : IIpRepository
    {
        private NetVisEntities context;

        public IpRepository(NetVisEntities context)
        {
            this.context = context;
        }

        public IEnumerable<Ip> GetIps()
        {
            var Ips = context.Ips.Include(i => i.Subnet);
            return Ips;
        }

        public Ip GetIpByID(int ID)
        {
            return context.Ips.Find(ID);
        }

        public void InsertIp(Ip Ip)
        {
            context.Ips.Add(Ip);
        }

        public void DeleteIp(int IpID)
        {
            Ip Ip = context.Ips.Find(IpID);
            context.Ips.Remove(Ip);
        }

        public void UpdateIp(Ip Ip)
        {
            context.Entry(Ip).State = EntityState.Modified;
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