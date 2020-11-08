using System;
using System.Data.Entity;
using Estoque.WebAPI.Models;

namespace Estoque.WebAPI.Tests
{
    public class TestEstoqueWebAPIContext : EstoqueInfrastruture_dbContext
    {
         public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(Produto CodProduto) { }
        public void Dispose() { }
    }
}