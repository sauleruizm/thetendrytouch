using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Web.TendryTouch.Inventory
{
	public class BundleConfig
	{
		#region -- Methods --

			public static void RegisterBundles(BundleCollection bundles)
			{
				//scripts

				bundles.Add(new ScriptBundle("~/js")
					.Include(
						"~/Scripts/jquery-{version}.js", 
						"~/Scripts/bootstrap.js",
						"~/Scripts/metisMenu.js",
						"~/Scripts/sb-admin-2.js",
						"~/Scripts/knockout-{version}.debug.js",
						"~/Scripts/sammy-{version}.js"
					));


				//css
				bundles.Add(new StyleBundle("~/css").Include(
					"~/Content/bootstrap.css",
					"~/Content/fontawesome/font-awesome.css",
					"~/Content/metisMenu.css",
					"~/Content/sb-admin-2.css"
					));

				//css
				bundles.Add(new StyleBundle("~/css/PagedList").Include("~/Content/PagedList.css"));
			}

		#endregion -- Methods --;

	}
}