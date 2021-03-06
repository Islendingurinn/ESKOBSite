﻿using System;
using System.Collections.Generic;

namespace ESKOBSite.Models
{
    public class Idea
    {
        public int Id { get; set; }
        public DateTime Submitted { get; set; }
        public DateTime Last_Edit { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public string Employee { get; set; }
        public string Cost_Save { get; set; }
        public string Challenges { get; set; }
        public string Results { get; set; }
        public int Impact { get; set; }
        public int Effort { get; set; }
        public IEnumerable<Hashtag> Hashtags { get; set; } = new List<Hashtag>();
        public IEnumerable<Task> Tasks { get; set; } = new List<Task>();
        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();
    }
}