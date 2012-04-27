using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NetVis.Net.Models;

namespace NetVis.Net.DAL
{
    public interface ISubnetRepository : IDisposable
    {
        IEnumerable<Subnet> GetSubnets();
        Subnet GetSubnetByID(int ID);
        void InsertSubnet(Subnet Subnet);
        void DeleteSubnet(int SubnetID);
        void UpdateSubnet(Subnet Subnet);
        void Save();
    }
}