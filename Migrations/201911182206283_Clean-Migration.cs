namespace BlogDeInvestigacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CleanMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Noticias", "IdLaboratorio", "dbo.Laboratorios");
            DropIndex("dbo.Noticias", new[] { "IdLaboratorio" });
            RenameColumn(table: "dbo.Noticias", name: "IdLaboratorio", newName: "laboratorio_IdLaboratorio");
            AlterColumn("dbo.Noticias", "laboratorio_IdLaboratorio", c => c.Int());
            CreateIndex("dbo.Noticias", "laboratorio_IdLaboratorio");
            AddForeignKey("dbo.Noticias", "laboratorio_IdLaboratorio", "dbo.Laboratorios", "IdLaboratorio");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Noticias", "laboratorio_IdLaboratorio", "dbo.Laboratorios");
            DropIndex("dbo.Noticias", new[] { "laboratorio_IdLaboratorio" });
            AlterColumn("dbo.Noticias", "laboratorio_IdLaboratorio", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Noticias", name: "laboratorio_IdLaboratorio", newName: "IdLaboratorio");
            CreateIndex("dbo.Noticias", "IdLaboratorio");
            AddForeignKey("dbo.Noticias", "IdLaboratorio", "dbo.Laboratorios", "IdLaboratorio", cascadeDelete: true);
        }
    }
}
