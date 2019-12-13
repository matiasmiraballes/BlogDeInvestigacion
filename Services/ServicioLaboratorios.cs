using BlogDeInvestigacion.Data_Management;
using BlogDeInvestigacion.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.Services
{
    public class ServicioLaboratorios
    {
        public void AsignarDocente(string idDocente, int idLaboratorio)
        {
            ServicioUsuarios ServicioUsuarios = new ServicioUsuarios();
            var docente = ServicioUsuarios.ObtenerUsuario(idDocente);

            DocenteACargo docACargo = new DocenteACargo()
            {
                IdDocente = idDocente,
                IdLaboratorio = idLaboratorio,
                Username = docente.UserName
            };

            using (BlogContext db = new BlogContext())
            {
                db.DocenteACargo.Add(docACargo);
                db.SaveChanges();
            }
        }

        public List<Laboratorio> LaboratoriosACargoByID(string idDocente)
        {
            List<Laboratorio> laboratoriosACargo = new List<Laboratorio>();

            using (BlogContext db = new BlogContext())
            {
                laboratoriosACargo = db.DocenteACargo.Where(dac => dac.IdDocente == idDocente)
                                                        .Include(dac => dac.Laboratorio)
                                                        .Select(dac => dac.Laboratorio)
                                                        .ToList();
            }

            return laboratoriosACargo;
        }

        public List<Laboratorio> LaboratoriosACargoByUsername(string UsernameDocente)
        {
            List<Laboratorio> laboratoriosACargo = new List<Laboratorio>();

            using (BlogContext db = new BlogContext())
            {
                laboratoriosACargo = db.DocenteACargo.Where(dac => dac.Username == UsernameDocente)
                                                        .Include(dac => dac.Laboratorio)
                                                        .Select(dac => dac.Laboratorio)
                                                        .ToList();
            }

            return laboratoriosACargo;
        }
    }
}