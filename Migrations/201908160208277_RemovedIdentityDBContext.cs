namespace BlogDeInvestigacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedIdentityDBContext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            CreateTable(
                "dbo.Laboratorios",
                c => new
                    {
                        IdLaboratorio = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 50),
                        Descripcion = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.IdLaboratorio);
            
            AddColumn("dbo.AspNetUserRoles", "IdentityUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUserClaims", "IdentityUser_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUserLogins", "IdentityUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.AspNetUserClaims", "UserId", c => c.String());
            CreateIndex("dbo.AspNetUserRoles", "IdentityUser_Id");
            CreateIndex("dbo.AspNetUserClaims", "IdentityUser_Id");
            CreateIndex("dbo.AspNetUserLogins", "IdentityUser_Id");
            AddForeignKey("dbo.AspNetUserClaims", "IdentityUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "IdentityUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "IdentityUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "IdentityUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "IdentityUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "IdentityUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetUserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "IdentityUser_Id" });
            AlterColumn("dbo.AspNetUserClaims", "UserId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.AspNetUserLogins", "IdentityUser_Id");
            DropColumn("dbo.AspNetUserClaims", "IdentityUser_Id");
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.AspNetUserRoles", "IdentityUser_Id");
            DropTable("dbo.Laboratorios");
            CreateIndex("dbo.AspNetUserLogins", "UserId");
            CreateIndex("dbo.AspNetUserClaims", "UserId");
            CreateIndex("dbo.AspNetUserRoles", "UserId");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
