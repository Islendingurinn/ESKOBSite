using ESKOBSite.Models;
using ESKOBSite.Viewmodel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ESKOBSite.Controllers
{
    public class IdeasController : Controller
    { 

        public async Task<ActionResult> Index(string reference, string id)
        {
            if(String.IsNullOrEmpty(reference))
                return View("~/Views/Shared/Error.cshtml");

            var tresponse = await API.GET("/tenants/" + reference);
            Tenant tenant;
            if (!tresponse.IsSuccessStatusCode)
                return View("~/Views/Shared/Error.cshtml");
            else
                tenant = await tresponse.Content.ReadAsAsync<Tenant>();

            Manager loggedin = null;
            if (!String.IsNullOrEmpty(Session["UserId"] as string) 
                && !String.IsNullOrEmpty(Session["UserName"] as string))
            {
                int mid = Int32.Parse(Session["UserId"] as string);
                var mresponse = await API.GET("/" + reference + "/managers/" + mid);
                if (ModelState.IsValid)
                    loggedin = await mresponse.Content.ReadAsAsync<Manager>();
            }

            List<Idea> model = new List<Idea>();
            var response = await API.GET("/" + tenant.Reference + "/ideas/" + id);
            if (response.IsSuccessStatusCode)
                model = await response.Content.ReadAsAsync<List<Idea>>();

            IndexViewmodel viewmodel = new IndexViewmodel
            {
                Tenant = tenant,
                Ideas = model,
                LoggedIn = loggedin,
                Search = id
            };

            return View(viewmodel);
        }

        public async Task<ActionResult> Idea(string reference, int id)
        {
            var tresponse = await API.GET("/tenants/" + reference);
            Tenant tenant;
            if (!tresponse.IsSuccessStatusCode)
                return View("~/Views/Shared/Error.cshtml");
            else
                tenant = await tresponse.Content.ReadAsAsync<Tenant>();

            Manager loggedin = null;
            if(!String.IsNullOrEmpty(Session["UserId"] as string) 
                && !String.IsNullOrEmpty(Session["UserName"] as string))
            {
                int mid = Int32.Parse(Session["UserId"] as string);
                var mresponse = await API.GET("/" + reference + "/managers/" + mid);
                if (ModelState.IsValid)
                    loggedin = await mresponse.Content.ReadAsAsync<Manager>();
            }

            Idea model = null;
            var response = await API.GET("/" + tenant.Reference + "/ideas/" + id);
            if (response.IsSuccessStatusCode)
                model = await response.Content.ReadAsAsync<Idea>();

            IdeaViewmodel viewmodel = new IdeaViewmodel
            {
                Tenant = tenant,
                Idea = model,
                LoggedIn = loggedin
            };

            return View(viewmodel);
        }

        public async Task<ActionResult> Create(string reference)
        {
            var tresponse = await API.GET("/tenants/" + reference);
            Tenant tenant;
            if (!tresponse.IsSuccessStatusCode)
                return View("~/Views/Shared/Error.cshtml");
            else
                tenant = await tresponse.Content.ReadAsAsync<Tenant>();

            Manager loggedin = null;
            if (!String.IsNullOrEmpty(Session["UserId"] as string) 
                && !String.IsNullOrEmpty(Session["UserName"] as string))
            {
                int mid = Int32.Parse(Session["UserId"] as string);
                var mresponse = await API.GET("/" + reference + "/managers/" + mid);
                if (ModelState.IsValid)
                    loggedin = await mresponse.Content.ReadAsAsync<Manager>();
            }

            CreateViewmodel viewmodel = new CreateViewmodel
            {
                Tenant = tenant,
                LoggedIn = loggedin
            };

            return View(viewmodel);
        }
    }
}