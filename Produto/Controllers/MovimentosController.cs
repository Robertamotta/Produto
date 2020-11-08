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
    public class MovimentosController : ControllerBase
    {
        private readonly EstoqueInfrastruture_dbContext _context;

        public MovimentosController(EstoqueInfrastruture_dbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Busca toda Movimentação do Estoque Cadastradas
        /// </summary>
        /// <response code="200">Consulta feita com Sucesso</response>
        // GET: api/Movimentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movimento>>> GetMovimento()
        {
            return await _context.Movimento.ToListAsync();
        }
        /// <summary>
        /// Busca Movimento por codigo
        /// </summary>
        /// <param CodMovimento="Codigo"></param>
        /// <response code="200">Consulta feita com Sucesso</response>
        /// <response code="404">Usuário não encontrado</response>
        // GET: api/Movimentos/5
        [HttpGet("{CodMovimento}")]
        public async Task<ActionResult<Movimento>> GetMovimento(int CodMovimento)
        {
            var movimento = await _context.Movimento.FindAsync(CodMovimento);

            if (movimento == null)
            {
                return NotFound();
            }

            return movimento;
        }
        /// <summary>
        /// Altera um Movimento de Estoque
        /// </summary>
        /// <param CodMovimento="Codigo"></param>
        /// <remarks>
        /// O Status do Uusário vinculado ao Movimento deverá ser 1.
        /// </remarks>
        /// <returns>Um registro de Movimento foi Alterado</returns>
        /// <response code="201">Movimento Alterado com Sucesso</response>
        /// <response code="400">Erro na Validação dos campos. Verifique os parametros.</response>  
        /// <response code="409">Já existe um Movimento incluido para esse código.</response>  
        // PUT: api/Movimentos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{CodMovimento}")]
        public async Task<IActionResult> PutMovimento(int CodMovimento, Movimento movimento)
        {
            if (CodMovimento != movimento.IdMovimento)
            {
                return BadRequest();
            }

           
            _context.Entry(movimento).State = EntityState.Modified;

            try
            {
                if ((bool)UsuarioAtivo(movimento.IdUsuario))
                {
                    return BadRequest();
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovimentoExists(CodMovimento))
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

        private object UsuarioAtivo(int? idUsuario)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Inclui um Movimento de Estoque
        /// </summary>
        /// <param CodMovimento="Codigo"></param>
        /// <remarks>
        /// O Status do Usário vinculado ao Movimento deverá ser 1.
        /// </remarks>
        /// <returns>Um registro de Movimento foi Incluido</returns>
        /// <response code="201">Movimento Incluido com Sucesso</response>
        /// <response code="400">Erro na Validação dos campos. Verifique os parametros.</response>  
        /// <response code="409">Já existe um Movimento incluido para esse código.</response>  
        // PUT: api/Movimentos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.


        // POST: api/Movimentos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Movimento>> PostMovimento(Movimento movimento)
        {
            _context.Movimento.Add(movimento);
            try
            {
                if ((bool)UsuarioAtivo(movimento.IdUsuario))
                {
                    return BadRequest();
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MovimentoExists(movimento.IdMovimento))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMovimento", new { id = movimento.IdMovimento }, movimento);
        }
        /// <summary>
        /// Exclui um Movimento de Estoque
        /// </summary>
        /// <param CodMovimento="Codigo"></param>
        /// <remarks>
        /// O Status do Uusário vinculado ao Movimento deverá ser 1.
        /// </remarks>
        /// <returns>Um registro de Movimento foi Excluido</returns>
        /// <response code="201">Movimento Excluido com Sucesso</response>
        /// <response code="400">Erro na Validação dos campos. Verifique os parametros.</response>  
        /// <response code="409">Já existe um Movimento incluido para esse código.</response>  
        // PUT: api/Movimentos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.


        // DELETE: api/Movimentos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Movimento>> DeleteMovimento(int id)
        {
            var movimento = await _context.Movimento.FindAsync(id);
            if (movimento == null)
            {
                return NotFound();
            }

            _context.Movimento.Remove(movimento);
            await _context.SaveChangesAsync();

            return movimento;
        }

        private bool MovimentoExists(int id)
        {
            return _context.Movimento.Any(e => e.IdMovimento == id);
        }

        public bool UsuarioAtivo(int id)
        {
            return _context.Usuario.Any(e => e.IdUsuario == id && e.StatusUsuario == 1);
        }
        public bool CategoriaAtiva(int codCategoria)
        {
            return _context.Categoria.Any(e => e.CodCategoria == codCategoria && e.Status == 1);
        }
    }
}
