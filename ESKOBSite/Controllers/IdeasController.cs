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

            IndexViewmodel viewmodel = new IndexViewmodel();
            List<Idea> model = new List<Idea>();
            var response = API.GET("/" + tenant.Reference + "/ideas/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                model = response.Content.ReadAsAsync<List<Idea>>().Result;
            }

            viewmodel.Tenant = tenant;
            viewmodel.Ideas = model;
            viewmodel.LoggedIn = loggedin;
            
            return View(viewmodel);
        }

        public async Task<ActionResult> Idea(string database, int id)
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
            if(!String.IsNullOrEmpty(Session["UserId"] as string) && !String.IsNullOrEmpty(Session["UserName"] as string))
            {
                int mid = Int32.Parse(Session["UserId"] as string);
                var mresponse = API.GET("/" + database + "/managers/" + mid).Result;
                if (ModelState.IsValid)
                {
                    loggedin = mresponse.Content.ReadAsAsync<Manager>().Result;
                }
            }

            IdeaViewmodel viewmodel = new IdeaViewmodel();
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

        public async Task<ActionResult> Create(string database)
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

            CreateViewmodel viewmodel = new CreateViewmodel();
            viewmodel.Tenant = tenant;
            viewmodel.LoggedIn = loggedin;
            
            return View(viewmodel);
        }
    }
}