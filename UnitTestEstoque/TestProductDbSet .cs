using System;
using System.Data.Entity;
using System.Linq;
using Estoque.WebAPI.Models;

namespace Estoque.WebAPI.Tests
{
    class TestProductDbSet : TestDbSet<Produto>
    {
        public override Produto Find(params object[] keyValues)
        {
            return this.SingleOrDefault(product => product.CodProduto == (int)keyValues.Single());
        }

        public static implicit operator DbSet<object>(TestProductDbSet v)
        {
            throw new NotImplementedException();
        }
    }
}