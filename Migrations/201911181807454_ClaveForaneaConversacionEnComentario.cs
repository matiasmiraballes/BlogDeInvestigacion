namespace BlogDeInvestigacion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClaveForaneaConversacionEnComentario : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comentarios", "Conversacion_IdConversacion", "dbo.Conversacions");
            DropIndex("dbo.Comentarios", new[] { "Conversacion_IdConversacion" });
            RenameColumn(table: "dbo.Comentarios", name: "Conversacion_IdConversacion", newName: "IdConversacion");
            AlterColumn("dbo.Comentarios", "IdConversacion", c => c.Int(nullable: false));
            CreateIndex("dbo.Comentarios", "IdConversacion");
            AddForeignKey("dbo.Comentarios", "IdConversacion", "dbo.Conversacions", "IdConversacion", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentarios", "IdConversacion", "dbo.Conversacions");
            DropIndex("dbo.Comentarios", new[] { "IdConversacion" });
            AlterColumn("dbo.Comentarios", "IdConversacion", c => c.Int());
            RenameColumn(table: "dbo.Comentarios", name: "IdConversacion", newName: "Conversacion_IdConversacion");
            CreateIndex("dbo.Comentarios", "Conversacion_IdConversacion");
            AddForeignKey("dbo.Comentarios", "Conversacion_IdConversacion", "dbo.Conversacions", "IdConversacion");
        }
    }
}
