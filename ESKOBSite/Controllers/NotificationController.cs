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
    public class NotificationController : Controller
    {
        public ActionResult Notifications(string database)
        {

            List<Notification> notifs = null;
            int id = Int32.Parse(Session["UserId"] as string);
            var response = API.GET("/" + database + "/notifications/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                notifs = response.Content.ReadAsAsync<List<Notification>>().Result;
            }

            ViewBag.Reference = database;
            return PartialView(notifs);
        }
    }
}