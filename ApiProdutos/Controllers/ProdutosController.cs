using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiProdutos.Data;

namespace ApiProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        //API DE GET api/produtos
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        //API DE GET api/produtos/5
        [HttpGet("{id}")]

        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        //API DE PUT api/produtos/5
        [HttpPut("{id}")]

        public async Task<ActionResult<Produto>> PutProduto(int id, Produto produto)
        {
            if (id != produto.Id) 
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }

        //API DE POST
        [HttpPost]

        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduto", new { id = produto.Id }, produto);
        }

        //API DE DELETE api/produtos/5
        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null) 
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
