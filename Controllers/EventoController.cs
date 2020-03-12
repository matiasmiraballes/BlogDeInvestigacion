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

namespace BlogDeInvestigacion.Controllers
{
    public class EventoController : BaseController
    {
        private BlogContext db = new BlogContext();
        // GET: Evento
        public ActionResult Index()
        {
            return View(db.Eventos.ToList());
        }

        public ActionResult Create([Bind(Include = "IdEvento,Nombre,Descripcion,IdLaboratorio")] Evento evento, string Inicio, string Fin)
        {
            if (ModelState.IsValid && !String.IsNullOrEmpty(Inicio) && !String.IsNullOrEmpty(Fin))
            {
                evento.Inicio = DateTime.Parse(Inicio);
                evento.Fin = DateTime.Parse(Fin);

                db.Eventos.Add(evento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            EventoViewModel eventoViewModel = new EventoViewModel()
            {
                Evento = evento,
                Laboratorios = getServicioLaboratorios().ObtenerLaboratorios(),
            };

            return View(eventoViewModel);
        }
        // boton Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }
        //Aca es cuando lo busca para poder borrarlo
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evento evento = db.Eventos.Find(id);
            if (evento == null)
            {
                return HttpNotFound();
            }
            return View(evento);
        }

        //Aca es cuando lo borra
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evento evento = db.Eventos.Find(id);
            db.Eventos.Remove(evento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}