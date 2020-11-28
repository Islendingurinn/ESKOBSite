using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESKOBSite.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Estimation { get; set; }
        public Manager Creator { get; set; }
        public Idea Idea { get; set; }
        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();
    }
}