using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.TendryTouch.Models;
using Web.TendryTouch.WebApi.Models;
using Web.TendryTouch.WebApi.Models.RepositoryPattern;

namespace Web.TendryTouch.WebApi.api.Controllers
{
    public class ProductController : BaseApiController
    {
		/// <summary>
		/// Get all products
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IHttpActionResult GetAll()
		{
			return Ok(base._repository.GetAll<Product>().AsQueryable());
		}
    }
}
