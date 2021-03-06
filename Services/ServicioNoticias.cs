﻿using BlogDeInvestigacion.Data_Management;
using BlogDeInvestigacion.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.Services
{
    public class ServicioNoticias
    {
        public void GuardarNoticia(Noticia noticia)
        {

            using (BlogContext db = new BlogContext())
            {
                db.Noticias.Add(noticia);
                db.SaveChanges();
            }
        }

        public List<Noticia> ObtenerNoticias()
        {
            List<Noticia> noticias = new List<Noticia>();

            using (BlogContext db = new BlogContext())
            {
                noticias = db.Noticias
                            .Include(n => n.Laboratorio)
                            .ToList();
            }

            return noticias;
        }

        public Noticia ObtenerNoticia(int id)
        {
            Noticia noticia;

            using (BlogContext db = new BlogContext())
            {
                noticia = db.Noticias.Where(n => n.IdNoticia == id)
                                     .Include(n => n.Laboratorio)
                                     .SingleOrDefault();
            }

            return noticia;        
        }
    }
}