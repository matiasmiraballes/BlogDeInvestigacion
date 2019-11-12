using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.Models
{
    public class Conversacion
    {
        [Key]
        public int IdConversacion { get; set; }

        public int IdLaboratorio { get; set; }

        public DateTime TiempoCreacion { get; set; }

        public IList<Comentario> Comentarios { get; set; }
    }
}