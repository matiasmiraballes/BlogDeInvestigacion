namespace BlogDeInvestigacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Idlab : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Noticias", "laboratorio_IdLaboratorio", "dbo.Laboratorios");
            DropIndex("dbo.Noticias", new[] { "laboratorio_IdLaboratorio" });
            RenameColumn(table: "dbo.Noticias", name: "laboratorio_IdLaboratorio", newName: "IdLaboratorio");
            AlterColumn("dbo.Noticias", "IdLaboratorio", c => c.Int(nullable: false));
            CreateIndex("dbo.Noticias", "IdLaboratorio");
            AddForeignKey("dbo.Noticias", "IdLaboratorio", "dbo.Laboratorios", "IdLaboratorio", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Noticias", "IdLaboratorio", "dbo.Laboratorios");
            DropIndex("dbo.Noticias", new[] { "IdLaboratorio" });
            AlterColumn("dbo.Noticias", "IdLaboratorio", c => c.Int());
            RenameColumn(table: "dbo.Noticias", name: "IdLaboratorio", newName: "laboratorio_IdLaboratorio");
            CreateIndex("dbo.Noticias", "laboratorio_IdLaboratorio");
            AddForeignKey("dbo.Noticias", "laboratorio_IdLaboratorio", "dbo.Laboratorios", "IdLaboratorio");
        }
    }
}
