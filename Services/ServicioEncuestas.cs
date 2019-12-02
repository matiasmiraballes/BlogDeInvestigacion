using BlogDeInvestigacion.Data_Management;
using BlogDeInvestigacion.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.Services
{
    public class ServicioEncuestas
    {
        public void GuardarEncuesta(Encuesta encuesta)
        {
            using (BlogContext db = new BlogContext())
            {
                db.Encuestas.Add(encuesta);
                db.SaveChanges();
            }
        }

        public List<Encuesta> ObtenerEncuestas()
        {
            List<Encuesta> encuestas = new List<Encuesta>();

            using (BlogContext db = new BlogContext())
            {
                encuestas = db.Encuestas.Include(e => e.Laboratorio).ToList();
            }

            return encuestas;
        }

        public Encuesta ObtenerEncuesta(int idEncuesta)
        {
            Encuesta encuesta;

            using (BlogContext db = new BlogContext())
            {
                encuesta = db.Encuestas.Include(e => e.Laboratorio)
                                       .Include(e => e.Preguntas)
                                       .Where(e => e.IdEncuesta == idEncuesta)
                                       .SingleOrDefault();
            }

            return encuesta;
        }

        /// <summary>
        /// Devuelve las encuestas sin completar del usuario para un laboratorio
        /// </summary>
        /// <param name="idLaboratorio"></param>
        /// <param name="username"></param>
        /// <returns>Lista de encuestas sin completar</returns>
        public List<Encuesta> ObtenerEncuestasSinCompletar(int idLaboratorio, string username)
        {
            List<EncuestaCompletada> encCompletadasLabUser = new List<EncuestaCompletada>();
            List<Encuesta> encNoCompletadas = new List<Encuesta>();
            
            using (BlogContext db = new BlogContext())
            {
                encCompletadasLabUser = db.EncuestasCompletadas.Where(ec => ec.Encuesta.IdLaboratorio == idLaboratorio && ec.Usuario == username)
                                                                .ToList();

                encNoCompletadas = db.Encuestas.Where(e => e.IdLaboratorio == idLaboratorio 
                                                            && !encCompletadasLabUser.Any(ec => ec.Encuesta.IdLaboratorio == e.IdLaboratorio))
                                                            .ToList();
            }

            return encNoCompletadas;
        }
    }
}