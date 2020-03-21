using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.Models
{
    [Table("Eventos")]
    public class Evento : IElementoMuro
    {
        [Key]
        public int IdEvento { get; set; }

        public Laboratorio Laboratorio { get; set; }
        public int IdLaboratorio { get; set; }


        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        [Required]
        public DateTime Inicio { get; set; }

        [Required]
        public DateTime Fin { get; set; }


        public DateTime FechaPublicacion { get; set; }
        public string Username { get; set; }

        public DateTime GetFechaDePublicacion()
        {
            return FechaPublicacion;
        }

        public string GetNombreDeLaboratorio()
        {
            return this.Laboratorio.Nombre;
        }

        public string GetTipoDePublicacion()
        {
            return TipoPublicacion.Evento;
        }

        public string GetUsername()
        {
            return this.Username;
        }
    }
}