namespace BlogDeInvestigacion.Migrations
{
    using BlogDeInvestigacion.Data_Management;
    using BlogDeInvestigacion.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

            var context = new BlogContext();
            //Seed(context);    //Descomentar para poder debuggear
        }

        //public void SeedDatabase(BlogContext context)
        //{
        //    Seed(context);
        //}

        protected override void Seed(BlogContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            ResetDatabase(context);


            var laboratorios = new List<Laboratorio>
            {
            new Laboratorio{IdLaboratorio = 1, Nombre="LINES",Descripcion="LINES - Laboratorio de Ingeniería en Sistemas de Información, Misión: Efectuar desarrollos de avanzada e investigación aplicada, sobre temas relacionados con las necesidades y características informáticas del sistema productivo local, nacional e internacional. En temas relacionados a desarrollo de software a medida, auditorias, consultoría, redes y comunicaciones."},
            new Laboratorio{IdLaboratorio = 2, Nombre="LINSI",Descripcion="LINSI - Laboratorio de Innovaciones en sistemas de Información, Misión: Dar Apoyo académico en áreas de competencia del Departamento de Sistemas de Información (DSI) que componen el Departamento de Ingeniería en Sistemas de Información, además de desarrollar actividades de investigación y desarrollo de distintos proyectos tecnológicos."},
            new Laboratorio{IdLaboratorio = 3, Nombre="GIDAS",Descripcion="GIDAS - Grupo de Investigación y Desarrollo aplicado a Sistemas de Información, Misión: Aportar al mejoramiento de Sistemas informáticos en distintas áreas del medio socio productivo, a través de tecnología innovadora."},
            new Laboratorio{IdLaboratorio = 4, Nombre="GyTE",Descripcion="Grupo de I+D de Gestión y Tecnología Energética"},
            new Laboratorio{IdLaboratorio = 5, Nombre="LM",Descripcion="Lean Manufacturing (LM)"}
            };

            //using (var transaction = context.Database.BeginTransaction())
            //{
            //    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Laboratorios ON");

            //    context.Database.ExecuteSqlCommand("INSERT INTO dbo.Laboratorios ([IdLaboratorio], [Nombre], [Descripcion]) VALUES (1, 'LINES', 'LINES - Laboratorio de Ingeniería en Sistemas de Información, Misión: Efectuar desarrollos de avanzada e investigación aplicada, sobre temas relacionados con las necesidades y características informáticas del sistema productivo local, nacional e internacional. En temas relacionados a desarrollo de software a medida, auditorias, consultoría, redes y comunicaciones.')");
            //    context.Database.ExecuteSqlCommand("INSERT INTO dbo.Laboratorios ([IdLaboratorio], [Nombre], [Descripcion]) VALUES (2, 'LINSI', 'LINSI - Laboratorio de Innovaciones en sistemas de Información, Misión: Dar Apoyo académico en áreas de competencia del Departamento de Sistemas de Información (DSI) que componen el Departamento de Ingeniería en Sistemas de Información, además de desarrollar actividades de investigación y desarrollo de distintos proyectos tecnológicos.')");
            //    context.Database.ExecuteSqlCommand("INSERT INTO dbo.Laboratorios ([IdLaboratorio], [Nombre], [Descripcion]) VALUES (3, 'GIDAS', 'GIDAS - Grupo de Investigación y Desarrollo aplicado a Sistemas de Información, Misión: Aportar al mejoramiento de Sistemas informáticos en distintas áreas del medio socio productivo, a través de tecnología innovadora.')");
            //    context.Database.ExecuteSqlCommand("INSERT INTO dbo.Laboratorios ([IdLaboratorio], [Nombre], [Descripcion]) VALUES (4, 'GyTE', 'Grupo de I+D de Gestión y Tecnología Energética')");
            //    context.Database.ExecuteSqlCommand("INSERT INTO dbo.Laboratorios ([IdLaboratorio], [Nombre], [Descripcion]) VALUES (5, 'LM', 'Lean Manufacturing (LM)')");

            //    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Laboratorios OFF");
            //    transaction.Commit();
            //}

            laboratorios.ForEach(l => context.Laboratorios.Add(l));
            SaveChanges(context);

            var noticias = new List<Noticia>
            {
                new Noticia{Titulo="Inauguracion LINES", Descripcion="Se ha inaugurado la seccion de...", FechaCreacion = DateTime.ParseExact("15/06/2019 20:00:00", "dd/MM/yyyy HH:mm:ss",null), laboratorio = laboratorios[0]},
                new Noticia{Titulo="Proyecto GIDAS", Descripcion="GIDAS comenzo un nuevo proyecto de investigacion...", FechaCreacion = DateTime.ParseExact("15/06/2019 20:00:00", "dd/MM/yyyy HH:mm:ss",null), laboratorio = laboratorios[2]}
            };

            noticias.ForEach(n => context.Noticias.Add(n));
            SaveChanges(context);

            var eventos = new List<Evento>
            {
                new Evento
                {
                    Nombre ="Jornada interna exposición de avances de trabajos de becarios...",
                    Descripcion ="Los becarios del LINSI han presentado el primer avance del trabajo de Active Directory y SAMBA...Excelente!!!",
                    Laboratorio = laboratorios[1],
                    Inicio = DateTime.ParseExact("15/06/2018 18:00:00", "dd/MM/yyyy HH:mm:ss",null),
                    Fin = DateTime.ParseExact("15/06/2019 22:00:00", "dd/MM/yyyy HH:mm:ss",null)
                }
            };

            eventos.ForEach(e => context.Eventos.Add(e));
            SaveChanges(context);

            var Comentarios1 = new List<Comentario>
            {
                new Comentario { IdComentario = 1, IdConversacion = 1, NombreDeUsuario = "Matias Miraballes" ,Texto = "Comentario-1", TiempoCreacion = DateTime.Now},
                new Comentario { IdComentario = 2, IdConversacion = 1, NombreDeUsuario = "Nicolas Palomeque" , Texto = "Comentario-2", TiempoCreacion = DateTime.Now}
            };

            var Comentarios2 = new List<Comentario>
            {
                new Comentario { IdComentario = 3, IdConversacion = 2, NombreDeUsuario = "Nicolas Palomeque" ,Texto = "Comentario-3", TiempoCreacion = DateTime.Now},
                new Comentario { IdComentario = 4, IdConversacion = 2, NombreDeUsuario = "Matias Miraballes" , Texto = "Comentario-4", TiempoCreacion = DateTime.Now},
                new Comentario { IdComentario = 5, IdConversacion = 2, NombreDeUsuario = "Matias Miraballes" , Texto = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam", TiempoCreacion = DateTime.Now}
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

            conversaciones.ForEach(c => context.Conversaciones.Add(c));
            SaveChanges(context);

            var encuestas = new List<Encuesta>()
            {
                new Encuesta { IdEncuesta = 1, Titulo = "Presentacion sobre Blockchain" }
            };

            encuestas.ForEach(e => context.Encuestas.Add(e));
            SaveChanges(context);

            var preguntas = new List<Pregunta>()
            {
                new Pregunta { IdPregunta = 1, IdEncuesta = 1, Descripcion = "¿Que tal les parecio la presentacion?" },
                new Pregunta { IdPregunta = 2, IdEncuesta = 1, Descripcion = "¿Fue interesante la parte práctica?" },
                new Pregunta { IdPregunta = 3, IdEncuesta = 1, Descripcion = "¿Fue interesante la parte teórica?" }
            };

            preguntas.ForEach(p => context.Preguntas.Add(p));
            SaveChanges(context);

            var respuestas = new List<Respuesta>()
            {
                new Respuesta { IdRespuesta = 1, IdEncuesta = 1, IdPregunta = 1, Detalle = 3},
                new Respuesta { IdRespuesta = 1, IdEncuesta = 1, IdPregunta = 1, Detalle = 2},
                new Respuesta { IdRespuesta = 1, IdEncuesta = 1, IdPregunta = 1, Detalle = 3}
            };

            respuestas.ForEach(r => context.Respuestas.Add(r));
            SaveChanges(context);

            var encuestasCompletadas = new List<EncuestaCompletada>()
            {
                new EncuestaCompletada { IdEncuestaCompletada = 1, IdEncuesta = 1, Usuario = "admin@mail.com" }
            };

            encuestasCompletadas.ForEach(e => context.EncuestasCompletadas.Add(e));
            SaveChanges(context);
        }

        private void ResetDatabase(BlogContext context)
        {
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('dbo.Comentarios',RESEED,0);");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('dbo.Conversacions',RESEED,0);");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('dbo.Eventos',RESEED,0);");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('dbo.Noticias',RESEED,0);");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('dbo.Laboratorios',RESEED,0);");

            context.Database.ExecuteSqlCommand("DELETE FROM[dbo].[AspNetRoles]");
            context.Database.ExecuteSqlCommand("DELETE FROM[dbo].[AspNetUserClaims]");
            context.Database.ExecuteSqlCommand("DELETE FROM[dbo].[AspNetUserLogins]");
            context.Database.ExecuteSqlCommand("DELETE FROM[dbo].[AspNetUserRoles]");
            context.Database.ExecuteSqlCommand("DELETE FROM[dbo].[AspNetUsers]");
            context.Database.ExecuteSqlCommand("DELETE FROM[dbo].[Comentarios]");
            context.Database.ExecuteSqlCommand("DELETE FROM[dbo].[Conversacions]");
            context.Database.ExecuteSqlCommand("DELETE FROM[dbo].[Eventos]");
            context.Database.ExecuteSqlCommand("DELETE FROM[dbo].[Noticias]");
            context.Database.ExecuteSqlCommand("DELETE FROM[dbo].[Laboratorios]");

            context.SaveChanges();
        }

        /// <summary>
        /// Wrapper for SaveChanges adding the Validation Messages to the generated exception
        /// </summary>
        /// <param name="context">The context.</param>
        private void SaveChanges(DbContext context)
        {
            try
            {

                //using (var transaction = context.Database.BeginTransaction())
                //{
                //    //var item = new IdentityItem { Id = 418, Name = "Abrahadabra" };
                //    //context.IdentityItems.Add(item);
                //    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Comentarios ON");
                //    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Conversacions ON");
                //    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Eventos ON");
                //    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Noticias ON");
                //    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Laboratorios ON");
                //    context.SaveChanges();
                //    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Comentarios OFF");
                //    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Conversacions OFF");
                //    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Eventos OFF");
                //    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Noticias OFF");
                //    context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Laboratorios OFF");
                //    transaction.Commit();
                //}


                //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Comentarios ON");
                //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Conversacions ON");
                //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Eventos ON");
                //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Noticias ON");
                //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Laboratorios ON");


                context.SaveChanges();


                //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Comentarios OFF");
                //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Conversacions OFF");
                //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Eventos OFF");
                //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Noticias OFF");
                //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Laboratorios OFF");
            }
            catch (DbEntityValidationException ex)
            {
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Conversacions OFF");
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }

    }
}
