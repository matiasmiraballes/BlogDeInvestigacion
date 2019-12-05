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

        public ActionResult Encuesta(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            Encuesta encuesta = getServicioEncuestas().ObtenerEncuesta((int)id);

            return View(encuesta);
        }

        public ActionResult GuardarEncuesta(int idEncuesta, int[] IdPregunta, int[] Respuesta)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }


            ServicioEncuestas servicioEncuestas = getServicioEncuestas();

            List<Respuesta> respuestas = new List<Respuesta>();

            for (int i = 0; i < IdPregunta.Length; i++)
            {
                respuestas.Add(new Respuesta
                {
                    IdPregunta = IdPregunta[i],
                    Detalle = Respuesta[i]
                });
            }

            EncuestaCompletada encCompletada = new EncuestaCompletada
            {
                IdEncuesta = idEncuesta,
                Usuario = User.Identity.Name
            };

            servicioEncuestas.GuardarRespuestas(respuestas);

            servicioEncuestas.GuardarEncuestaCompletada(encCompletada);

            return RedirectToAction("Index");
        }
    }
}