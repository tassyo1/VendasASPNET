namespace VendasASPNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriaProduto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descricao = c.String(),
                        Quantidade = c.Int(nullable: false),
                        categoriaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categorias", t => t.categoriaID, cascadeDelete: true)
                .Index(t => t.categoriaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtos", "categoriaID", "dbo.Categorias");
            DropIndex("dbo.Produtos", new[] { "categoriaID" });
            DropTable("dbo.Produtos");
        }
    }
}
