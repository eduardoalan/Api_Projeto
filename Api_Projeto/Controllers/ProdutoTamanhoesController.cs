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
    public class ProdutoTamanhoesController : ControllerBase
    {
        private readonly projeto_lilian_modasContext _context;

        public ProdutoTamanhoesController(projeto_lilian_modasContext context)
        {
            _context = context;
        }

        // GET: api/ProdutoTamanhoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoTamanho>>> GetProdutoTamanho()
        {
            return await _context.ProdutoTamanho.ToListAsync();
        }

        // GET: api/ProdutoTamanhoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoTamanho>> GetProdutoTamanho(int id)
        {
            var produtoTamanho = await _context.ProdutoTamanho.FindAsync(id);

            if (produtoTamanho == null)
            {
                return NotFound();
            }

            return produtoTamanho;
        }

        // PUT: api/ProdutoTamanhoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdutoTamanho(int id, ProdutoTamanho produtoTamanho)
        {
            if (id != produtoTamanho.IdProdutoTamanho)
            {
                return BadRequest();
            }

            _context.Entry(produtoTamanho).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoTamanhoExists(id))
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

        // POST: api/ProdutoTamanhoes
        [HttpPost]
        public async Task<ActionResult<ProdutoTamanho>> PostProdutoTamanho(ProdutoTamanho produtoTamanhos)
        {
            _context.ProdutoTamanho.Add(produtoTamanhos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdutoTamanho", new { id = produtoTamanhos.IdProdutoTamanho }, produtoTamanhos);

        }

        // DELETE: api/ProdutoTamanhoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoTamanho>> DeleteProdutoTamanho(int id)
        {
            var produtoTamanho = await _context.ProdutoTamanho.FindAsync(id);
            if (produtoTamanho == null)
            {
                return NotFound();
            }

            _context.ProdutoTamanho.Remove(produtoTamanho);
            await _context.SaveChangesAsync();

            return produtoTamanho;
        }

        private bool ProdutoTamanhoExists(int id)
        {
            return _context.ProdutoTamanho.Any(e => e.IdProdutoTamanho == id);
        }
    }
}
