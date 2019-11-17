using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.Models
{
    public class Laboratorio
    {
        [Key]
        public int IdLaboratorio { get; set; }

        [StringLength(50)]
        [Required]
        public string Nombre { get; set; }

        [StringLength(500)]
        [Required]
        public string Descripcion { get; set; }
    }
}