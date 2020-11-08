using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Estoque.WebAPI.Models;

namespace Estoque.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly EstoqueInfrastruture_dbContext _context;

        public ProdutosController(EstoqueInfrastruture_dbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Busca todos Produtos Cadastrados
        /// </summary>
        /// <response code="200">Consulta feita com Sucesso</response>
         // GET: api/Produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProduto()
        {
            return await _context.Produto.ToListAsync();
        }

        /// <summary>
        /// Busca Produto por codigo
        /// </summary>
        /// <param CodProduto="Codigo"></param>
        /// <response code="200">Consulta feita com Sucesso</response>
        /// <response code="404">Produto não encontrado</response>

        // GET: api/Produtos/5
        [HttpGet("{CodProduto}")]
        public async Task<ActionResult<Produto>> GetProduto(int CodProduto)
        {
            var produto = await _context.Produto.FindAsync(CodProduto);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }
        /// <summary>
        /// Altera um Produto
        /// </summary>
        /// <remarks>
        /// O Produto deverá pertencer a uma Categoria Existente e com Status = 1 (Ativa)
        /// </remarks>
        /// <param CodProduto="Codigo"></param>
        /// <returns>Um registro de Produto foi Alterado</returns>
        /// <response code="201">Produto Alterado com Sucesso</response>
        /// <response code="400">Erro na Validação dos campos. Verifique os parametros.</response>  
        /// <response code="409">Já existe um Produto incluido para esse código.</response>  
        /// <response code="500">Código da Categoria inválido.</response>
        // PUT: api/Produtos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{CodProduto}")]
        public async Task<IActionResult> PutProduto(int CodProduto, Produto produto)
        {
            if (CodProduto != produto.CodProduto)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(CodProduto))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        /// <summary>
        /// Altera um Produto
        /// </summary>
        /// <remarks>
        /// O Produto deverá pertencer a uma Categoria Existente e com Status = 1 (Ativa)
        /// </remarks>
        /// <param CodProduto="Codigo"></param>
        /// <returns>Um registro de Produto foi Incluido</returns>
        /// <response code="201">Produto Incluido com Sucesso</response>
        /// <response code="400">Erro na Validação dos campos. Verifique os parametros.</response>  
        /// <response code="409">Já existe um Produto incluido para esse código.</response>  
        /// <response code="500">Código da Categoria inválido.</response>

        // POST: api/Produtos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            _context.Produto.Add(produto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProdutoExists(produto.CodProduto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProduto", new { CodProduto = produto.CodProduto }, produto);

        }

        /// <summary>
        /// Exclui um Produto
        /// </summary>
        /// <remarks>
        /// O Produto deverá pertencer a uma Categoria Existente e com Status = 1 (Ativa)
        /// </remarks>
        /// <param CodProduto="Codigo"></param>
        /// <returns>Um registro de Produto foi Incluido</returns>
        /// <response code="201">Produto Incluido com Sucesso</response>
        /// <response code="400">Erro na Validação dos campos. Verifique os parametros.</response>  
        /// <response code="409">Já existe um Produto incluido para esse código.</response>  
        /// <response code="500">Código da Categoria inválido.</response>


        // DELETE: api/Produtos/5
        [HttpDelete("{CodProduto}")]
        public async Task<ActionResult<Produto>> DeleteProduto(int id)
        {
            var produto = await _context.Produto.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();

            return produto;
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produto.Any(e => e.CodProduto == id);
        }
    }
}
