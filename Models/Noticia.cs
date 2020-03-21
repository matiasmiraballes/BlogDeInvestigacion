using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.Models
{
    public class Noticia : IElementoMuro
    {
        /* PKs - FKs */
        [Key]
        public int IdNoticia { get; set; }

        [Display(Name = "Laboratorio")]
        public Laboratorio Laboratorio { get; set; }
        public int IdLaboratorio { get; set; }

        /* Datos */
        [Required]
        [MaxLength(50)]
        public string Titulo { get; set; }

        [MaxLength(500)]
        public string Descripcion { get; set; }

        /* Interface IElementoMuro */
        public DateTime FechaCreacion { get; set; }
        public string Username { get; set; }

        public DateTime GetFechaDePublicacion()
        {
            return FechaCreacion;
        }

        public string GetNombreDeLaboratorio()
        {
            return this.Laboratorio.Nombre;
        }

        public string GetTipoDePublicacion()
        {
            return TipoPublicacion.Noticia;
        }

        public string GetUsername()
        {
            return this.Username;
        }
    }
}