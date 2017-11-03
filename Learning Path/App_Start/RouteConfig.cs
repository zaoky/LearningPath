using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Learning_Path
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            //routes.MapRoute("MoviesByReleaseDate", "movies/released/{year}/{month}", new { Controller = "Movies", Action = "ByReleaseDate"},
            //   // new { year = @"\d{4}", month = @"\d{2}"}); for limite year just at four digits
            //    new { year = @"2015|2016", month = @"\d{2}"}); // limite just for 2015 or 2016 years

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
