﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESKOBSite.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
    }
}