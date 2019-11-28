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
    public class CorsController : ControllerBase
    {
        private readonly projeto_lilian_modasContext _context;

        public CorsController(projeto_lilian_modasContext context)
        {
            _context = context;
        }

        // GET: api/Cors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cor>>> GetCor()
        {
            return await _context.Cor.ToListAsync();
        }

        // GET: api/Cors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cor>> GetCor(int id)
        {
            var cor = await _context.Cor.FindAsync(id);

            if (cor == null)
            {
                return NotFound();
            }

            return cor;
        }

        // PUT: api/Cors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCor(int id, Cor cor)
        {
            if (id != cor.IdCor)
            {
                return BadRequest();
            }

            _context.Entry(cor).State = EntityState.Modified;

            try
            {
                cor.DtAtualizado = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(cor);
        }

        // POST: api/Cors
        [HttpPost]
        public async Task<ActionResult<Cor>> PostCor(Cor cor)
        {
            _context.Cor.Add(cor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCor", new { id = cor.IdCor }, cor);
        }

        // DELETE: api/Cors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cor>> DeleteCor(int id)
        {
            var cor = await _context.Cor.FindAsync(id);
            if (cor == null)
            {
                return NotFound();
            }

            _context.Cor.Remove(cor);
            await _context.SaveChangesAsync();

            return cor;
        }

        private bool CorExists(int id)
        {
            return _context.Cor.Any(e => e.IdCor == id);
        }
    }
}
