namespace BlogDeInvestigacion.Migrations
{
    using BlogDeInvestigacion.Data_Management;
    using BlogDeInvestigacion.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BlogContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

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

            var noticias = new List<Noticia>
            {
                new Noticia{Titulo="Inauguracion LINES", Descripcion="Se ha inaugurado la seccion de...", FechaCreacion = DateTime.ParseExact("15/06/2019 20:00:00", "dd/MM/yyyy HH:mm:ss",null), laboratorio = laboratorios[0]},
                new Noticia{Titulo="Proyecto GIDAS", Descripcion="GIDAS comenzo un nuevo proyecto de investigacion...", FechaCreacion = DateTime.ParseExact("15/06/2019 20:00:00", "dd/MM/yyyy HH:mm:ss",null), laboratorio = laboratorios[2]}
            };

            noticias.ForEach(n => context.Noticias.Add(n));
            context.SaveChanges();

            //public Laboratorio laboratorio { get; set; }
            //public string Titulo { get; set; }
            //public string Description { get; set; }
            //public DateTime FechaCreacion { get; set; }
        }
    }
}
