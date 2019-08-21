namespace BlogDeInvestigacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModeloEventos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Eventos",
                c => new
                    {
                        IdEvento = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Descripcion = c.String(maxLength: 500),
                        Inicio = c.DateTime(nullable: false),
                        Fin = c.DateTime(nullable: false),
                        Laboratorio_IdLaboratorio = c.Int(),
                    })
                .PrimaryKey(t => t.IdEvento)
                .ForeignKey("dbo.Laboratorios", t => t.Laboratorio_IdLaboratorio)
                .Index(t => t.Laboratorio_IdLaboratorio);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Eventos", "Laboratorio_IdLaboratorio", "dbo.Laboratorios");
            DropIndex("dbo.Eventos", new[] { "Laboratorio_IdLaboratorio" });
            DropTable("dbo.Eventos");
        }
    }
}
