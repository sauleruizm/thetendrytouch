using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.TendryTouch.Inventory.Controllers
{
    public class StockController : Controller
    {
        //
        // GET: /Stock/
        public ActionResult Index(int id)
        {
            return View();
        }

		
		public ActionResult Create(int productId)
		{

			return View();
		}
	}
}