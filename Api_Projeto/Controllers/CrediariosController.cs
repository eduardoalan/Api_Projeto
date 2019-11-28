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
    public class CrediariosController : ControllerBase
    {
        private readonly projeto_lilian_modasContext _context;

        public CrediariosController(projeto_lilian_modasContext context)
        {
            _context = context;
        }

        // GET: api/Crediarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Crediario>>> GetCrediario()
        {
            return await _context.Crediario.ToListAsync();
        }

        // GET: api/Crediarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Crediario>> GetCrediario(int id)
        {
            var crediario = await _context.Crediario.FindAsync(id);

            if (crediario == null)
            {
                return NotFound();
            }

            return crediario;
        }

        // PUT: api/Crediarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCrediario(int id, Crediario crediario)
        {
            if (id != crediario.IdCrediario)
            {
                return BadRequest();
            }

            _context.Entry(crediario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrediarioExists(id))
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

        // POST: api/Crediarios
        [HttpPost]
        public async Task<ActionResult<Crediario>> PostCrediario(Crediario crediario)
        {
            _context.Crediario.Add(crediario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCrediario", new { id = crediario.IdCrediario }, crediario);
        }

        // DELETE: api/Crediarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Crediario>> DeleteCrediario(int id)
        {
            var crediario = await _context.Crediario.FindAsync(id);
            if (crediario == null)
            {
                return NotFound();
            }

            _context.Crediario.Remove(crediario);
            await _context.SaveChangesAsync();

            return crediario;
        }

        private bool CrediarioExists(int id)
        {
            return _context.Crediario.Any(e => e.IdCrediario == id);
        }
    }
}
