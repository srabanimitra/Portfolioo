using System.Web.Mvc;

namespace Portfolioo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(); // Renders Index.cshtml
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
