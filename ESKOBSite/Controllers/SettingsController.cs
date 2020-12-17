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
    public class SettingsController : Controller
    {
        public async Task<ActionResult> Settings(string database)
        {
            ViewBag.Reference = database;
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Settings(PasswordManager objUser, string database)
        {
            if (ModelState.IsValid)
            {
                LoginManager lm = new LoginManager() { Name = Session["UserName"] as string, Password = objUser.Old };
                var result = await API.POST("/" + database + "/login", lm);

                Manager manager = null;
                if (result.IsSuccessStatusCode)
                {
                    manager = await result.Content.ReadAsAsync<Manager>();
                }

                if (manager != null)
                {
                    var change = new { Password = objUser.New };
                    await API.PUT("/" + database + "/managers/" + Int32.Parse(Session["UserID"] as string), change);
                    return
                        Redirect("/" + database);
                }
            }

            ViewBag.Message = "Incorrect password!";
            return PartialView();
        }
    }
}