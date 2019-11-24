using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion
{
    public static class TipoPublicacion
    {
        public const string Conversacion = "Conversacion";
        public const string Evento = "Evento";
        public const string Noticia = "Noticia";
        public const string Encuesta = "Encuesta";
        public const string Todos = "Todos";
    }

    public static class TipoOpcion
    {
        public const string Action = "action";
        public const string OpenModal = "modal";
    }
}