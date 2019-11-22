using BlogDeInvestigacion.Data_Management;
using BlogDeInvestigacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.Services
{
    public class ServicioEvento
    {
        public void GuardarEvento(Evento evento)
        {

            using (BlogContext db = new BlogContext())
            {
                db.Eventos.Add(evento);
                db.SaveChanges();
            }
        }

        public List<Evento> ObtenerEventos()
        {
            List<Evento> eventos = new List<Evento>();

            using (BlogContext db = new BlogContext())
            {
                eventos = db.Eventos.ToList();
            }

            return eventos;
        }
    }
}