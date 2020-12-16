using ESKOBSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESKOBSite.Viewmodel
{
    public class IndexViewmodel
    {
        public Tenant Tenant { get; set; }
        public IEnumerable<Idea> Ideas { get; set; }
        public Manager LoggedIn { get; set; }
    }
}