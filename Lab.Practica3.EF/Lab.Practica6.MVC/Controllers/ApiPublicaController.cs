using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.Practica6.MVC.Controllers
{
    public class ApiPublicaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VolverInicio()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Recargar()
        {
            return RedirectToAction("Index");
        }
    }
}