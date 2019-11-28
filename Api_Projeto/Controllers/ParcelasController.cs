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
    public class ParcelasController : ControllerBase
    {
        private readonly projeto_lilian_modasContext _context;

        public ParcelasController(projeto_lilian_modasContext context)
        {
            _context = context;
        }

        // GET: api/Parcelas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parcelas>>> GetParcelas()
        {
            return await _context.Parcelas.ToListAsync();
        }

        // GET: api/Parcelas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Parcelas>> GetParcelas(int id)
        {
            var parcelas = await _context.Parcelas.FindAsync(id);

            if (parcelas == null)
            {
                return NotFound();
            }

            return parcelas;
        }

        // PUT: api/Parcelas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParcelas(int id, Parcelas parcelas)
        {
            if (id != parcelas.IdParcelas)
            {
                return BadRequest();
            }

            _context.Entry(parcelas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParcelasExists(id))
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

        // POST: api/Parcelas
        [HttpPost]
        public async Task<ActionResult<Parcelas>> PostParcelas(Parcelas parcelas)
        {
            _context.Parcelas.Add(parcelas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParcelas", new { id = parcelas.IdParcelas }, parcelas);
        }

        // DELETE: api/Parcelas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Parcelas>> DeleteParcelas(int id)
        {
            var parcelas = await _context.Parcelas.FindAsync(id);
            if (parcelas == null)
            {
                return NotFound();
            }

            _context.Parcelas.Remove(parcelas);
            await _context.SaveChangesAsync();

            return parcelas;
        }

        private bool ParcelasExists(int id)
        {
            return _context.Parcelas.Any(e => e.IdParcelas == id);
        }
    }
}
