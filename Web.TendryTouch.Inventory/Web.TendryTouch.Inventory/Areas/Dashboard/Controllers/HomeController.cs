using System.Web.Mvc;

namespace Web.TendryTouch.Inventory.Areas.Dashboard.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Dashboard()
        {
            return View();
        }

		public PartialViewResult PartialBoard()
		{
			return PartialView();
		}
	}
}