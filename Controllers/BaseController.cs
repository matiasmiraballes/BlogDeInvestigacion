using BlogDeInvestigacion.Services;
using System.Web.Mvc;

namespace BlogDeInvestigacion.Controllers
{
    public class BaseController : Controller
    {
        private ServicioComentarios ServicioComentarios;
        private ServicioSuscripciones ServicioSuscripciones;
        private ServicioEventos ServicioEventos;
        private ServicioNoticias ServicioNoticias;
        private ServicioEncuestas ServicioEncuestas;
        private ServicioUsuarios ServicioUsuarios;
        private ServicioLaboratorios ServicioLaboratorio;

        protected ServicioLaboratorios getServicioLaboratorios()
        {
            if (ServicioLaboratorio == null)
            {
                this.ServicioLaboratorio = new ServicioLaboratorios();
            }

            return this.ServicioLaboratorio;
        }

        protected ServicioUsuarios getServicioUsuarios()
        {
            if (ServicioUsuarios == null)
            {
                this.ServicioUsuarios = new ServicioUsuarios();
            }

            return this.ServicioUsuarios;
        }

        protected ServicioNoticias getServicioNoticias()
        {
            if (ServicioNoticias == null)
            {
                this.ServicioNoticias = new ServicioNoticias();
            }

            return this.ServicioNoticias;
        }
        protected ServicioComentarios getServicioComentarios()
        {
            if (ServicioComentarios == null)
            {
                this.ServicioComentarios = new ServicioComentarios();
            }

            return this.ServicioComentarios;
        }

        protected ServicioSuscripciones getServicioSuscripciones()
        {
            if (ServicioSuscripciones == null)
            {
                this.ServicioSuscripciones = new ServicioSuscripciones();
            }

            return this.ServicioSuscripciones;
        }

        protected ServicioEventos getServicioEventos()
        {
            if (ServicioEventos == null)
            {
                this.ServicioEventos = new ServicioEventos();
            }

            return this.ServicioEventos;
        }

        protected ServicioEncuestas getServicioEncuestas()
        {
            if (ServicioEncuestas == null)
            {
                this.ServicioEncuestas = new ServicioEncuestas();
            }

            return this.ServicioEncuestas;
        }
    }
}