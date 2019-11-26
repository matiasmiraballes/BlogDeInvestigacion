using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.Models
{
    public class Respuesta
    {
        [Key]
        public int IdRespuesta { get; set; }
        public int IdEncuesta { get; set; }
        public Encuesta Encuesta { get; set; }
        public int IdPregunta { get; set; }
        public Pregunta Pregunta { get; set; }
        public int Detalle { get; set; }
    }
}
