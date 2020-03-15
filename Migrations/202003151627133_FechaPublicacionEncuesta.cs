namespace BlogDeInvestigacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FechaPublicacionEncuesta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Encuestas", "FechaPublicacion", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Encuestas", "FechaPublicacion");
        }
    }
}
