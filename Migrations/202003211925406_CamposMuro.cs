namespace BlogDeInvestigacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CamposMuro : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        IdComentario = c.Int(nullable: false, identity: true),
                        IdConversacion = c.Int(nullable: false),
                        Texto = c.String(),
                        TiempoCreacion = c.DateTime(nullable: false),
                        NombreDeUsuario = c.String(),
                    })
                .PrimaryKey(t => t.IdComentario)
                .ForeignKey("dbo.Conversacions", t => t.IdConversacion, cascadeDelete: true)
                .Index(t => t.IdConversacion);
            
            CreateTable(
                "dbo.Conversacions",
                c => new
                    {
                        IdConversacion = c.Int(nullable: false, identity: true),
                        IdLaboratorio = c.Int(nullable: false),
                        TiempoCreacion = c.DateTime(nullable: false),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.IdConversacion)
                .ForeignKey("dbo.Laboratorios", t => t.IdLaboratorio, cascadeDelete: true)
                .Index(t => t.IdLaboratorio);
            
            CreateTable(
                "dbo.Laboratorios",
                c => new
                    {
                        IdLaboratorio = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.IdLaboratorio);
            
            CreateTable(
                "dbo.DocentesACargo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdDocente = c.String(),
                        Username = c.String(),
                        IdLaboratorio = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Laboratorios", t => t.IdLaboratorio, cascadeDelete: true)
                .Index(t => t.IdLaboratorio);
            
            CreateTable(
                "dbo.Encuestas",
                c => new
                    {
                        IdEncuesta = c.Int(nullable: false, identity: true),
                        IdLaboratorio = c.Int(nullable: false),
                        Titulo = c.String(),
                        Username = c.String(),
                        FechaPublicacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdEncuesta)
                .ForeignKey("dbo.Laboratorios", t => t.IdLaboratorio, cascadeDelete: true)
                .Index(t => t.IdLaboratorio);
            
            CreateTable(
                "dbo.Preguntas",
                c => new
                    {
                        IdPregunta = c.Int(nullable: false, identity: true),
                        IdEncuesta = c.Int(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.IdPregunta)
                .ForeignKey("dbo.Encuestas", t => t.IdEncuesta, cascadeDelete: true)
                .Index(t => t.IdEncuesta);
            
            CreateTable(
                "dbo.EncuestaCompletadas",
                c => new
                    {
                        IdEncuestaCompletada = c.Int(nullable: false, identity: true),
                        IdEncuesta = c.Int(nullable: false),
                        Usuario = c.String(),
                    })
                .PrimaryKey(t => t.IdEncuestaCompletada)
                .ForeignKey("dbo.Encuestas", t => t.IdEncuesta, cascadeDelete: true)
                .Index(t => t.IdEncuesta);
            
            CreateTable(
                "dbo.Eventos",
                c => new
                    {
                        IdEvento = c.Int(nullable: false, identity: true),
                        IdLaboratorio = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Descripcion = c.String(maxLength: 500),
                        Inicio = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Fin = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        FechaPublicacion = c.DateTime(nullable: false),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.IdEvento)
                .ForeignKey("dbo.Laboratorios", t => t.IdLaboratorio, cascadeDelete: true)
                .Index(t => t.IdLaboratorio);
            
            CreateTable(
                "dbo.Noticias",
                c => new
                    {
                        IdNoticia = c.Int(nullable: false, identity: true),
                        IdLaboratorio = c.Int(nullable: false),
                        Titulo = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(maxLength: 500),
                        FechaCreacion = c.DateTime(nullable: false),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.IdNoticia)
                .ForeignKey("dbo.Laboratorios", t => t.IdLaboratorio, cascadeDelete: true)
                .Index(t => t.IdLaboratorio);
            
            CreateTable(
                "dbo.Respuestas",
                c => new
                    {
                        IdRespuesta = c.Int(nullable: false, identity: true),
                        IdPregunta = c.Int(nullable: false),
                        Detalle = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdRespuesta)
                .ForeignKey("dbo.Preguntas", t => t.IdPregunta, cascadeDelete: true)
                .Index(t => t.IdPregunta);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.IdentityUser_Id)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.Suscripcions",
                c => new
                    {
                        IdSubscripcion = c.Int(nullable: false, identity: true),
                        IdLaboratorio = c.Int(nullable: false),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.IdSubscripcion);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "IdentityUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "IdentityUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "IdentityUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Respuestas", "IdPregunta", "dbo.Preguntas");
            DropForeignKey("dbo.Noticias", "IdLaboratorio", "dbo.Laboratorios");
            DropForeignKey("dbo.Eventos", "IdLaboratorio", "dbo.Laboratorios");
            DropForeignKey("dbo.EncuestaCompletadas", "IdEncuesta", "dbo.Encuestas");
            DropForeignKey("dbo.Preguntas", "IdEncuesta", "dbo.Encuestas");
            DropForeignKey("dbo.Encuestas", "IdLaboratorio", "dbo.Laboratorios");
            DropForeignKey("dbo.DocentesACargo", "IdLaboratorio", "dbo.Laboratorios");
            DropForeignKey("dbo.Conversacions", "IdLaboratorio", "dbo.Laboratorios");
            DropForeignKey("dbo.Comentarios", "IdConversacion", "dbo.Conversacions");
            DropIndex("dbo.AspNetUserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Respuestas", new[] { "IdPregunta" });
            DropIndex("dbo.Noticias", new[] { "IdLaboratorio" });
            DropIndex("dbo.Eventos", new[] { "IdLaboratorio" });
            DropIndex("dbo.EncuestaCompletadas", new[] { "IdEncuesta" });
            DropIndex("dbo.Preguntas", new[] { "IdEncuesta" });
            DropIndex("dbo.Encuestas", new[] { "IdLaboratorio" });
            DropIndex("dbo.DocentesACargo", new[] { "IdLaboratorio" });
            DropIndex("dbo.Conversacions", new[] { "IdLaboratorio" });
            DropIndex("dbo.Comentarios", new[] { "IdConversacion" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Suscripcions");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Respuestas");
            DropTable("dbo.Noticias");
            DropTable("dbo.Eventos");
            DropTable("dbo.EncuestaCompletadas");
            DropTable("dbo.Preguntas");
            DropTable("dbo.Encuestas");
            DropTable("dbo.DocentesACargo");
            DropTable("dbo.Laboratorios");
            DropTable("dbo.Conversacions");
            DropTable("dbo.Comentarios");
        }
    }
}
