using System.Web.Http;
using Web.TendryTouch.WebApi.Data;

namespace Web.TendryTouch.WebApi.api.Controllers
{
    public class BaseApiController : ApiController
	{
		#region -- Properties --
			/// <summary>
			/// Data manager
			/// </summary>
			public MySqlContext DataMgr { get; set; }

		#endregion -- Properties --;
	}
}
