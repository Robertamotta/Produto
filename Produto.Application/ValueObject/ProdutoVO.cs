using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estoque.Application.ValueObject
{
    public class ProdutoVO
    {
        public int CodProduto { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public double ValorCusto { get; set; }
        public double ValorVenda { get; set; }
        public string Categoria { get; set; }
    }
}