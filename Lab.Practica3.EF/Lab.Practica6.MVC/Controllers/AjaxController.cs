using System.Web.Mvc;

namespace Lab.Practica6.MVC.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VolverInicio()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
