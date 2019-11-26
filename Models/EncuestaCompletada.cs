using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.Models
{
    public class EncuestaCompletada
    {
        [Key]
        public int IdEncuestaCompletada { get; set; }
        public int IdEncuesta { get; set; }
        public string Usuario { get; set; }
    }
}