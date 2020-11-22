using ESKOBSite.Models;
using ESKOBSite.Viewmodel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ESKOBSite.Controllers
{
    public class IdeasController : Controller
    { 

        public async Task<ActionResult> Index(string database, string id)
        {
            IndexViewmodel viewmodel = new IndexViewmodel();
            List<Idea> model = new List<Idea>();
            var response = API.GET("/api/ideas/get/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                model = response.Content.ReadAsAsync<List<Idea>>().Result;
            }

            viewmodel.Database = database;
            viewmodel.Ideas = model;
            return View(viewmodel);
        }

        public async Task<ActionResult> Idea(int id)
        {
            Idea model = null;
            var response = API.GET("/api/ideas/get/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                model = response.Content.ReadAsAsync<Idea>().Result;
            }
            return View(model);
        }

        public async Task<ActionResult> Hashtag(string id)
        {
            List<Idea> model = new List<Idea>();
            var response = API.GET("/api/hashtags/getideas/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                model = response.Content.ReadAsAsync<List<Idea>>().Result;
            }
            return View(model);
        }
    }
}