using System.Web.Mvc;

namespace YourProjectName.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Login", "AdminCMS");
        }
    }
}
