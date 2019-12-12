using BlogDeInvestigacion.Data_Management;
using BlogDeInvestigacion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.ViewModels
{
    public class EditLaboratorioViewModel
    {
        public Laboratorio Laboratorio { get; set; }
        public List<ApplicationUser> Docentes { get; set; }

        [Display(Name = "Docente A Cargo")]
        public string IdDocente { get; set; }
    }
}