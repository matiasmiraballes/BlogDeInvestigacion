using BlogDeInvestigacion.Data_Management;
using BlogDeInvestigacion.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BlogDeInvestigacion.Services
{
    public class ServicioEventos
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
                eventos = db.Eventos
                            .Include(e => e.Laboratorio)
                            .ToList();
            }

            return eventos;
        }
    }
}