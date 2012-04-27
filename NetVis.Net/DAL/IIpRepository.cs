using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NetVis.Net.Models;

namespace NetVis.Net.DAL
{
    public interface IIpRepository : IDisposable
    {
        IEnumerable<Ip> GetIps();
        Ip GetIpByID(int ID);
        void InsertIp(Ip ip);
        void DeleteIp(int ipID);
        void UpdateIp(Ip ip);
        void Save();
    }
}