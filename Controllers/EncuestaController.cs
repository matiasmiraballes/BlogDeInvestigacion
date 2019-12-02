using BlogDeInvestigacion.Models;
using BlogDeInvestigacion.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogDeInvestigacion.Controllers
{
    public class EncuestaController : BaseController
    {
        public ActionResult Index()
        {
            ServicioEncuestas servicioEncuestas = getServicioEncuestas();
            List<Encuesta> encuestas = servicioEncuestas.ObtenerEncuestas();

            return View(encuestas);
        }
    }
}