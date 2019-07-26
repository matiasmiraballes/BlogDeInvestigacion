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
        }
    }
}
