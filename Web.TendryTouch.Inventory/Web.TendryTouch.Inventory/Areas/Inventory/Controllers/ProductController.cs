using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using Web.TendryTouch.Models;
using PagedList;
using System.Net;
using Web.TendryTouch.Inventory.Controllers;

namespace Web.TendryTouch.Inventory.Areas.Inventory.Controllers
{
	public class ProductController : BaseMvcController
	{
		#region -- Methods --

			//
			// GET: /Inventory/
			public ActionResult List(int? page)
			{

				var response = base.Get("product", "getall");
				IQueryable<Product> returnedListOfProducts;

				if (response.IsCompleted && response.Result.StatusCode == HttpStatusCode.OK)
				{	
					var returnedObjects = response.Result.Content.ReadAsStringAsync().Result;
						returnedListOfProducts = ((List<Product>)JsonConvert
							.DeserializeObject(returnedObjects, typeof(List<Product>)))
							.AsQueryable();

					var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
					var onePageOfProducts = returnedListOfProducts.ToPagedList(pageNumber, 25); // will only contain 25 products max because of the pageSize

					ViewBag.OnePageOfProducts = onePageOfProducts;
				}
				else
				{
					var pageNumber = page ?? 1;
					ViewBag.OnePageOfProducts = new List<Product>().AsQueryable().ToPagedList<Product>(pageNumber,25);
				}
				return View();
			}

			[HttpGet]
			public ActionResult Add()
			{
				return View();
			}

			/// <summary>
			/// Recive information to save
			/// </summary>
			/// <param name="product"></param>
			/// <returns></returns>
			[HttpPost]
			public ActionResult Create(Product product)
			{
				if (ModelState.IsValid)
				{

				}
				return View();
			}

			[HttpPut]
			public ActionResult Update()
			{
				return View();
			}
		#endregion -- Methods --;
	}
}