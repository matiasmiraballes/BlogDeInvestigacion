using BlogDeInvestigacion.Data_Management;
using BlogDeInvestigacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BlogDeInvestigacion.Services
{
    public class ServicioEventos
    {
        public IList<Conversacion> ObtenerConversaciones()
        {
            var Comentarios1 = new List<Comentario>
            {
                new Comentario { IdComentario = 1, NombreDeUsuario = "Matias Miraballes" ,Texto = "Comentario-1", TiempoCreacion = DateTime.Now},
                new Comentario { IdComentario = 2, NombreDeUsuario = "Nicolas Palomeque" , Texto = "Comentario-2", TiempoCreacion = DateTime.Now}
            };

            var Comentarios2 = new List<Comentario>
            {
                new Comentario { IdComentario = 3, NombreDeUsuario = "Nicolas Palomeque" ,Texto = "Comentario-3", TiempoCreacion = DateTime.Now},
                new Comentario { IdComentario = 4, NombreDeUsuario = "Matias Miraballes" , Texto = "Comentario-4", TiempoCreacion = DateTime.Now},
                new Comentario { IdComentario = 5, NombreDeUsuario = "Matias Miraballes" , Texto = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam", TiempoCreacion = DateTime.Now}
            };

            var conversaciones = new List<Conversacion>
            {
                new Conversacion
                {
                    IdConversacion = 1,
                    IdLaboratorio = 1,
                    TiempoCreacion = DateTime.Now,
                    Comentarios = Comentarios1
                },
                new Conversacion
                {
                    IdConversacion = 2,
                    IdLaboratorio = 1,
                    TiempoCreacion = DateTime.Now,
                    Comentarios = Comentarios2
                }
            };

            return conversaciones;
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

                db.Conversaciones.Add(conversacion);
                db.SaveChanges();
            }

        }
    }
}