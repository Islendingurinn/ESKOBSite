using ESKOBSite.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace ESKOBSite.Controllers
{
    public class NotificationController : Controller
    {
        public ActionResult Notifications(string reference)
        {
            List<Notification> notifs = null;
            int id = Int32.Parse(Session["UserId"] as string);
            var response = API.GETSYNC("/" + reference + "/notifications/" + id);
            if (response.IsSuccessStatusCode)
                notifs = response.Content.ReadAsAsync<List<Notification>>().Result;
           
            ViewBag.Reference = reference;
            return PartialView(notifs);
        }
    }
}