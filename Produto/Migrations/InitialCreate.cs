namespace Estoque.WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        IdCategoria = c.Int(nullable: false),
                        NomeCategoria = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(PK_Categoria => PK_Categoria.IdCategoria);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        CodProduto = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Quantidade = c.Int(),
                        ValorCusto = c.Double(),
						ValorVenda = c.Double(),
                        Categoria = c.String(),
                    })
                .PrimaryKey(t => t.CodProduto);
                
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categoria", "Produto");
            DropTable("dbo.Categoria");
            DropTable("dbo.Produto");
        }
    }
}
