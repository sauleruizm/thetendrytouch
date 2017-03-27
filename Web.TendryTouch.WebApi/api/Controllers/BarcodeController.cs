using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.TendryTouch.Models;

namespace Web.TendryTouch.WebApi.api.Controllers
{
    public class BarcodeController : BaseApiController
	{
		#region -- Private member variables --
		#endregion -- Private member variables --;


		#region -- Constructors, destructors, and finalizers --
		#endregion -- Constructors, destructors, and finalizers --;


		#region -- Properties --
		#endregion -- Properties --;


		#region -- Methods --

			
			public IHttpActionResult AddBarcodeEntity(BarcodeHistory entity)
			{
				return Ok();
			}

		#endregion -- Methods --;

	}
}
