using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogDeInvestigacion.Data_Management;
using BlogDeInvestigacion.Models;
using BlogDeInvestigacion.Services;
using BlogDeInvestigacion.ViewModels;

namespace BlogDeInvestigacion.Controllers
{
    public class LaboratorioController : Controller
    {
        private ServicioComentarios CommentsSerives;

        private ServicioComentarios getCommentsService()
        {
            if (CommentsSerives == null)
            {
                this.CommentsSerives = new ServicioComentarios();
            }

            return this.CommentsSerives;
        }

        private BlogContext db = new BlogContext();

        // GET: Laboratorio
        public ActionResult Index()
        {
            return View(db.Laboratorios.ToList());
        }

        // GET: Laboratorio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laboratorio laboratorio = db.Laboratorios.Find(id);
            if (laboratorio == null)
            {
                return HttpNotFound();
            }
            return View(laboratorio);
        }

        // GET: Laboratorio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Laboratorio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLaboratorio,Nombre,Descripcion")] Laboratorio laboratorio)
        {
            if (ModelState.IsValid)
            {
                db.Laboratorios.Add(laboratorio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(laboratorio);
        }

        // GET: Laboratorio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laboratorio laboratorio = db.Laboratorios.Find(id);
            if (laboratorio == null)
            {
                return HttpNotFound();
            }
            return View(laboratorio);
        }

        // POST: Laboratorio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLaboratorio,Nombre,Descripcion")] Laboratorio laboratorio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(laboratorio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(laboratorio);
        }

        // GET: Laboratorio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laboratorio laboratorio = db.Laboratorios.Find(id);
            if (laboratorio == null)
            {
                return HttpNotFound();
            }
            return View(laboratorio);
        }

        // POST: Laboratorio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Laboratorio laboratorio = db.Laboratorios.Find(id);
            db.Laboratorios.Remove(laboratorio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // MOSTRAR LABORATORIO

        //[ValidateAntiForgeryToken]
        public ActionResult Laboratorio(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Laboratorio laboratorio = db.Laboratorios.Find(id);

            if (laboratorio == null)
            {
                return HttpNotFound();
            }

            var service = getCommentsService();
            IList<Conversacion> conversaciones = service.ObtenerConversaciones();

            LaboratorioViewModel labViewModel = new LaboratorioViewModel
            {
                Laboratorio = laboratorio,
                Conversaciones = conversaciones.OrderByDescending(c => c.TiempoCreacion).ToList(),
                Noticias = db.Noticias.Where(n => n.IdLaboratorio == id).ToList()
            };

            return View(labViewModel);
        }

        public ActionResult GuardarComentario(int IdConversacion, int IdLaboratorio, string Texto)
        {
            var service = getCommentsService();

            if (IdConversacion != 0)    //Cuando se crea una nueva conversacion, IdConversacion llega en 0
            {
                var conversacionExistente = service.BuscarConversacion(IdConversacion);

                var nuevoComentario = new Comentario
                {
                    NombreDeUsuario = User.Identity.Name,
                    Texto = Texto,
                    TiempoCreacion = DateTime.Now,
                    IdConversacion = IdConversacion,
                    IdComentario = conversacionExistente.Comentarios.LastOrDefault().IdComentario + 1
                };

                conversacionExistente.Comentarios.Add(nuevoComentario);

                service.GuardarConversacion(conversacionExistente);
            }
            else
            {
                var nuevoComentario = new List<Comentario>
                {
                    new Comentario
                    {
                        NombreDeUsuario = User.Identity.Name,
                        Texto = Texto,
                        TiempoCreacion = DateTime.Now
                    }
                };

                var nuevaConversacion = new Conversacion()
                {
                    Comentarios = nuevoComentario,
                    TiempoCreacion = DateTime.Now,
                    IdLaboratorio = IdLaboratorio
                };

                service.GuardarConversacion(nuevaConversacion);
            }

            return RedirectToAction("Laboratorio", new { id = IdLaboratorio });
        }


       //public ActionResult CrearEvento(string nombre, string descripcion, string Inicio, string fin)
       public ActionResult CrearEvento(Evento evento)
       {

            Evento eventoN = new Evento
            {
                Nombre = evento.Nombre,
                Descripcion = evento.Descripcion,
                Inicio = evento.Inicio,
                Fin = evento.Fin,

            };

            var ServicioEvento = new ServicioEvento();

           ServicioEvento.GuardarEvento(eventoN);

            return View("~/Views/Evento/Index.cshtml",db.Eventos.ToList());
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
