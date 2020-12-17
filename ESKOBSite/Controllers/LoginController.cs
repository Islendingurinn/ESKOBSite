using ESKOBSite.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ESKOBSite.Controllers
{
    public class LoginController : Controller
    {

        public async Task<ActionResult> Index(string reference)
        {
            var tresponse = await API.GET("/tenants/" + reference);
            Tenant tenant;
            if (!tresponse.IsSuccessStatusCode)
                return View("~/Views/Shared/Error.cshtml");
            else
                tenant = await tresponse.Content.ReadAsAsync<Tenant>();

            ViewBag.Name = tenant.Name;
            ViewBag.Reference = tenant.Reference;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(LoginManager objUser, string reference)
        {
            if (ModelState.IsValid)
            {
                Manager manager = null;
                var result = await API.POST("/" + reference + "/login", objUser);
                if (result.IsSuccessStatusCode)
                    manager = await result.Content.ReadAsAsync<Manager>();

                if (manager != null)
                {
                    Session["UserID"] = manager.Id.ToString();
                    Session["UserName"] = manager.Name.ToString();
                    ViewBag.ManagerId = manager.Id;
                    return Redirect("/" + reference);
                }
            }

             return View("~/Views/Shared/Error.cshtml");
        }
    }
}