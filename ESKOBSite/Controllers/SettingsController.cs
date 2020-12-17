using ESKOBSite.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ESKOBSite.Controllers
{
    public class SettingsController : Controller
    {
        public ActionResult Settings(string reference)
        {
            ViewBag.Reference = reference;
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Settings(PasswordManager objUser, string reference)
        {
            if (ModelState.IsValid)
            {
                LoginManager lm = new LoginManager() 
                { 
                    Name = Session["UserName"] as string, 
                    Password = objUser.Old 
                };

                var result = await API.POST("/" + reference + "/login", lm);

                Manager manager = null;
                if (result.IsSuccessStatusCode)
                    manager = await result.Content.ReadAsAsync<Manager>();

                if (manager != null)
                {
                    var change = new 
                    { 
                        Password = objUser.New 
                    };

                    await API.PUT("/" + reference + "/managers/" + Int32.Parse(Session["UserID"] as string), change);
                    
                    return Redirect("/" + reference);
                }
            }

            ViewBag.Message = "Incorrect password!";
            return PartialView();
        }
    }
}