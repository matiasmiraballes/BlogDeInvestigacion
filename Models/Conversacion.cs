using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.Models
{
    public class Conversacion : IElementoMuro
    {
        [Key]
        public int IdConversacion { get; set; }

        public Laboratorio Laboratorio { get; set; }
        public int IdLaboratorio { get; set; }


        public IList<Comentario> Comentarios { get; set; }


        public DateTime TiempoCreacion { get; set; }
        public string Username { get; set; }

        public DateTime GetFechaDePublicacion()
        {
            return this.TiempoCreacion;
        }

        public string GetNombreDeLaboratorio()
        {
            return this.Laboratorio.Nombre;
        }

        public string GetTipoDePublicacion()
        {
            return TipoPublicacion.Conversacion;
        }

        public string GetUsername()
        {
            return this.Username;
        }
    }
}