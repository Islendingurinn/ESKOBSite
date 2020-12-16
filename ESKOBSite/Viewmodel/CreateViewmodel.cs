using ESKOBSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESKOBSite.Viewmodel
{
    public class CreateViewmodel
    {
        public Tenant Tenant { get; set; }
        public Idea Idea { get; set; }
        public Manager LoggedIn { get; set; }
    }
}