using BlogDeInvestigacion.Models;
using BlogDeInvestigacion.Services;
using BlogDeInvestigacion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogDeInvestigacion.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ServicioSubscripcion servicioSubscripcion = getSubscriptionService();
            List<Subscripcion> subscipciones = servicioSubscripcion.GetSubscripciones(User.Identity.Name);

            ServicioComentarios servicioComentarios = getCommentsService();
            List<Conversacion> conversaciones = servicioComentarios.ObtenerConversaciones();

            ServicioNoticia servicioNoticia = getNewsService();
            List<Noticia> noticias = servicioNoticia.ObtenerNoticias();

            ServicioEvento servicioEvento = getEventService();
            List<Evento> eventos = servicioEvento.ObtenerEventos();

            List<IElementoMuro> elementosMuro = new List<IElementoMuro>();


            foreach (Subscripcion s in subscipciones)
            {
                List<Conversacion> convRelacionadas = conversaciones.Where(c => c.IdLaboratorio == s.IdLaboratorio).ToList();

                foreach (Conversacion item in convRelacionadas)
                {
                    elementosMuro.Add(item);
                }

                List<Noticia> noticiasRelacionadas = noticias.Where(n => n.IdLaboratorio == s.IdLaboratorio).ToList();

                foreach (Noticia item in noticiasRelacionadas)
                {
                    elementosMuro.Add(item);
                }

                List<Evento> eventosRelacionados = eventos.Where(e => e.IdLaboratorio == s.IdLaboratorio).ToList();

                foreach (Evento item in eventosRelacionados)
                {
                    elementosMuro.Add(item);
                }
            }

            var orderedElementos = elementosMuro.OrderByDescending(e => e.GetFechaDePublicacion()).ToList();

            var homeViewModel = new HomeViewModel()
            {
                ElementosMuro = orderedElementos
            };

            return View(homeViewModel);
        }

        [HttpPost]
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

        [Authorize(Roles = "Administrador")]
        public ActionResult Estadisticas()
        {
            ViewBag.Message = "Estadisticas";

            return View();
        }

        public ActionResult Perfil()
        {
            ViewBag.Message = "Perfil";

            return View();
        }
    }
}