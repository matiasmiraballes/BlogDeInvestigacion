namespace BlogDeInvestigacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModeloNoticias : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Noticias", "Descripcion", c => c.String(maxLength: 500));
            DropColumn("dbo.Noticias", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Noticias", "Description", c => c.String(maxLength: 500));
            DropColumn("dbo.Noticias", "Descripcion");
        }
    }
}
