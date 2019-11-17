namespace BlogDeInvestigacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LaboratorioRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Laboratorios", "Nombre", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Laboratorios", "Descripcion", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Laboratorios", "Descripcion", c => c.String(maxLength: 500));
            AlterColumn("dbo.Laboratorios", "Nombre", c => c.String(maxLength: 50));
        }
    }
}
