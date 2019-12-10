using BlogDeInvestigacion.Data_Management;
using BlogDeInvestigacion.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogDeInvestigacion.Startup))]
namespace BlogDeInvestigacion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
            //PopulateDatabase();
        }

        // Agregar entradas a la base de datos manualmente, alternativamente se puede usar el comando "update-database"
        private void PopulateDatabase()
        {
            //CreateRolesandUsers();

            var ctx = new BlogContext();
            {
                var laboratorio = new Laboratorio { Nombre = "LINES", Descripcion = "LINES - Laboratorio" };

                ctx.Laboratorios.Add(laboratorio);
                ctx.SaveChanges();
            }
        }

        // Mas informacion en: https://code.msdn.microsoft.com/ASPNET-MVC-5-Security-And-44cbdb97
        private void CreateRolesandUsers()
        {
            BlogContext context = new BlogContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // Si aun no existe el rol de Administrador, lo creamos junto con un usuario Admin por defecto
            if (!roleManager.RoleExists(UserRoles.Administrador))
            {
                // Primero creamos el rol Administrador 
                var role = new IdentityRole();
                role.Name = UserRoles.Administrador;
                roleManager.Create(role);

                // Luego el usuario
                var user = new ApplicationUser();
                user.UserName = "admin@mail.com";
                user.Email = "admin@mail.com";

                string userPWD = "123456";

                var chkUser = UserManager.Create(user, userPWD);
  
                if (chkUser.Succeeded)
                {
                    UserManager.AddToRole(user.Id, UserRoles.Administrador);
                }
            }

            // Verificamos que los demas roles se encuentran creados
            if (!roleManager.RoleExists(UserRoles.Docente))
            {
                var role = new IdentityRole();
                role.Name = UserRoles.Docente;
                roleManager.Create(role);

                // Luego el usuario
                var user = new ApplicationUser();
                user.UserName = "docente@mail.com";
                user.Email = "docente@mail.com";

                string userPWD = "123456";

                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    UserManager.AddToRole(user.Id, UserRoles.Docente);
                }
            }

            // creating Creating Employee role    
            if (!roleManager.RoleExists(UserRoles.Alumno))
            {
                var role = new IdentityRole();
                role.Name = UserRoles.Alumno;
                roleManager.Create(role);
            }
        }
    }
}
