﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Capitu.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Mapa", action = "Index", id = UrlParameter.Optional }
                //defaults: new { controller = "Home", action = "HotSite", id = UrlParameter.Optional }
                //defaults: new { controller = "Fornecedor", action = "Index", id = UrlParameter.Optional }
                //defaults: new { controller = "Fornecedor", action = "Create", id = UrlParameter.Optional }
            );
        }
    }
}