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
    public class NotafiscalsController : ControllerBase
    {
        private readonly projeto_lilian_modasContext _context;
        private Notafiscal auxNota;
        

        public NotafiscalsController(projeto_lilian_modasContext context)
        {
            _context = context;

        }

        // GET: api/Notafiscals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notafiscal>>> GetNotafiscal()
        {
            return await _context.Notafiscal.ToListAsync();
        }

        // GET: api/Notafiscals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notafiscal>> GetNotafiscal(int id)
        {
            var notafiscal = await _context.Notafiscal.FindAsync(id);

            if (notafiscal == null)
            {
                return NotFound();
            }

            return notafiscal;
        }

        // PUT: api/Notafiscals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotafiscal(int id, Notafiscal notafiscal)
        {
            if (id != notafiscal.IdNotafiscal)
            {
                return BadRequest();
            }

            _context.Entry(notafiscal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotafiscalExists(id))
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

        // POST: api/Notafiscals/Entrada
        [HttpPost("Entrada")]
        public async Task<ActionResult> PostNotafiscalEntrada(Notafiscal notafiscal)
        {   
            if (notafiscal != null)
            {            
                auxNota = new Notafiscal();
                auxNota.IdCliente = notafiscal.IdCliente;
                auxNota.DsTipo = notafiscal.DsTipo;
                auxNota.DtCriacao = DateTime.Now;

                _context.Notafiscal.Add(auxNota);
                _context.SaveChanges();


            foreach (var prod in notafiscal.ProdutoTamanhos)
                {
                      

                    if (ExisteProdutoTamanho(prod.IdProduto, prod.IdTamanho))
                    {

                        //var tamanhos = _context.ProdutoTamanho.FromSql("Select id_produto_tamanho from produto_tamanho where id_produto = prod.IdProduto and id_tamanho = prod.IdTamanho");
                        //var tamanhos = _context.ProdutoTamanho.Where(p => p.IdProduto == prod.IdProduto && p.IdTamanho == prod.IdTamanho).FirstOrDefault();
                        _context.Estoque.Add(new Estoque()
                        {
                            DsTipo = "Entrada",
                            IdProdutoTamanho = 37,
                            DtCriacao = DateTime.Now,
                            IdNotafiscal = auxNota.IdNotafiscal,
                            NmUsuario = "Edu",
                            VlQuantidade = prod.VlQuantidade
                        });
                        
                        _context.SaveChanges();
                    }
                    else
                    {


                    var produtoTamanho = new ProdutoTamanho();
                    produtoTamanho.IdProduto = prod.IdProduto;
                    produtoTamanho.IdTamanho = prod.IdTamanho;
                    produtoTamanho.VlQuantidade = prod.VlQuantidade;

                        _context.ProdutoTamanho.Add(produtoTamanho);
                        _context.SaveChanges();
                     

                        _context.Estoque.Add(new Estoque()
                        {
                            DsTipo = "Entrada",
                            IdProdutoTamanho = produtoTamanho.IdProdutoTamanho,
                            DtCriacao = DateTime.Now,
                            IdNotafiscal = auxNota.IdNotafiscal,
                            NmUsuario = "Edu",
                            VlQuantidade = produtoTamanho.VlQuantidade
                        });
                        _context.SaveChanges();
                    }
                    }
            }
            else
            {
                return BadRequest();
            }
            return Ok(notafiscal);
           
        }
        public List<ProdutoTamanho> BuscarId(int idProduto, int idTamanho)
        {
            var buscar = _context.ProdutoTamanho.Where(p => p.IdProduto == idProduto && p.IdTamanho == idTamanho).ToList();
            return buscar;
        }


        // DELETE: api/Notafiscals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Notafiscal>> DeleteNotafiscal(int id)
        {
            var notafiscal = await _context.Notafiscal.FindAsync(id);
            if (notafiscal == null)
            {
                return NotFound();
            }

            _context.Notafiscal.Remove(notafiscal);
            await _context.SaveChangesAsync();

            return notafiscal;
        }

        private bool NotafiscalExists(int id)
        {
            return _context.Notafiscal.Any(e => e.IdNotafiscal == id);
        }

        public bool ExisteProdutoTamanho(int IdProduto, int IdTamanho)
        {
            return _context.ProdutoTamanho.Any(p => p.IdProduto == IdProduto && p.IdTamanho == IdTamanho);
            
        }
    }
}
