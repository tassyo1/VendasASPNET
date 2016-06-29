namespace VendasASPNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriaValidacaoCategoria : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categorias", "Nome", c => c.String(nullable: false));
            AlterColumn("dbo.Categorias", "Descricao", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categorias", "Descricao", c => c.String());
            AlterColumn("dbo.Categorias", "Nome", c => c.String());
        }
    }
}
