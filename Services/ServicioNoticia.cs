using BlogDeInvestigacion.Data_Management;
using BlogDeInvestigacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.Services
{
    public class ServicioNoticia
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
                noticias = db.Noticias.ToList();
            }

            return noticias;
        }
    }
}