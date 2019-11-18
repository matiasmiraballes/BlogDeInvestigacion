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
    public class HomeController : Controller
    {
        private ServicioComentarios CommentsSerives;
        private ServicioEvento EventsServices;

        private ServicioComentarios getCommentsService()
        {
            if (CommentsSerives == null)
            {
                this.CommentsSerives = new ServicioComentarios();
            }

            return this.CommentsSerives;
        }

        private ServicioEvento getEventsService()
        {
            if (EventsServices == null)
            {
                this.EventsServices = new ServicioEvento();
            }

            return this.EventsServices;
        }

        public ActionResult Index()
        {
            var servicioComentarios = getCommentsService();

            var comentarios = servicioComentarios.ObtenerConversaciones();

            var elementosMuro = new List<IElementoMuro>();

            foreach (var c in comentarios)
            {
                elementosMuro.Add(c);
            }

            var orderedElementos = elementosMuro.OrderByDescending(e => e.GetFechaDePublicacion()).ToList();

            var homeViewModel = new HomeViewModel()
            {
                ElementosMuro = orderedElementos
            };

            return View();
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