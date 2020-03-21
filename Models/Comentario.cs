using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.Models
{
    public class Comentario : IElementoMuro
    {
        /* PKs - FKs */
        [Key]
        public int IdComentario { get; set; }

        public int IdConversacion { get; set; }
        public Conversacion Conversacion { get; set; }

        /* Datos */
        public string Texto { get; set; }

        /* Interface IElementoMuro */
        public DateTime TiempoCreacion { get; set; }
        public string NombreDeUsuario { get; set; }

        public DateTime GetFechaDePublicacion()
        {
            return TiempoCreacion;
        }

        public string GetNombreDeLaboratorio()
        {
            return this.Conversacion.Laboratorio.Nombre;
        }

        public string GetTipoDePublicacion()
        {
            return TipoPublicacion.Comentario;
        }

        public string GetUsername()
        {
            return this.NombreDeUsuario;
        }
    }
}