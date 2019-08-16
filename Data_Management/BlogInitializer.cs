using BlogDeInvestigacion.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace BlogDeInvestigacion.Data_Management
{
    public class BlogInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        //Más informacion en https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application#create-the-database-context
        protected override void Seed(BlogContext context)
        {
            var laboratorios = new List<Laboratorio>
            {
            new Laboratorio{Nombre="LINES",Descripcion="LINES - Laboratorio de Ingeniería en Sistemas de Información, Misión: Efectuar desarrollos de avanzada e investigación aplicada, sobre temas relacionados con las necesidades y características informáticas del sistema productivo local, nacional e internacional. En temas relacionados a desarrollo de software a medida, auditorias, consultoría, redes y comunicaciones."},
            new Laboratorio{Nombre="LINSI",Descripcion="LINSI - Laboratorio de Innovaciones en sistemas de Información, Misión: Dar Apoyo académico en áreas de competencia del Departamento de Sistemas de Información (DSI) que componen el Departamento de Ingeniería en Sistemas de Información, además de desarrollar actividades de investigación y desarrollo de distintos proyectos tecnológicos."},
            new Laboratorio{Nombre="GIDAS",Descripcion="GIDAS - Grupo de Investigación y Desarrollo aplicado a Sistemas de Información, Misión: Aportar al mejoramiento de Sistemas informáticos en distintas áreas del medio socio productivo, a través de tecnología innovadora."},
            new Laboratorio{Nombre="GyTE",Descripcion="Grupo de I+D de Gestión y Tecnología Energética"},
            new Laboratorio{Nombre="LM",Descripcion="Lean Manufacturing (LM)"},
            };

            laboratorios.ForEach(l => context.Laboratorios.Add(l));
            context.SaveChanges();
        }
    }
}