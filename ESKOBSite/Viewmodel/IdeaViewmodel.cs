﻿using ESKOBSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESKOBSite.Viewmodel
{
    public class IdeaViewmodel
    {
        public Idea Idea { get; set; }
        public Task Task { get; set; }
        public Tenant Tenant { get; set; }
    }
}