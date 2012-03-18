using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NetVis.Net.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<NetVisEntities>
    {
        protected override void Seed(NetVisEntities context)
        {
            new List<Site>
            {
                new Site { SiteId = 0, Name = "Windstream", Address = "3rd Ave", Priority = 1, Description = "Primary Data Center" },
            new Site { SiteId = 1, Name = "Peak 10", Address = "Duke Ave", Priority = 1, Description = "Secondary Data Center" },
            new Site { SiteId = 2, Name = "Home Office", Address = "Murfreesboro Pike", Priority = 1, Description = "Home Office" }
            }.ForEach(s => context.Sites.Add(s));

            new List<Contact>
            {
                new Contact { ContactId = 0, Name = "Jim Jones", Email = "jjones@windstream.net", Phone = "615-899-9999", SiteId=0 },
                new Contact { ContactId = 1, Name = "Peak 10 Support", Email = "support@peak10.net", Phone = "615-899-9999", SiteId=1 }
            }.ForEach(c => context.Contacts.Add(c));

            new List<Subnet>
            {
                new Subnet { SubnetId = 0, Network = "192.168.4.0", Netmask = "255.255.255.0", Gateway = "192.168.4.200", Description = "Primary PDC LAN", SiteId = 0 },
                new Subnet { SubnetId = 1, Network = "192.168.45.0", Netmask = "255.255.255.0", Gateway = "192.168.46.200", Description = "Primary ERMA LAN", SiteId = 0 },
                new Subnet { SubnetId = 2, Network = "192.168.16.0", Netmask = "255.255.255.0", Gateway = "192.168.16.1", Description = "Primary SDC LAN", SiteId = 1 },
                new Subnet { SubnetId = 3, Network = "192.168.6.0", Netmask = "255.255.255.0", Gateway = "192.168.6.1", Description = "Home Office Core LAN", SiteId = 2 }
            }.ForEach(n => context.Subnets.Add(n));

            new List<Ip>
            {
                new Ip { IpId = 0, Address = "192.168.4.200", Name = "pdcsw01.ccstenn.com", Purpose = "Default Gateway Cisco Switch", SubnetId = 0 },
                new Ip { IpId = 1, Address = "192.168.4.10", Name = "pdcfw01.ccstenn.com", Purpose = "Firewall", SubnetId = 0 },
                new Ip { IpId = 2, Address = "192.168.16.1", Name = "sdcsw01.ccstenn.com", Purpose = "Default Gateway Cisco Switch", SubnetId = 2 },
                new Ip { IpId = 3, Address = "192.168.16.5", Name = "sdcdc02.ccstenn.com", Purpose = "DC and Primary DNS", SubnetId = 2 },
                new Ip { IpId = 4, Address = "192.168.6.22", Name = "sdcesxiv01.ccstenn.com", Purpose = "Voice Server", SubnetId=3 }
            }.ForEach(i => context.Ips.Add(i));
        }

    }
}