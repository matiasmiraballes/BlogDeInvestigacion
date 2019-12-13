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

            if (User.IsInRole(UserRoles.Docente))
            {
                // Solo devolver las encuestas de sus laboratorios a cargo

                var idsLabACargo = getServicioLaboratorios()
                                        .LaboratoriosACargoByUsername(User.Identity.Name)
                                        .Select(l => l.IdLaboratorio)
                                        .ToList();

                encuestas = getServicioEncuestas()
                                .ObtenerEncuestas()
                                .Where(e => idsLabACargo.Contains(e.IdLaboratorio))
                                .ToList();
            }
            else
            {
                // Si el usuario es admin, mostrar todas las encuestas

                encuestas = getServicioEncuestas().ObtenerEncuestas();
            }

            return View(encuestas);
        }

        public ActionResult Resultados(int? idEncuesta)
        {
            if (idEncuesta != null)
            {
                RedirectToAction("Index");
            }


            return View();
        }
    }
}