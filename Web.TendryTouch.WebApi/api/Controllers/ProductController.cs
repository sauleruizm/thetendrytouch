using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web.TendryTouch.Models;
using Web.TendryTouch.WebApi.Data;
using Web.TendryTouch.WebApi.Data.RepositoryPattern;

namespace Web.TendryTouch.WebApi.api.Controllers
{
    public class ProductController : BaseApiController
    {
		protected readonly IRepository _repository;

		public ProductController()
		{
			//_repository = new EntityFrameworkRepository<MySqlContext>
			//	(new MySqlContext(ConfigurationManager.ConnectionStrings["myDbEntities"].ConnectionString));
			_repository = new EntityFrameworkRepository<MySqlContext>(new MySqlContext());
		}

		public ProductController(IRepository repository)
		{
			_repository = repository;
		}

		/// <summary>
		/// Get all products
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IHttpActionResult GetAll()
		{
			return Ok(_repository.GetAll<Product>().AsQueryable());
		}
    }
}
