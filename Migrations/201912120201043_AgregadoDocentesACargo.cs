namespace BlogDeInvestigacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregadoDocentesACargo : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DocentesACargo", "IdLaboratorio", "dbo.Laboratorios");
            DropIndex("dbo.DocentesACargo", new[] { "IdLaboratorio" });
            DropTable("dbo.DocentesACargo");
        }
    }
}
