using BlogDeInvestigacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.ViewModels
{
    public class ResultadosEncuestaViewModel
    {
        public string Pregunta { get; set; }
        public int Muestras { get; set; }
        public int Total { get; set; }
        public float Promedio { get; set; }
    }
}