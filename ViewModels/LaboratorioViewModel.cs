using BlogDeInvestigacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.ViewModels
{
    public class LaboratorioViewModel
    {
        public Laboratorio Laboratorio { get; set; }

        public IList<Conversacion> Conversaciones { get; set; }
    }
}