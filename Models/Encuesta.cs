using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.Models
{
    public class Encuesta : IElementoMuro
    {
        [Key]
        public int IdEncuesta { get; set; }
        public int IdLaboratorio { get; set; }
        public Laboratorio Laboratorio { get; set; }
        public string Titulo { get; set; }
        public IList<Pregunta> Preguntas { get; set; }

        public DateTime FechaPublicacion { get; set; }

        public DateTime GetFechaDePublicacion()
        {
            return this.FechaPublicacion;
        }

        public string GetTipoDePublicacion()
        {
            return TipoPublicacion.Encuesta;
        }
    }
}