using System.Web.Mvc;

namespace SuperZapatos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Inicio";

            return View();
        }

        public ActionResult Admin()
        {
            ViewBag.Title = "Administración";
            return View();
        }
    }
}
