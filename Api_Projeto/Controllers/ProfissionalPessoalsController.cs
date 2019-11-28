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
    public class ProfissionalPessoalsController : ControllerBase
    {
        private readonly projeto_lilian_modasContext _context;

        public ProfissionalPessoalsController(projeto_lilian_modasContext context)
        {
            _context = context;
        }

        // GET: api/ProfissionalPessoals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfissionalPessoal>>> GetProfissionalPessoal()
        {
            return await _context.ProfissionalPessoal.ToListAsync();
        }

        // GET: api/ProfissionalPessoals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfissionalPessoal>> GetProfissionalPessoal(int id)
        {
            var profissionalPessoal = await _context.ProfissionalPessoal.FindAsync(id);

            if (profissionalPessoal == null)
            {
                return NotFound();
            }

            return profissionalPessoal;
        }

        // PUT: api/ProfissionalPessoals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfissionalPessoal(int id, ProfissionalPessoal profissionalPessoal)
        {
            if (id != profissionalPessoal.IdProfissionalPessoal)
            {
                return BadRequest();
            }

            _context.Entry(profissionalPessoal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfissionalPessoalExists(id))
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

        // POST: api/ProfissionalPessoals
        [HttpPost]
        public async Task<ActionResult<ProfissionalPessoal>> PostProfissionalPessoal(ProfissionalPessoal profissionalPessoal)
        {
            _context.ProfissionalPessoal.Add(profissionalPessoal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfissionalPessoal", new { id = profissionalPessoal.IdProfissionalPessoal }, profissionalPessoal);
        }

        // DELETE: api/ProfissionalPessoals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProfissionalPessoal>> DeleteProfissionalPessoal(int id)
        {
            var profissionalPessoal = await _context.ProfissionalPessoal.FindAsync(id);
            if (profissionalPessoal == null)
            {
                return NotFound();
            }

            _context.ProfissionalPessoal.Remove(profissionalPessoal);
            await _context.SaveChangesAsync();

            return profissionalPessoal;
        }

        private bool ProfissionalPessoalExists(int id)
        {
            return _context.ProfissionalPessoal.Any(e => e.IdProfissionalPessoal == id);
        }
    }
}
