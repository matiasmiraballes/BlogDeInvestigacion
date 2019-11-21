using BlogDeInvestigacion.Data_Management;
using BlogDeInvestigacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.Services
{
    public class ServicioSubscripcion
    {
        public List<Subscripcion> getSubscripciones()
        {
            List<Subscripcion> subscripciones;

            using (BlogContext db = new BlogContext())
            {
                subscripciones = db.Subscripciones.ToList();
            }

            var subscripcion = new Subscripcion()
            {
                IdLaboratorio = 1,
                IdSubscripcion = 1,
                Username = "admin@mail.com"
            };

            subscripciones.Add(subscripcion);

            return subscripciones;
        }
    }
}