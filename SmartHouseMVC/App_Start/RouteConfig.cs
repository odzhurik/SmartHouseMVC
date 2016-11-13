using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SmartHouseMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "AddApp",
                url: "Applience/Add/{app}",
                defaults: new { controller = "Applience", action = "Add" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{name}",
                defaults: new { controller = "Applience", action = "Index", id = UrlParameter.Optional, name=UrlParameter.Optional }
            );
        }
    }
}
