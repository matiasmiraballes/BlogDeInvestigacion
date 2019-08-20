namespace BlogDeInvestigacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LaboratorioNoticiaRelationship : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Noticias",
                c => new
                    {
                        IdNoticia = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 500),
                        FechaCreacion = c.DateTime(nullable: false),
                        laboratorio_IdLaboratorio = c.Int(),
                    })
                .PrimaryKey(t => t.IdNoticia)
                .ForeignKey("dbo.Laboratorios", t => t.laboratorio_IdLaboratorio)
                .Index(t => t.laboratorio_IdLaboratorio);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Noticias", "laboratorio_IdLaboratorio", "dbo.Laboratorios");
            DropIndex("dbo.Noticias", new[] { "laboratorio_IdLaboratorio" });
            DropTable("dbo.Noticias");
        }
    }
}
