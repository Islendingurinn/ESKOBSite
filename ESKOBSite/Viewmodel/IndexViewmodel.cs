using ESKOBSite.Models;
using System.Collections.Generic;

namespace ESKOBSite.Viewmodel
{
    public class IndexViewmodel
    {
        public Tenant Tenant { get; set; }
        public IEnumerable<Idea> Ideas { get; set; }
        public Manager LoggedIn { get; set; }
        public string Search { get; set; }
    }
}