using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.Models
{
    public class Encuesta
    {
        [Key]
        public int IdEncuesta { get; set; }
        public int IdLaboratorio { get; set; }
        public Laboratorio Laboratorio { get; set; }
        public string Titulo { get; set; }
        public IList<Pregunta> Preguntas { get; set; }
    }
}