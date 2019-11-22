using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogDeInvestigacion.Controllers
{
    public class ConversacionController : BaseController
    {




        // COMENTARIOS //
        public ActionResult GuardarComentario(int IdConversacion, int IdLaboratorio, string Texto)
        {
            var servicioComentarios = getCommentsService();

            if (IdConversacion != 0)    //Cuando se crea una nueva conversacion, IdConversacion llega en 0
            {
                var conversacionExistente = servicioComentarios.BuscarConversacion(IdConversacion);

                var nuevoComentario = new Comentario
                {
                    NombreDeUsuario = User.Identity.Name,
                    Texto = Texto,
                    TiempoCreacion = DateTime.Now,
                    IdConversacion = IdConversacion,
                    IdComentario = conversacionExistente.Comentarios.LastOrDefault().IdComentario + 1
                };

                conversacionExistente.Comentarios.Add(nuevoComentario);

                servicioComentarios.GuardarConversacion(conversacionExistente);
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

                servicioComentarios.GuardarConversacion(nuevaConversacion);
            }

            return RedirectToAction("Laboratorio", new { id = IdLaboratorio });
        }
    }
}