namespace BlogDeInvestigacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLaboratoryForComments : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Conversacions", "IdLaboratorio");
            AddForeignKey("dbo.Conversacions", "IdLaboratorio", "dbo.Laboratorios", "IdLaboratorio", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Conversacions", "IdLaboratorio", "dbo.Laboratorios");
            DropIndex("dbo.Conversacions", new[] { "IdLaboratorio" });
        }
    }
}
