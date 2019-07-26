using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogDeInvestigacion.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() => View();

        public ActionResult Eventos()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Consultas()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Estadisticas()
        {
            ViewBag.Message = "Estadisticas";

            return View();
        }

        public ActionResult Laboratorios()
        {
            ViewBag.Message = "Aprendé Nico!!";

            return View();
        }

        public ActionResult CrearUsuario()
        {
            ViewBag.Message = "Crear Usuario";

            return View();
        }

        public ActionResult Perfil()
        {
            ViewBag.Message = "Perfil";

            return View();
        }
    }
}