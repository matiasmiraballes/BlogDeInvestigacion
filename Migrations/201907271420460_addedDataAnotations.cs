namespace BlogDeInvestigacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDataAnotations : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Laboratorios");
            DropColumn("dbo.Laboratorios", "Id");
            AddColumn("dbo.Laboratorios", "IdLaboratorio", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Laboratorios", "Nombre", c => c.String(maxLength: 50));
            AlterColumn("dbo.Laboratorios", "Descripcion", c => c.String(maxLength: 500));
            AddPrimaryKey("dbo.Laboratorios", "IdLaboratorio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Laboratorios", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Laboratorios");
            AlterColumn("dbo.Laboratorios", "Descripcion", c => c.String());
            AlterColumn("dbo.Laboratorios", "Nombre", c => c.String());
            DropColumn("dbo.Laboratorios", "IdLaboratorio");
            AddPrimaryKey("dbo.Laboratorios", "Id");
        }
    }
}
