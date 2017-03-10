using System.Web.Mvc;

namespace Web.TendryTouch.Inventory.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Dashboard()
        {
            return View();
        }
	}
}