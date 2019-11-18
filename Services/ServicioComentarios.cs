using BlogDeInvestigacion.Data_Management;
using BlogDeInvestigacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BlogDeInvestigacion.Services
{
    public class ServicioComentarios
    {
        public IList<Conversacion> ObtenerConversaciones()
        {
            List<Conversacion> conversaciones;

            using (BlogContext db = new BlogContext())
            {
                conversaciones = db.Conversaciones.Include(c => c.Comentarios).ToList();
            }

            return conversaciones;
        }

        public Conversacion BuscarConversacion(int id)
        {
            Conversacion conversacion;

            using (BlogContext db = new BlogContext())
            {
                conversacion = db.Conversaciones.Include(c => c.Comentarios)
                                                .Where(c => c.IdConversacion == id)
                                                .SingleOrDefault();
            }

            return conversacion;
        }

        public void GuardarConversacion(Conversacion conversacion)
        {

            using (BlogContext db = new BlogContext())
            {
                var convExistente = db.Conversaciones.Include(c => c.Comentarios)
                                                      .Where(c => c.IdConversacion == conversacion.IdConversacion)
                                                      .SingleOrDefault();

                //si la conversacion ya existe, se borra y crea de nuevo
                if (convExistente != null)
                {
                    foreach (Comentario comentario in convExistente.Comentarios.ToList())
                    {
                        db.Comentarios.Remove(comentario);
                    }

                    db.Conversaciones.Remove(convExistente);
                }

                //db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Comentarios ON");
                //db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Conversacions ON");
                db.Conversaciones.Add(conversacion);
                db.SaveChanges();
                //db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Conversacions OFF");
                //db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Comentarios OFF");
            }

        }
    }
}