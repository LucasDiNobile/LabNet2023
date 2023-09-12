using System.Web.Mvc;

namespace Lab.Practica6.MVC.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }

        public ActionResult Volver() 
        { 
            return RedirectToAction("Index", "Employee");
        }
    }
}