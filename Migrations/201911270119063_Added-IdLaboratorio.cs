namespace BlogDeInvestigacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIdLaboratorio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Encuestas", "IdLaboratorio", c => c.Int(nullable: false));
            CreateIndex("dbo.EncuestaCompletadas", "IdEncuesta");
            AddForeignKey("dbo.EncuestaCompletadas", "IdEncuesta", "dbo.Encuestas", "IdEncuesta", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EncuestaCompletadas", "IdEncuesta", "dbo.Encuestas");
            DropIndex("dbo.EncuestaCompletadas", new[] { "IdEncuesta" });
            DropColumn("dbo.Encuestas", "IdLaboratorio");
        }
    }
}
