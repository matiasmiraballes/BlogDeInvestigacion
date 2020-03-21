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


        public string Username { get; set; }
        public DateTime FechaPublicacion { get; set; }

        public DateTime GetFechaDePublicacion()
        {
            return this.FechaPublicacion;
        }

        public string GetNombreDeLaboratorio()
        {
            return this.Laboratorio.Nombre;
        }

        public string GetTipoDePublicacion()
        {
            return TipoPublicacion.Encuesta;
        }

        public string GetUsername()
        {
            return this.Username;
        }
    }
}