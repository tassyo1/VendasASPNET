namespace VendasASPNET.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidacaoNomeProduto : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Produtos", "Nome", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produtos", "Nome", c => c.String());
        }
    }
}
