namespace BlogDeInvestigacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConversacionesyComentarios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        IdComentario = c.Int(nullable: false, identity: true),
                        NombreDeUsuario = c.String(),
                        TiempoCreacion = c.DateTime(nullable: false),
                        Texto = c.String(),
                        Conversacion_IdConversacion = c.Int(),
                    })
                .PrimaryKey(t => t.IdComentario)
                .ForeignKey("dbo.Conversacions", t => t.Conversacion_IdConversacion)
                .Index(t => t.Conversacion_IdConversacion);
            
            CreateTable(
                "dbo.Conversacions",
                c => new
                    {
                        IdConversacion = c.Int(nullable: false, identity: true),
                        IdLaboratorio = c.Int(nullable: false),
                        TiempoCreacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdConversacion);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentarios", "Conversacion_IdConversacion", "dbo.Conversacions");
            DropIndex("dbo.Comentarios", new[] { "Conversacion_IdConversacion" });
            DropTable("dbo.Conversacions");
            DropTable("dbo.Comentarios");
        }
    }
}
