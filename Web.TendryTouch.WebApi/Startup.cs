using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using Web.TendryTouch.WebApi;
using Web.TendryTouch.WebApi.Migrations;
using Web.TendryTouch.WebApi.Models;

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
			Database.SetInitializer<MySqlContext>(new MySqlDatabaseInitialization());
		}
	}
}