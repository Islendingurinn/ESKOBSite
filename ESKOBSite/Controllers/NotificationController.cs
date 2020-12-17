using ESKOBSite.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ESKOBSite.Controllers
{
    public class NotificationController : Controller
    {
        public async Task<ActionResult> Notifications(string reference)
        {

            List<Notification> notifs = null;
            int id = Int32.Parse(Session["UserId"] as string);
            var response = await API.GET("/" + reference + "/notifications/" + id);
            if (response.IsSuccessStatusCode)
                notifs = await response.Content.ReadAsAsync<List<Notification>>();

            ViewBag.Reference = reference;
            return PartialView(notifs);
        }
    }
}