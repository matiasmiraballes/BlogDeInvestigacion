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
using BlogDeInvestigacion.ViewModels;

namespace BlogDeInvestigacion.Controllers
{
    public class LaboratorioController : Controller
    {
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

            var conversaciones = GetConversaciones();

            LaboratorioViewModel labViewModel = new LaboratorioViewModel
            {
                Laboratorio = laboratorio,
                Conversaciones = conversaciones
            };

            return View(labViewModel);
        }

        private IList<Conversacion> GetConversaciones()
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
