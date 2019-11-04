using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
         TWMarketplaceContext context = new TWMarketplaceContext();

        [HttpGet]
        public async Task<ActionResult<List<Produtos>>> Get (){
            var produtos = await context.Produtos.ToListAsync();

            if(produtos == null){
                return NotFound();
            }

            return produtos;
        }

         // GET: api/Categoria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produtos>> Get(int id)
        {
            var produto = await context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        [HttpPost]
        public async Task<ActionResult<Produtos>> Post(Produtos produto)
        {
            try
            {
                await context.AddAsync(produto);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return produto;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Produtos produto)
        {
            if (id != produto.IdProduto)
            {
                return BadRequest();
            }

            context.Entry(produto).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var produto_valido = await context.Produtos.FindAsync(id);

                if (produto_valido == null)
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<Produtos>> Delete(int id)
        {
            var produto = await context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            context.Produtos.Remove(produto);
            await context.SaveChangesAsync();

            return produto;
        }
    }
}