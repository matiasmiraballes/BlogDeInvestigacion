using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.Models
{
    public class Comentario
    {
        [Key]
        public int IdComentario { get; set; }

        public string NombreDeUsuario { get; set; }

        public DateTime TiempoCreacion { get; set; }

        public string Texto { get; set; }

        //Clave Foranea para Conversacion
        public int IdConversacion { get; set; }
        public Conversacion Conversacion { get; set; }
    }
}