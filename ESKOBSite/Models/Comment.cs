using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESKOBSite.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }
        public Idea Idea { get; set; }
        public Task Task {get; set; }
        public Manager Author { get; set; }
    }
}