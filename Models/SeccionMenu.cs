using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.Models
{
    public class SeccionMenu
    {
        public string Titulo { get; set; }
        public IList<OpcionMenu> Opciones { get; set; }
    }
}