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
        public List<Subscripcion> GetSubscripciones()
        {
            List<Subscripcion> subscripciones;

            using (BlogContext db = new BlogContext())
            {
                subscripciones = db.Subscripciones.ToList();
            }

            //var subscripcion = new Subscripcion()
            //{
            //    IdLaboratorio = 1,
            //    IdSubscripcion = 1,
            //    Username = "admin@mail.com"
            //};

            //subscripciones.Add(subscripcion);

            return subscripciones;
        }

        public bool IsSubscripted(int? idLaboratorio, string username)
        {
            if (username == "") { return false; }

            Subscripcion subscripcion;

            using (BlogContext db = new BlogContext())
            {
                subscripcion = db.Subscripciones
                                    .Where(s => s.IdLaboratorio == idLaboratorio && s.Username == username)
                                    .FirstOrDefault();
            }

            return (subscripcion != null);
        }

        public void Subscribirse(int idLaboratorio, string username)
        {
            using (BlogContext db = new BlogContext())
            {
                Subscripcion subscripcion = db.Subscripciones
                                    .Where(s => s.IdLaboratorio == idLaboratorio && s.Username == username)
                                    .FirstOrDefault();

                if (subscripcion == null)
                {
                    db.Subscripciones.Add(new Subscripcion
                    {
                        IdLaboratorio = idLaboratorio,
                        Username = username
                    });

                    db.SaveChanges();
                }
            }
        }

        public void CancelarSubscripcion(int idLaboratorio, string username)
        {
            using (BlogContext db = new BlogContext())
            {
                Subscripcion subscripcion = db.Subscripciones
                                    .Where(s => s.IdLaboratorio == idLaboratorio && s.Username == username)
                                    .FirstOrDefault();

                if (subscripcion != null)
                {
                    db.Subscripciones.Remove(subscripcion);
                    db.SaveChanges();
                }
            }
        }
    }
}