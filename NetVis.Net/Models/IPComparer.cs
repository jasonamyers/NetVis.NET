using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetVis.Net.Models
{
    public class IPComparer : IComparer<string>
    {
        public int Compare(String a, String b)
        {
            return Enumerable.Zip(a.Split('.'), b.Split('.'), (x, y) => int.Parse(x).CompareTo(int.Parse(y))).FirstOrDefault(i => i != 0);
        }
    }
}