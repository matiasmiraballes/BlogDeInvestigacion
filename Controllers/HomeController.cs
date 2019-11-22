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
        private ServicioSubscripcion SubscriptionsServices;

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

        private ServicioSubscripcion getSubscriptionService()
        {
            if (SubscriptionsServices == null)
            {
                this.SubscriptionsServices = new ServicioSubscripcion();
            }

            return this.SubscriptionsServices;
        }

        public ActionResult Index()
        {
            ServicioSubscripcion servicioSubscripcion = getSubscriptionService();
            List<Subscripcion> subscipciones = servicioSubscripcion.GetSubscripciones(User.Identity.Name);

            ServicioComentarios servicioComentarios = getCommentsService();
            List<Conversacion> conversaciones = servicioComentarios.ObtenerConversaciones();

            List<IElementoMuro> elementosMuro = new List<IElementoMuro>();


            foreach (Subscripcion s in subscipciones)
            {
                List<Conversacion> convRelacionadas = conversaciones.Where(c => c.IdLaboratorio == s.IdLaboratorio).ToList();

                foreach (var item in convRelacionadas)
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