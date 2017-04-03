using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Owin;
using Owin;
using Web.TendryTouch.Inventory;
using Web.TendryTouch.Inventory.Areas.Dashboard;
using Web.TendryTouch.Inventory.Areas.Inventory;

[assembly: OwinStartupAttribute(typeof(Startup))]
namespace Web.TendryTouch.Inventory
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			AreaRegistration.RegisterAllAreas();
			//RouteConfig.RegisterRoutes(RouteTable.Routes);			
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}


	}
}