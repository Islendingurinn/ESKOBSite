using System.Web.Mvc;

namespace ESKOBSite.Controllers
{
    public class LogoutController : Controller
    {

        public ActionResult Index(string reference)
        {
            Session["UserID"] = "";
            Session["UserName"] = "";
            ViewBag.ManagerId = null;
            return Redirect("/" + reference); ;
        }
    }
}