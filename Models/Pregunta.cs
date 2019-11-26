using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.Models
{
    public class Pregunta
    {
        [Key]
        public int IdPregunta { get; set; }
        public int IdEncuesta { get; set; }
        public Encuesta Encuesta { get; set; }
        public string Descripcion { get; set; }
    }
}