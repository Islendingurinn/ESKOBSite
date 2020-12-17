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
    public class LogoutController : Controller
    {

        public async Task<ActionResult> Index(string database)
        {
            Session["UserID"] = "";
            Session["UserName"] = "";
            ViewBag.ManagerId = null;
            return Redirect("/" + database); ;
        }
    }
}