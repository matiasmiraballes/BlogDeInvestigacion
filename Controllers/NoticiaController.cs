using BlogDeInvestigacion.Data_Management;
using BlogDeInvestigacion.Models;
using BlogDeInvestigacion.Services;
using BlogDeInvestigacion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BlogDeInvestigacion.Controllers
{
    public class NoticiaController : BaseController
    {
        BlogContext db = new BlogContext();

        public ActionResult Index()
        {
            var model = db.Noticias.Include(n => n.Laboratorio)
                .ToList();

            return View(db.Noticias.ToList());
        }

        //Crea Noticia
        public ActionResult Create([Bind(Include = "IdNoticia,Titulo,Descripcion,FechaCreacion,IdLaboratorio")] Noticia noticia)
        {
            if (ModelState.IsValid)
            {
                noticia.FechaCreacion = System.DateTime.Now;
                db.Noticias.Add(noticia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            NoticiaViewModel noticiaViewModel = new NoticiaViewModel()
            {
                Noticia = noticia,
                Laboratorios = db.Laboratorios.ToList(),
            };


            return View(noticiaViewModel);
        }
       
        // boton Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Noticia noticia = getServicioNoticias().ObtenerNoticia((int)id);
            if (noticia == null)
            {
                return HttpNotFound();
            }
            return View(noticia);
        }

        //Aca es cuando lo busca para poder borrarlo
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Noticia noticia = db.Noticias.Find(id);
            if (noticia == null)
            {
                return HttpNotFound();
            }
            return View(noticia);
        }

        //Aca es cuando lo borra
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Noticia noticia = db.Noticias.Find(id);
            db.Noticias.Remove(noticia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
