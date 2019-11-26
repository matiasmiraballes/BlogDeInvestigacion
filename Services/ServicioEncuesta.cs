using BlogDeInvestigacion.Data_Management;
using BlogDeInvestigacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.Services
{
    public class ServicioEncuesta
    {
        public void GuardarEncuesta(Encuesta encuesta)
        {
            using (BlogContext db = new BlogContext())
            {
                db.Encuestas.Add(encuesta);
                db.SaveChanges();
            }
        }
    }
}