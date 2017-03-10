using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using Web.TendryTouch.WebApi;

[assembly:OwinStartupAttribute(typeof(Startup))]
namespace Web.TendryTouch.WebApi
{
	public partial class Startup
	{
		/// <summary>
		/// Register 
		/// </summary>
		/// <param name="app"></param>
		public void Configuration(IAppBuilder app)
		{
			GlobalConfiguration.Configure(WebApiConfig.Register);
		}
	}
}