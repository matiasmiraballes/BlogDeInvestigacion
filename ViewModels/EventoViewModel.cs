using BlogDeInvestigacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.ViewModels
{
    public class EventoViewModel
    {
        public Evento Evento { get; set; }
        public IList<Laboratorio> Laboratorios { get; set; }
    }
}