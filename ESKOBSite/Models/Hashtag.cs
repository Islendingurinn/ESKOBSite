using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESKOBSite.Models
{
    public class Hashtag
    {
        public int Id { get; set; }
        public string Tag { get; set; }

        public Idea Idea { get; set; }
        //public Task Task { get; set; }
    }
}