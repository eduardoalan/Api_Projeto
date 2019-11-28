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
    public class ItemPedidoesController : ControllerBase
    {
        private readonly projeto_lilian_modasContext _context;

        public ItemPedidoesController(projeto_lilian_modasContext context)
        {
            _context = context;
        }

        // GET: api/ItemPedidoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemPedido>>> GetItemPedido()
        {
            return await _context.ItemPedido.ToListAsync();
        }

        // GET: api/ItemPedidoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemPedido>> GetItemPedido(int id)
        {
            var itemPedido = await _context.ItemPedido.FindAsync(id);

            if (itemPedido == null)
            {
                return NotFound();
            }

            return itemPedido;
        }

        // PUT: api/ItemPedidoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemPedido(int id, ItemPedido itemPedido)
        {
            if (id != itemPedido.IdItemPedido)
            {
                return BadRequest();
            }

            _context.Entry(itemPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemPedidoExists(id))
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

        // POST: api/ItemPedidoes
        [HttpPost]
        public async Task<ActionResult> PostItemPedido(ItemPedido itemPedido)
        {
            _context.ItemPedido.Add(itemPedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItemPedido", new { id = itemPedido.IdItemPedido }, itemPedido);
        }

        

        // DELETE: api/ItemPedidoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemPedido>> DeleteItemPedido(int id)
        {
            var itemPedido = await _context.ItemPedido.FindAsync(id);
            if (itemPedido == null)
            {
                return NotFound();
            }

            _context.ItemPedido.Remove(itemPedido);
            await _context.SaveChangesAsync();

            return itemPedido;
        }

        private bool ItemPedidoExists(int id)
        {
            return _context.ItemPedido.Any(e => e.IdItemPedido == id);
        }
    }
}
