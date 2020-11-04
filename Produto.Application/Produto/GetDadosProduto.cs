using System;
using System.Collections.Generic;
using System.Text;
using Estoque.Application.ValueObject;
using MediatR;

namespace Estoque.Application.Produto
{
    public class GetDadosProduto : IRequest<ProdutoVO>
    {
        private int Codproduto;

        public GetDadosProduto(int Codproduto)
        {
            this.Codproduto = Codproduto;

        }
    }
}