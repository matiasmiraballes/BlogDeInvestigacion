using BlogDeInvestigacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.ViewModels
{
    public class NoticiaViewModel
    {
        public Noticia Noticia { get; set; }
        public IList<Laboratorio> Laboratorios { get; set; }
    }
}