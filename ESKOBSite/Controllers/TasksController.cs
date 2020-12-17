using ESKOBSite.Models;
using ESKOBSite.Viewmodel;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ESKOBSite.Controllers
{
    public class TasksController : Controller
    { 

        public async Task<ActionResult> Index(string reference)
        {
            var tresponse = await API.GET("/tenants/" + reference);
            Tenant tenant;
            if (!tresponse.IsSuccessStatusCode)
                return View("~/Views/Shared/Error.cshtml");
            else
                tenant = await tresponse.Content.ReadAsAsync<Tenant>();

            return Redirect("/" + tenant.Reference);
        }

        public async Task<ActionResult> Task(string reference, int id)
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

            
            Models.Task model = null;
            var response = await API.GET("/" + tenant.Reference + "/tasks/" + id);
            if (response.IsSuccessStatusCode)
                model = await response.Content.ReadAsAsync<Models.Task>();

            IdeaViewmodel viewmodel = new IdeaViewmodel
            {
                Tenant = tenant,
                Task = model,
                LoggedIn = loggedin
            };

            return View(viewmodel);
        }

        public async Task<ActionResult> Create(string reference, string id)
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
            else
                return Redirect("/" + tenant.Reference);

            
            Idea model = null;
            var response = await API.GET("/" + tenant.Reference + "/ideas/" + id);
            if (response.IsSuccessStatusCode)
                model = await response.Content.ReadAsAsync<Idea>();

            CreateViewmodel viewmodel = new CreateViewmodel
            {
                Tenant = tenant,
                Idea = model,
                LoggedIn = loggedin
            };

            return View(viewmodel);
        }
    }
}