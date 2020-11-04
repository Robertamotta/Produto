using Estoque.Application.Produto;
using Estoque.Application.ValueObject;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
        /// Método utilizado para retornar os dados do Produto
        /// </summary>
        /// <remarks>Dados retornados, filtrado pelo codproduto do usuário desejado</remarks>
        /// <param name="codproduto"></param>
        /// <returns></returns>
        [HttpGet("{codproduto}")]
        public ActionResult<ProdutoVO> Get(int codproduto)
        {

            return Ok(mediator.Send(new GetDadosProduto(codproduto)));
        }

        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        /// <param name="codproduto"></param> 
        //[HttpGet("{codproduto}")]
        //public codproduto Get(int codproduto)
        //{
        //    return GerarLista()
        //       // .FirstOrDefault(Produto => codproduto == codproduto); //<- Expressão Lambda
        //}

        private object GerarLista()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{codproduto}")]
        public IActionResult Delete(int codproduto)
        {
            //[alterar] incluir comando apos configuração banco de dados
            //           var todo = _context.TodoItems.Find(id);

            //           if (todo == null)
            //           {
            //               return NotFound();
            //}

            //_context.TodoItems.Remove(todo);
            //_context.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="codproduto"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>            
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ProdutoVO> Create(ProdutoVO item)
        {
            //[alterar] incluir comando apos configuração banco de dados

            //_context.TodoItems.Add(item);
            //_context.SaveChanges();

            //           return CreatedAtRoute("GetTodo", new { id = item.ProdutoVO}, item);
            return NoContent();

            //[HttpPut("{id}")]
            //public codproduto Put(int id, [FromBody]  codproduto contaPF)
            //{
            //    var conta = Get(id);

            //    conta.Agencia = contaPF.Agencia;
            //    conta.Conta = contaPF.Conta;
            //    conta.TipoConta = contaPF.TipoConta;
            //    conta.NomeCompleto = contaPF.NomeCompleto;

            // return ;
        }
    }

}






