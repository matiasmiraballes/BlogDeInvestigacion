using BlogDeInvestigacion.Data_Management;
using BlogDeInvestigacion.Models;
using BlogDeInvestigacion.ViewModels;
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
            List<Encuesta> encLab = new List<Encuesta>();
            List<Encuesta> encNoCompletadas = new List<Encuesta>();
            
            using (BlogContext db = new BlogContext())
            {
                encCompletadasLabUser = db.EncuestasCompletadas.Where(ec => ec.Encuesta.IdLaboratorio == idLaboratorio && ec.Usuario == username)
                                                                .ToList();

                encLab = db.Encuestas.Where(e => e.IdLaboratorio == idLaboratorio).ToList();

                encNoCompletadas = encLab.Where(e => !encCompletadasLabUser.Any(ec => e.IdEncuesta == ec.IdEncuesta)).ToList();
            }

            return encNoCompletadas;
        }

        public List<Encuesta> ObtenerEncuestasSinCompletar(string username)
        {
            List<EncuestaCompletada> encCompletadasUser = new List<EncuestaCompletada>();
            List<Encuesta> encNoCompletadas = new List<Encuesta>();

            using (BlogContext db = new BlogContext())
            {
                encCompletadasUser = db.EncuestasCompletadas.Where(ec => ec.Usuario == username).ToList();

                encNoCompletadas = db.Encuestas.ToList().Where(e => !encCompletadasUser.Any(ec => e.IdEncuesta == ec.IdEncuesta)).ToList();
            }

            return encNoCompletadas;
        }

        public void GuardarRespuestas(List<Respuesta> respuestas)
        {
            using (BlogContext db = new BlogContext())
            {
                foreach (var r in respuestas)
                {
                    db.Respuestas.Add(r);
                }
                db.SaveChanges();
            }
        }

        public void GuardarEncuestaCompletada(EncuestaCompletada encuesta)
        {
            using (BlogContext db = new BlogContext())
            {
                db.EncuestasCompletadas.Add(encuesta);
                db.SaveChanges();
            }
        }

        public List<ResultadosEncuestaViewModel> ObtenerResultados(int idEncuesta)
        {
            List<ResultadosEncuestaViewModel> resultados = new List<ResultadosEncuestaViewModel>();

            using (BlogContext db = new BlogContext())
            {
                var preguntas = db.Preguntas.Where(p => p.IdEncuesta == idEncuesta).ToList();

                foreach (var pregunta in preguntas)
                {
                    var respuestas = db.Respuestas
                                        .Where(r => r.IdPregunta == pregunta.IdPregunta)
                                        .ToList();

                    int muestras = respuestas.Count();

                    int total = respuestas.Sum(r => r.Detalle);

                    float promedio = total / muestras;

                    ResultadosEncuestaViewModel resultadoPregunta = new ResultadosEncuestaViewModel()
                    {
                        Pregunta = pregunta.Descripcion,
                        Muestras = muestras,
                        Total = total,
                        Promedio = promedio
                    };

                    resultados.Add(resultadoPregunta);
                }
            }

            return resultados;
        }
    }
}