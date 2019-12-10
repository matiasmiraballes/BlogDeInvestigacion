using BlogDeInvestigacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogDeInvestigacion.Controllers
{
    [Authorize(Roles = UserRoles.AdministradorODocente)]
    public class EstadisticasController : BaseController
    {
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }


            List<Encuesta> encuestas = new List<Encuesta>();

            if (User.Identity.IsAuthenticated)
            {
                encuestas = getServicioEncuestas().ObtenerEncuestasSinCompletar(User.Identity.Name);
            }
            else
            {
                encuestas = getServicioEncuestas().ObtenerEncuestas();
            }

            return View(encuestas);
        }
    }
}