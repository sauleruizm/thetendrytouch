using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Web.TendryTouch.Inventory.Controllers;
using Web.TendryTouch.Models;
using PagedList;

namespace Web.TendryTouch.Inventory.Areas.Inventory.Controllers
{
	public class CategoryController : BaseMvcController
	{
		#region -- Methods --

			//
			// GET: /Inventory/Category/
			public PartialViewResult Index(int? page)
			{
				var response = base.Get("category", "getall");
				IQueryable<Category> returnedListOfCategories;

				if (response.IsCompleted && response.Result.StatusCode == HttpStatusCode.OK)
				{
					var returnedObjects = response.Result.Content.ReadAsStringAsync().Result;
					returnedListOfCategories = ((List<Category>)JsonConvert
						.DeserializeObject(returnedObjects, typeof(List<Category>)))
						.AsQueryable();

					var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
					var onePageOfCategories = returnedListOfCategories.ToPagedList(pageNumber, 25); // will only contain 25 products max because of the pageSize

					ViewBag.onePageOfCategories = onePageOfCategories;
				}
				else
				{
					var pageNumber = page ?? 1;
					ViewBag.onePageOfCategories = new List<Category>().AsQueryable().ToPagedList<Category>(pageNumber, 25);
				}
				return PartialView(ViewBag.onePageOfCategories);
			}

			//
			// GET: /Inventory/Category/Details/5
			public ActionResult Details(int id)
			{
				return View();
			}

			//
			// GET: /Inventory/Category/Create
			public ActionResult Create()
			{
				return View();
			}

			//
			// POST: /Inventory/Category/Create
			[HttpPost]
			public ActionResult Create(FormCollection collection)
			{
				try
				{
					// TODO: Add insert logic here

					return RedirectToAction("Index");
				}
				catch
				{
					return View();
				}
			}

			//
			// GET: /Inventory/Category/Edit/5
			public ActionResult Edit(int id)
			{
				return View();
			}

			//
			// POST: /Inventory/Category/Edit/5
			[HttpPost]
			public ActionResult Edit(int id, FormCollection collection)
			{
				try
				{
					// TODO: Add update logic here

					return RedirectToAction("Index");
				}
				catch
				{
					return View();
				}
			}

			//
			// GET: /Inventory/Category/Delete/5
			public ActionResult Delete(int id)
			{
				return View();
			}

			//
			// POST: /Inventory/Category/Delete/5
			[HttpPost]
			public ActionResult Delete(int id, FormCollection collection)
			{
				try
				{
					// TODO: Add delete logic here

					return RedirectToAction("Index");
				}
				catch
				{
					return View();
				}
			}

		#endregion -- Methods --;
	}
}
