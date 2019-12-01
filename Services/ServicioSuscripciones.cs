using BlogDeInvestigacion.Data_Management;
using BlogDeInvestigacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.Services
{
    public class ServicioSuscripciones
    {
        public List<Suscripcion> GetSuscripciones()
        {
            List<Suscripcion> suscripciones;

            using (BlogContext db = new BlogContext())
            {
                suscripciones = db.Subscripciones.ToList();
            }

            return suscripciones;
        }

        public List<Suscripcion> GetSuscripciones(string username)
        {
            List<Suscripcion> suscripciones;

            using (BlogContext db = new BlogContext())
            {
                suscripciones = db.Subscripciones
                                    .Where(s => s.Username == username)
                                    .ToList();
            }

            return suscripciones;
        }

        public bool IsSubscribed(int? idLaboratorio, string username)
        {
            if (username == "") { return false; }

            Suscripcion subscripcion;

            using (BlogContext db = new BlogContext())
            {
                subscripcion = db.Subscripciones
                                    .Where(s => s.IdLaboratorio == idLaboratorio && s.Username == username)
                                    .FirstOrDefault();
            }

            return (subscripcion != null);
        }

        public void Suscribirse(int idLaboratorio, string username)
        {
            using (BlogContext db = new BlogContext())
            {
                Suscripcion suscripcion = db.Subscripciones
                                    .Where(s => s.IdLaboratorio == idLaboratorio && s.Username == username)
                                    .FirstOrDefault();

                if (suscripcion == null)
                {
                    db.Subscripciones.Add(new Suscripcion
                    {
                        IdLaboratorio = idLaboratorio,
                        Username = username
                    });

                    db.SaveChanges();
                }
            }
        }

        public void CancelarSuscripcion(int idLaboratorio, string username)
        {
            using (BlogContext db = new BlogContext())
            {
                Suscripcion suscripcion = db.Subscripciones
                                    .Where(s => s.IdLaboratorio == idLaboratorio && s.Username == username)
                                    .FirstOrDefault();

                if (suscripcion != null)
                {
                    db.Subscripciones.Remove(suscripcion);
                    db.SaveChanges();
                }
            }
        }
    }
}