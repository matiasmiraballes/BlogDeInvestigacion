using BlogDeInvestigacion.Services;
using System.Web.Mvc;

namespace BlogDeInvestigacion.Controllers
{
    public class BaseController : Controller
    {
        private ServicioComentarios CommentsSerives;
        private ServicioSubscripcion SubscriptionService;
        private ServicioEvento EventsService;
        private ServicioNoticia NewsSerives;

        protected ServicioNoticia getNewsService()
        {
            if (NewsSerives == null)
            {
                this.NewsSerives = new ServicioNoticia();
            }

            return this.NewsSerives;
        }
        protected ServicioComentarios getCommentsService()
        {
            if (CommentsSerives == null)
            {
                this.CommentsSerives = new ServicioComentarios();
            }

            return this.CommentsSerives;
        }

        protected ServicioSubscripcion getSubscriptionService()
        {
            if (SubscriptionService == null)
            {
                this.SubscriptionService = new ServicioSubscripcion();
            }

            return this.SubscriptionService;
        }

        protected ServicioEvento getEventService()
        {
            if (EventsService == null)
            {
                this.EventsService = new ServicioEvento();
            }

            return this.EventsService;
        }
    }
}