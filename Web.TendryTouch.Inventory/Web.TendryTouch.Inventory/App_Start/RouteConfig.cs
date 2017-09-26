﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web.TendryTouch.Inventory
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(name: "Empty", url: "",
				defaults: new {area ="dashboard", controller = 
                    "home", action = "dashboard", id = UrlParameter.Optional }
			);
			routes.MapRoute(name: "Inventory", url: "inventory/{controller}/{action}/{id}",
				defaults: new { action = "Category", id = UrlParameter.Optional });
		}
	}
}
