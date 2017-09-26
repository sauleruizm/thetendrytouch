using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Web.TendryTouch.Inventory.Controllers
{
	public class BaseMvcController: Controller
	{
		#region -- Properties --

			public string WebApiBaseUrl
			{
				get
				{
					return ConfigurationManager.AppSettings.Get("WebApiBaseUrl");
				}
			}

		#endregion -- Properties --;

		#region -- Methods --

			/// <summary>
			/// Do the get request to webapi service
			/// </summary>
			/// <param name="ctrlActPra">controller with action and parameters</param>
			/// <returns></returns>
			protected async Task<HttpResponseMessage> Get(string controller, string action)
			{
				var url = new Uri(string.Concat(WebApiBaseUrl, "/", controller, "/",action));
				using (HttpClient client = new HttpClient())
				{
					return await client.GetAsync(url);
				}
			}

		#endregion -- Methods --;


	}
}