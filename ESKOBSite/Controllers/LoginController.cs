using ESKOBSite.Models;
using ESKOBSite.Viewmodel;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ESKOBSite.Controllers
{
    public class LoginController : Controller
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

            ViewBag.Name = tenant.Name;
            ViewBag.Reference = tenant.Reference;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(LoginManager objUser, string database)
        {
            if (ModelState.IsValid)
            {
                Manager manager = null;
                var result = await API.POST("/" + database + "/login", objUser);
                if (result.IsSuccessStatusCode)
                {
                    manager = await result.Content.ReadAsAsync<Manager>();
                }

                if (manager != null)
                {
                    Session["UserID"] = manager.Id.ToString();
                    Session["UserName"] = manager.Name.ToString();
                    ViewBag.ManagerId = manager.Id;
                    return Redirect("/" + database);
                }
            }

             return View("~/Views/Shared/Error.cshtml");
        }
    }
}