using BlogDeInvestigacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.ViewModels
{
    public class HomeViewModel
    {
        public IList<IElementoMuro> ElementosMuro { get; set; }
    }
}