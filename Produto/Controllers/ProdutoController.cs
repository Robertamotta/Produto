using Estoque.Application.Produto;
using Estoque.Application.ValueObject;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?Linkcodproduto=397860

namespace Produto.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProdutoController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        /// <summary>
        /// Método utilizado para retornar os dados do usuário
        /// </summary>
        /// <remarks>Dados retornados, filtrado pelo codproduto do usuário desejado</remarks>
        /// <param name="codproduto"></param>
        /// <returns></returns>
        [HttpGet("{codproduto}")]
        public ActionResult<ProdutoVO> Get(int codproduto)
        {

            return Ok(mediator.Send(new GetDadosProduto(codproduto)));
        }
    }
}