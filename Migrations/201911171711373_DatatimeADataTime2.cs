namespace BlogDeInvestigacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatatimeADataTime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Eventos", "Inicio", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Eventos", "Fin", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Eventos", "Fin", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Eventos", "Inicio", c => c.DateTime(nullable: false));
        }
    }
}
