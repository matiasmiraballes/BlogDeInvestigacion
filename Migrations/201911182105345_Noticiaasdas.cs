namespace BlogDeInvestigacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Noticiaasdas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        IdComentario = c.Int(nullable: false, identity: true),
                        NombreDeUsuario = c.String(),
                        TiempoCreacion = c.DateTime(nullable: false),
                        Texto = c.String(),
                        Conversacion_IdConversacion = c.Int(),
                    })
                .PrimaryKey(t => t.IdComentario)
                .ForeignKey("dbo.Conversacions", t => t.Conversacion_IdConversacion)
                .Index(t => t.Conversacion_IdConversacion);
            
            CreateTable(
                "dbo.Conversacions",
                c => new
                    {
                        IdConversacion = c.Int(nullable: false, identity: true),
                        IdLaboratorio = c.Int(nullable: false),
                        TiempoCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdConversacion);
            
            CreateTable(
                "dbo.Eventos",
                c => new
                    {
                        IdEvento = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Descripcion = c.String(maxLength: 500),
                        Inicio = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Fin = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Laboratorio_IdLaboratorio = c.Int(),
                    })
                .PrimaryKey(t => t.IdEvento)
                .ForeignKey("dbo.Laboratorios", t => t.Laboratorio_IdLaboratorio)
                .Index(t => t.Laboratorio_IdLaboratorio);
            
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
                "dbo.Noticias",
                c => new
                    {
                        IdNoticia = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 50),
                        Descripcion = c.String(maxLength: 500),
                        FechaCreacion = c.DateTime(nullable: false),
                        laboratorio_IdLaboratorio = c.Int(),
                    })
                .PrimaryKey(t => t.IdNoticia)
                .ForeignKey("dbo.Laboratorios", t => t.laboratorio_IdLaboratorio)
                .Index(t => t.laboratorio_IdLaboratorio);
            
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
            DropForeignKey("dbo.Noticias", "laboratorio_IdLaboratorio", "dbo.Laboratorios");
            DropForeignKey("dbo.Eventos", "Laboratorio_IdLaboratorio", "dbo.Laboratorios");
            DropForeignKey("dbo.Comentarios", "Conversacion_IdConversacion", "dbo.Conversacions");
            DropIndex("dbo.AspNetUserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Noticias", new[] { "laboratorio_IdLaboratorio" });
            DropIndex("dbo.Eventos", new[] { "Laboratorio_IdLaboratorio" });
            DropIndex("dbo.Comentarios", new[] { "Conversacion_IdConversacion" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Noticias");
            DropTable("dbo.Laboratorios");
            DropTable("dbo.Eventos");
            DropTable("dbo.Conversacions");
            DropTable("dbo.Comentarios");
        }
    }
}
