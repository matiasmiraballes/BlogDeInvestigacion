using BlogDeInvestigacion.Data_Management;
using BlogDeInvestigacion.Models;
using BlogDeInvestigacion.Services;
using BlogDeInvestigacion.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
                    ElementosMuro = new List<IElementoMuro>(),
                    ListaDocentes = getServicioUsuarios().ObtenerUsuarios(UserRoles.Docente)
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

            ServicioEncuestas servicioEncuestas = getServicioEncuestas();
            List<Encuesta> encuestas = servicioEncuestas.ObtenerEncuestas();

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
                    List<Encuesta> encuestasRelacionadas = encuestas.Where(e => e.IdLaboratorio == s.IdLaboratorio).ToList();

                    foreach (Encuesta item in encuestasRelacionadas)
                    {
                        elementosMuro.Add(item);
                    }
                }
            }

            var orderedElementos = elementosMuro.OrderByDescending(e => e.GetFechaDePublicacion()).ToList();

            var homeViewModel = new HomeViewModel()
            {
                ElementosMuro = orderedElementos,
                ListaDocentes = getServicioUsuarios().ObtenerUsuarios(UserRoles.Docente)
            };

            return View(homeViewModel);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult CrearDocente(string Usuario, string Contraseña)
        {
            BlogContext context = new BlogContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser();
            user.UserName = Usuario;
            user.Email = Usuario;

            string userPWD = Contraseña;

            var chkUser = UserManager.Create(user, userPWD);

            if (chkUser.Succeeded)
            {
                UserManager.AddToRole(user.Id, UserRoles.Docente);
            }

            return Redirect(Request.UrlReferrer.ToString());
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public ActionResult BorrarDocente(string Usuario)
        {
            getServicioUsuarios().EliminarUsuario(Usuario);

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}