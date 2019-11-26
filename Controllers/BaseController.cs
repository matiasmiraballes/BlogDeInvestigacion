using BlogDeInvestigacion.Services;
using System.Web.Mvc;

namespace BlogDeInvestigacion.Controllers
{
    public class BaseController : Controller
    {
        private ServicioComentarios CommentsService;
        private ServicioSubscripcion SubscriptionService;
        private ServicioEvento EventsService;
        private ServicioNoticia NewsService;
        private ServicioEncuesta QuestionnairesService;

        protected ServicioNoticia getNewsService()
        {
            if (NewsService == null)
            {
                this.NewsService = new ServicioNoticia();
            }

            return this.NewsService;
        }
        protected ServicioComentarios getCommentsService()
        {
            if (CommentsService == null)
            {
                this.CommentsService = new ServicioComentarios();
            }

            return this.CommentsService;
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

        protected ServicioEncuesta getQuestionnaireService()
        {
            if (QuestionnairesService == null)
            {
                this.QuestionnairesService = new ServicioEncuesta();
            }

            return this.QuestionnairesService;
        }
    }
}