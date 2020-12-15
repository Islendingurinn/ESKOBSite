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
            if (!await API.VALIDATETENANT(database))
                return View("~/Views/Shared/Error.cshtml");

            return Redirect("/" + database);
        }

        //TODO
        public async Task<ActionResult> Task(string database, int id)
        {
            if (!await API.VALIDATETENANT(database))
                return View("~/Views/Shared/Error.cshtml");

            IdeaViewmodel viewmodel = new IdeaViewmodel();
            Models.Task model = null;
            var response = API.GET("/" + database + "/tasks/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                model = response.Content.ReadAsAsync<Models.Task>().Result;
            }

            viewmodel.Database = database;
            viewmodel.Task = model;
            return View(viewmodel);
        }

        public async Task<ActionResult> Create(string database, string id)
        {
            if (!await API.VALIDATETENANT(database))
                return View("~/Views/Shared/Error.cshtml");

            CreateViewmodel viewmodel = new CreateViewmodel();
            Idea model = null;
            var response = API.GET("/" + database + "/ideas/" + id).Result;
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