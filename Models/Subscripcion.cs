using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.Models
{
    public class Subscripcion
    {
        [Key]
        public int IdSubscripcion { get; set; }
        public int IdLaboratorio { get; set; }
        public string Username { get; set; }
    }
}