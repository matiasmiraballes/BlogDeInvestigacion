using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.Models
{
    [Table("DocentesACargo")]
    public class DocenteACargo
    {
        public int Id { get; set; }
        public string IdDocente { get; set; }
        public string Username { get; set; }
        public int IdLaboratorio { get; set; }
        public Laboratorio Laboratorio { get; set; }
    }
}