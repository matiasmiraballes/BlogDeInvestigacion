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
        public ActionResult Index(string parametro)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View(new HomeViewModel()
                {
                    ElementosMuro = new List<IElementoMuro>()
                });
            }

            ServicioSuscripciones servicioSuscripciones = getServicioSuscripciones();
            List<Suscripcion> suscripciones = servicioSuscripciones.GetSuscripciones(User.Identity.Name);

            ServicioComentarios servicioComentarios = getServicioComentarios();
            List<Conversacion> conversaciones = servicioComentarios.ObtenerConversaciones();

            ServicioNoticias servicioNoticias = getServicioNoticias();
            List<Noticia> noticias = servicioNoticias.ObtenerNoticias();

            ServicioEventos servicioEventos = getServicioEventos();
            List<Evento> eventos = servicioEventos.ObtenerEventos();

            List<IElementoMuro> elementosMuro = new List<IElementoMuro>();

            if (parametro == null || parametro == "")
            {
                parametro = TipoPublicacion.Todos;
            }

            foreach (Suscripcion s in suscripciones)
            {
                if (parametro == TipoPublicacion.Conversacion || parametro == TipoPublicacion.Todos)
                {
                    List<Conversacion> convRelacionadas = conversaciones.Where(c => c.IdLaboratorio == s.IdLaboratorio).ToList();

                    foreach (Conversacion item in convRelacionadas)
                    {
                        elementosMuro.Add(item);
                    }
                }

                if (parametro == TipoPublicacion.Noticia || parametro == TipoPublicacion.Todos)
                {
                    List<Noticia> noticiasRelacionadas = noticias.Where(n => n.IdLaboratorio == s.IdLaboratorio).ToList();

                    foreach (Noticia item in noticiasRelacionadas)
                    {
                        elementosMuro.Add(item);
                    }
                }

                if (parametro == TipoPublicacion.Evento || parametro == TipoPublicacion.Todos)
                {
                    List<Evento> eventosRelacionados = eventos.Where(e => e.IdLaboratorio == s.IdLaboratorio).ToList();

                    foreach (Evento item in eventosRelacionados)
                    {
                        elementosMuro.Add(item);
                    }
                }

                if (parametro == TipoPublicacion.Encuesta || parametro == TipoPublicacion.Todos)
                {

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