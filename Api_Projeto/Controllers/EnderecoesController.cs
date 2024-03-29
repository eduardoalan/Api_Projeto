﻿using System;
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
    public class EnderecoesController : ControllerBase
    {
        private readonly projeto_lilian_modasContext _context;

        public EnderecoesController(projeto_lilian_modasContext context)
        {
            _context = context;
        }

        // GET: api/Enderecoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Endereco>>> GetEndereco()
        {
            return await _context.Endereco.ToListAsync();
        }

        // GET: api/Enderecoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Endereco>> GetEndereco(int id)
        {
            var endereco = await _context.Endereco.FindAsync(id);

            if (endereco == null)
            {
                return NotFound();
            }

            return endereco;
        }

        // PUT: api/Enderecoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEndereco(int id, Endereco endereco)
        {
            if (id != endereco.IdEndereco)
            {
                return BadRequest();
            }

            _context.Entry(endereco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoExists(id))
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

        // POST: api/Enderecoes
        [HttpPost]
        public async Task<ActionResult<Endereco>> PostEndereco(Endereco endereco)
        {
            _context.Endereco.Add(endereco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEndereco", new { id = endereco.IdEndereco }, endereco);
        }

        // DELETE: api/Enderecoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Endereco>> DeleteEndereco(int id)
        {
            var endereco = await _context.Endereco.FindAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }

            _context.Endereco.Remove(endereco);
            await _context.SaveChangesAsync();

            return endereco;
        }

        private bool EnderecoExists(int id)
        {
            return _context.Endereco.Any(e => e.IdEndereco == id);
        }
    }
}
