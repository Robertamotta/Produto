using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Estoque.WebAPI.Models;
using System.ComponentModel.DataAnnotations;
using FizzWare.NBuilder.Dates;

namespace Estoque.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly EstoqueInfrastruture_dbContext _context;

        public CategoriaController(EstoqueInfrastruture_dbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Busca todas Categorias Cadastradas
        /// </summary>
        /// <response code="200">Consulta feita com Sucesso</response>
        // GET: api/Categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoria()
        {
            return await _context.Categoria.ToListAsync();
        }

        // GET: api/Categorias/5

        /// <summary>
        /// Busca Categoria por codigo
        /// </summary>
        /// <param CodCategoria="Codigo"></param>
        /// <response code="200">Consulta feita com Sucesso</response>
        /// <response code="404">Categoria não encontrada</response>
        [HttpGet("{CodCategoria}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int CodCategoria)
        {
            var categoria = await _context.Categoria.FindAsync(CodCategoria);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        // PUT: api/Categorias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Altera uma categoria
        /// </summary>
        /// <remarks>
        /// O Status da Categoria deverá ser 1 - Ativo ou 0 - Inativo.
        /// </remarks>
        /// <param CodCategoria="Codigo"></param>
        /// <returns>Um registro de Categoria foi Alterado</returns>
        /// <response code="201">Categoria Alterada com Sucesso</response>
        /// <response code="400">Erro na Validação dos campos. Verifique os parametros.</response>  
        /// <response code="409">Já existe uma Categoria incluida para esse código.</response>  


        [HttpPut("{CodCategoria}")]
        public async Task<IActionResult> PutCategoria(int CodCategoria, Categoria categoria)
        {
            if (CodCategoria != categoria.CodCategoria)
            {
                return BadRequest();
            }

            categoria.DataAlteracao = DateTime.Today;

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(CodCategoria))
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

        // POST: api/Categorias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.

        /// <summary>
        /// Inclui uma categoria
        /// </summary>
        /// <remarks>
        /// O Status da Categoria deverá ser 1 - Ativo ou 0 - Inativo
        /// </remarks>
        /// <param CodCategoria="Codigo"></param>
        /// <returns>Um registro de Categoria foi Alterado</returns>
        /// <response code="201">Categoria Incluida com Sucesso</response>
        /// <response code="400">Erro na Validação dos campos. Verifique os parametros.</response>  
        /// <response code="409">Já existe uma Categoria incluida para esse código.</response>  
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            _context.Categoria.Add(categoria);
            categoria.DataInclusao = DateTime.Today; 
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CategoriaExists(categoria.CodCategoria))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCategoria", new { id = categoria.CodCategoria }, categoria);
        }
        /// <summary>
        /// Exclui uma categoria
        /// </summary>
        /// <remarks>
        /// O Status da Categoria deverá ser 1 - Ativo ou 0 - Inativo
        /// </remarks>
        /// <param CodCategoria="Codigo"></param>
        /// <returns>Um registro de Categoria foi Alterado</returns>
        /// <response code="201">Categoria Excluida com Sucesso</response>
        /// <response code="404">Categoria não encontrada</response>  
 
        // DELETE: api/Categorias/5
        [HttpDelete("{CodCategoria}")]
        public async Task<ActionResult<Categoria>> DeleteCategoria(int CodCategoria)
        {
            var categoria = await _context.Categoria.FindAsync(CodCategoria);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();

            return categoria;
        }

        private bool CategoriaExists(int CodCategoria)
        {
            return _context.Categoria.Any(e => e.CodCategoria == CodCategoria);
        }
    }
}
