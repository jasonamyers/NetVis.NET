using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetVis.Net.Models
{
    public class Subnet
    {
        public int SubnetId { get; set; }
        public int SiteId { get; set; }
        public string Network { get; set; }
        public string Description { get; set; }
        public string Netmask { get; set; }
        public string Gateway { get; set; }
        public int Preference { get; set; }
        public Site Site { get; set; }
        public ICollection<Ip> Ips { get; set; }
    }
}