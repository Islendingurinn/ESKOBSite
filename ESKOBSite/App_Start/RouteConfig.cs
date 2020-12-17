using System.Web.Mvc;
using System.Web.Routing;

namespace ESKOBSite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Setup",
                url: "{reference}/{controller}/{action}/{id}",
                defaults: new { reference = "", controller = "ideas", action = "index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{id}",
                defaults: new { controller = "ideas", action = "index", id = UrlParameter.Optional }
            );
        }
    }
}
