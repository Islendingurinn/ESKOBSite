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
    public class TasksController : Controller
    { 

        public async Task<ActionResult> Index(string database)
        {
            return Redirect("/" + database);
        }

        //TODO
        public async Task<ActionResult> Task(string database, int id)
        {
            IdeaViewmodel viewmodel = new IdeaViewmodel();
            Models.Task model = null;
            var response = API.GET("/api/tasks/get/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                model = response.Content.ReadAsAsync<Models.Task>().Result;
            }

            viewmodel.Database = database;
            viewmodel.Task = model;
            return View(viewmodel);
        }

        public ActionResult Create(string database, string id)
        {
            CreateViewmodel viewmodel = new CreateViewmodel();
            Idea model = null;
            var response = API.GET("/api/ideas/get/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                model = response.Content.ReadAsAsync<Idea>().Result;
            }
            viewmodel.Database = database;
            viewmodel.Idea = model;
            return View(viewmodel);
        }
    }
}