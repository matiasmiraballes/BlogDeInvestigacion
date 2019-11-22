namespace BlogDeInvestigacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdLaboratorioForEvents : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Eventos", "Laboratorio_IdLaboratorio", "dbo.Laboratorios");
            DropIndex("dbo.Eventos", new[] { "Laboratorio_IdLaboratorio" });
            RenameColumn(table: "dbo.Eventos", name: "Laboratorio_IdLaboratorio", newName: "IdLaboratorio");
            AlterColumn("dbo.Eventos", "IdLaboratorio", c => c.Int(nullable: false));
            CreateIndex("dbo.Eventos", "IdLaboratorio");
            AddForeignKey("dbo.Eventos", "IdLaboratorio", "dbo.Laboratorios", "IdLaboratorio", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Eventos", "IdLaboratorio", "dbo.Laboratorios");
            DropIndex("dbo.Eventos", new[] { "IdLaboratorio" });
            AlterColumn("dbo.Eventos", "IdLaboratorio", c => c.Int());
            RenameColumn(table: "dbo.Eventos", name: "IdLaboratorio", newName: "Laboratorio_IdLaboratorio");
            CreateIndex("dbo.Eventos", "Laboratorio_IdLaboratorio");
            AddForeignKey("dbo.Eventos", "Laboratorio_IdLaboratorio", "dbo.Laboratorios", "IdLaboratorio");
        }
    }
}
