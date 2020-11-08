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
    public class UsuariosController : ControllerBase
    {
        private readonly EstoqueInfrastruture_dbContext _context;

        public UsuariosController(EstoqueInfrastruture_dbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Busca todos Usuários Cadastrados
        /// </summary>
        /// <response code="200">Consulta feita com Sucesso</response>

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _context.Usuario.ToListAsync();
        }
        /// <summary>
        /// Busca Usuário por codigo
        /// </summary>
        /// <param CodUsuario="Codigo"></param>
        /// <response code="200">Consulta feita com Sucesso</response>
        /// <response code="404">Usuário não encontrado</response>


        // GET: api/Usuarios/5
        [HttpGet("{CodUsuario}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int CodUsuario)
        {
            var usuario = await _context.Usuario.FindAsync(CodUsuario);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        /// <summary>
        /// Altera um Usuário
        /// </summary>
        /// <param CodUsuario="Codigo"></param>
        /// <remarks>
        /// O Status do Uusário deverá ser 1 - Ativo ou 0 - Inativo.
        /// </remarks>
        /// <returns>Um registro de Produto foi Alterado</returns>
        /// <response code="201">Usuário Alterado com Sucesso</response>
        /// <response code="400">Erro na Validação dos campos. Verifique os parametros.</response>  
        /// <response code="409">Já existe um Usuário incluido para esse código.</response>  
       
        // PUT: api/Usuarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{CodUsuario}")]
        public async Task<IActionResult> PutUsuario(int CodUsuario, Usuario usuario)
        {
            if (CodUsuario != usuario.IdUsuario)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(CodUsuario))
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
        /// Inclui um Usuário
        /// </summary>
        /// <param CodUsuario="Codigo"></param>
        /// <remarks>
        /// O Status do Usário deverá ser 1 - Ativo ou 0 - Inativo.
        /// </remarks>
        /// <returns>Um registro de Produto foi incluido.</returns>
        /// <response code="201">Usuário Incluido com Sucesso</response>
        /// <response code="400">Erro na Validação dos campos. Verifique os parametros.</response>  
        /// <response code="409">Já existe um Usuário incluido para esse código.</response>  

        // POST: api/Usuarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { CodUsuario = usuario.IdUsuario }, usuario);
        }
        /// <summary>
        /// Exclui um Usuário
        /// </summary>
        /// <param CodUsuario="Codigo"></param>
        /// <remarks>
        /// O Status do Usário deverá ser 1 - Ativo ou 0 - Inativo.
        /// </remarks>
        /// <returns>Um registro de Produto foi Alterado</returns>
        /// <response code="201">Usuário Excluido com Sucesso</response>
        /// <response code="400">Erro na Validação dos campos. Verifique os parametros.</response>  
        /// <response code="409">Já existe um Usuário incluido para esse código.</response>
        // DELETE: api/Usuarios/5
        [HttpDelete("{CodUsuario}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int CodUsuario)
        {
            var usuario = await _context.Usuario.FindAsync(CodUsuario);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        private bool UsuarioExists(int CodUsuario)
        {
            return _context.Usuario.Any(e => e.IdUsuario == CodUsuario);
        }
    }
}
