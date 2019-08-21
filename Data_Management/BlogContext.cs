using BlogDeInvestigacion.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogDeInvestigacion.Data_Management
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    // inheriting from IdentityDbContext Adds the necessary DbSets for Identity tables. More info here:
    // https://stackoverflow.com/questions/19902756/asp-net-identity-dbcontext-confusion
    public class BlogContext : IdentityDbContext<ApplicationUser>
    {
        public BlogContext() : base("BlogContext")
        {
            // We can set predefined or custom initializers

            //Database.SetInitializer<BlogContext>(new CreateDatabaseIfNotExists<BlogContext>());
            //Database.SetInitializer<BlogContext>(new DropCreateDatabaseIfModelChanges<BlogContext>());
            //Database.SetInitializer<BlogContext>(new DropCreateDatabaseAlways<BlogContext>());
            Database.SetInitializer<BlogContext>(new BlogInitializer());
        }

        public DbSet<Laboratorio> Laboratorios { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Evento> Eventos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //La linea comentada previene que las tablas en la bd se creen con nombre en plural
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().ToTable("dbo.AspNetUsers");

            modelBuilder.Entity<ApplicationUser>().ToTable("dbo.AspNetUsers");

            modelBuilder.Entity<IdentityRole>().ToTable("dbo.AspNetRoles");

            modelBuilder.Entity<IdentityUserClaim>().ToTable("dbo.AspNetUserClaims");

            modelBuilder.Entity<IdentityUserRole>().ToTable("dbo.AspNetUserRoles");
            modelBuilder.Entity<IdentityUserRole>().HasKey((IdentityUserRole r) => new { UserId = r.UserId, RoleId = r.RoleId }).ToTable("dbo.AspNetUserRoles");

            modelBuilder.Entity<IdentityUserLogin>().ToTable("dbo.AspNetUserLogins");
        }

        public static BlogContext Create()
        {
            return new BlogContext();
        }
    }
}