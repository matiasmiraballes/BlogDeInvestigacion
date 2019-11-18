using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.Models
{
    public class Noticia
    {
        [Key]
        public int IdNoticia { get; set; }

        [Display(Name = "Laboratorio")]
        public Laboratorio laboratorio { get; set; }

        [Required]
        [MaxLength(50)]
        public string Titulo { get; set; }

        [MaxLength(500)]
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}