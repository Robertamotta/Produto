using Estoque.Application.Produto;
using Estoque.Application.ValueObject;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Estoque.Services.Handler.Produto
{
    public class GetDadosProdutoHandler : IRequestHandler<GetDadosProduto, ProdutoVO>
    {
        string filename = "./produto.json";

        private readonly IMediator _mediator;
        public GetDadosProdutoHandler(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

       public async Task<ProdutoVO> Handle(GetDadosProduto request, CancellationToken cancellationToken)
        {
            try
           {
                return ReadFile().FirstOrDefault(x => x.CodProduto.Equals(request));
           }
            catch (Exception)
            {
                throw;
            }
        }

        private List<ProdutoVO> ReadFile()
        {
            //List<ProdutoVO> list;

            //Verificando a existencia do arquivo
            //if (File.Exists(filename))
            //{
            //    string jsonString = File.ReadAllText(filename);
            //    return JsonSerializer.Deserialize<List<ProdutoVO>>(jsonString);
            //}
            //else
            //{
            //    return new List<ProdutoVO>();
            //}

            //Versão Operador Ternário
            return File.Exists(filename)
                ? JsonSerializer.Deserialize<List<ProdutoVO>>(File.ReadAllText(filename))
                : new List<ProdutoVO>();
        }
    }
}
