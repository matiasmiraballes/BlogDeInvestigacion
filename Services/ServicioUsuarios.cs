using BlogDeInvestigacion.Data_Management;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogDeInvestigacion.Services
{
    public class ServicioUsuarios
    {
        public List<ApplicationUser> ObtenerUsuarios()
        {
            BlogContext context = new BlogContext();

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            return UserManager.Users.ToList();
        }

        public ApplicationUser ObtenerUsuario(string idUsuario)
        {
            BlogContext context = new BlogContext();

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            return UserManager.Users.Where(u => u.Id == idUsuario).SingleOrDefault();
        }

        public List<ApplicationUser> ObtenerUsuarios(string rol)
        {
            BlogContext context = new BlogContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var usuariosEnRol = roleManager.Roles.Include(r => r.Users)
                                            .Where(r => r.Name == rol)
                                            .SingleOrDefault()
                                            .Users;

            var usuarios = UserManager.Users.ToList().Where(u => usuariosEnRol.Any(uer => u.Id == uer.UserId)).ToList();

            return usuarios;
        }
    }
}