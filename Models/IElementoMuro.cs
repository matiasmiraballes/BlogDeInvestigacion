﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDeInvestigacion.Models
{
    public interface IElementoMuro
    {
        DateTime GetFechaDePublicacion();
        string GetTipoDePublicacion();
        string GetNombreDeLaboratorio();
        string GetUsername();
    }
}
