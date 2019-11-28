using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_Projeto.Models;

namespace Api_Projeto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoFornecedorsController : ControllerBase
    {
        private readonly projeto_lilian_modasContext _context;

        public ProdutoFornecedorsController(projeto_lilian_modasContext context)
        {
            _context = context;
        }

        // GET: api/ProdutoFornecedors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoFornecedor>>> GetProdutoFornecedor()
        {
            return await _context.ProdutoFornecedor.ToListAsync();
        }

        // GET: api/ProdutoFornecedors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoFornecedor>> GetProdutoFornecedor(int id)
        {
            var produtoFornecedor = await _context.ProdutoFornecedor.FindAsync(id);

            if (produtoFornecedor == null)
            {
                return NotFound();
            }

            return produtoFornecedor;
        }

        // PUT: api/ProdutoFornecedors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdutoFornecedor(int id, ProdutoFornecedor produtoFornecedor)
        {
            if (id != produtoFornecedor.IdProdutoFornecedor)
            {
                return BadRequest();
            }

            _context.Entry(produtoFornecedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoFornecedorExists(id))
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

        // POST: api/ProdutoFornecedors
        [HttpPost]
        public async Task<ActionResult<ProdutoFornecedor>> PostProdutoFornecedor(ProdutoFornecedor produtoFornecedor)
        {
            _context.ProdutoFornecedor.Add(produtoFornecedor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProdutoFornecedorExists(produtoFornecedor.IdProdutoFornecedor))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProdutoFornecedor", new { id = produtoFornecedor.IdProdutoFornecedor }, produtoFornecedor);
        }

        // DELETE: api/ProdutoFornecedors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoFornecedor>> DeleteProdutoFornecedor(int id)
        {
            var produtoFornecedor = await _context.ProdutoFornecedor.FindAsync(id);
            if (produtoFornecedor == null)
            {
                return NotFound();
            }

            _context.ProdutoFornecedor.Remove(produtoFornecedor);
            await _context.SaveChangesAsync();

            return produtoFornecedor;
        }

        private bool ProdutoFornecedorExists(int id)
        {
            return _context.ProdutoFornecedor.Any(e => e.IdProdutoFornecedor == id);
        }
    }
}
