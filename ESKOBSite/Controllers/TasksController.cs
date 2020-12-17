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
            var tresponse = API.GET("/tenants/" + database).Result;
            Tenant tenant;
            if (!tresponse.IsSuccessStatusCode)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                tenant = tresponse.Content.ReadAsAsync<Tenant>().Result;
            }

            return Redirect("/" + tenant.Reference);
        }

        //TODO
        public async Task<ActionResult> Task(string database, int id)
        {
            var tresponse = API.GET("/tenants/" + database).Result;
            Tenant tenant;
            if (!tresponse.IsSuccessStatusCode)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                tenant = tresponse.Content.ReadAsAsync<Tenant>().Result;
            }

            Manager loggedin = null;
            if (!String.IsNullOrEmpty(Session["UserId"] as string) && !String.IsNullOrEmpty(Session["UserName"] as string))
            {
                int mid = Int32.Parse(Session["UserId"] as string);
                var mresponse = API.GET("/" + database + "/managers/" + mid).Result;
                if (ModelState.IsValid)
                {
                    loggedin = mresponse.Content.ReadAsAsync<Manager>().Result;
                }
            }

            IdeaViewmodel viewmodel = new IdeaViewmodel();
            Models.Task model = null;
            var response = API.GET("/" + tenant.Reference + "/tasks/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                model = response.Content.ReadAsAsync<Models.Task>().Result;
            }

            viewmodel.Tenant = tenant;
            viewmodel.Task = model;
            viewmodel.LoggedIn = loggedin;
            
            return View(viewmodel);
        }

        public async Task<ActionResult> Create(string database, string id)
        {
            var tresponse = API.GET("/tenants/" + database).Result;
            Tenant tenant;
            if (!tresponse.IsSuccessStatusCode)
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                tenant = tresponse.Content.ReadAsAsync<Tenant>().Result;
            }

            Manager loggedin = null;
            if (!String.IsNullOrEmpty(Session["UserId"] as string) && !String.IsNullOrEmpty(Session["UserName"] as string))
            {
                int mid = Int32.Parse(Session["UserId"] as string);
                var mresponse = API.GET("/" + database + "/managers/" + mid).Result;
                if (ModelState.IsValid)
                {
                    loggedin = mresponse.Content.ReadAsAsync<Manager>().Result;
                }
            }
            else
            {
                return Redirect("/" + tenant.Reference);
            }

            CreateViewmodel viewmodel = new CreateViewmodel();
            Idea model = null;
            var response = API.GET("/" + tenant.Reference + "/ideas/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                model = response.Content.ReadAsAsync<Idea>().Result;
            }

            viewmodel.Tenant = tenant;
            viewmodel.Idea = model;
            viewmodel.LoggedIn = loggedin;
            
            return View(viewmodel);
        }
    }
}