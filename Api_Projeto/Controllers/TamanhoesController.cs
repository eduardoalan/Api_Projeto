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
    public class TamanhoesController : ControllerBase
    {
        private readonly projeto_lilian_modasContext _context;

        public TamanhoesController(projeto_lilian_modasContext context)
        {
            _context = context;
        }

        // GET: api/Tamanhoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tamanho>>> GetTamanho()
        {
            return await _context.Tamanho.ToListAsync();
        }

        // GET: api/Tamanhoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tamanho>> GetTamanho(int id)
        {
            var tamanho = await _context.Tamanho.FindAsync(id);

            if (tamanho == null)
            {
                return NotFound();
            }

            return tamanho;
        }

        // PUT: api/Tamanhoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTamanho(int id, Tamanho tamanho)
        {
            if (id != tamanho.IdTamanho)
            {
                return BadRequest();
            }

            _context.Entry(tamanho).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TamanhoExists(id))
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

        // POST: api/Tamanhoes
        [HttpPost]
        public async Task<ActionResult<Tamanho>> PostTamanho(Tamanho tamanho)
        {
            _context.Tamanho.Add(tamanho);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTamanho", new { id = tamanho.IdTamanho }, tamanho);
        }

        // DELETE: api/Tamanhoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tamanho>> DeleteTamanho(int id)
        {
            var tamanho = await _context.Tamanho.FindAsync(id);
            if (tamanho == null)
            {
                return NotFound();
            }

            _context.Tamanho.Remove(tamanho);
            await _context.SaveChangesAsync();

            return tamanho;
        }

        private bool TamanhoExists(int id)
        {
            return _context.Tamanho.Any(e => e.IdTamanho == id);
        }
    }
}
