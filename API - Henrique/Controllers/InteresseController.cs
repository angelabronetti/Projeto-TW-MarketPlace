using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InteresseController : ControllerBase
    {
        TWMarketplaceContext context = new TWMarketplaceContext();

        [HttpGet]
        public async Task<ActionResult<List<Interesse>>> Get (){
            var interesses = await context.Interesse.Include(x => x.IdUsuarioNavigation).Include(y => y.IdProdutoNavigation).ToListAsync();

            if(interesses == null){
                return NotFound();
            }

            return interesses;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Interesse>> Get(int id)
        {
            var interesse = await context.Interesse.Include(x => x.IdUsuarioNavigation).Include(y => y.IdProdutoNavigation).FirstOrDefaultAsync(i => i.IdInteresse == id);

            if (interesse == null)
            {
                return NotFound();
            }

            return interesse;
        }

        [HttpPost]
        public async Task<ActionResult<Interesse>> Post(Interesse interesse)
        {
            try
            {
                await context.AddAsync(interesse);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return interesse;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Interesse interesse)
        {
            if (id != interesse.IdInteresse)
            {
                return BadRequest();
            }

            context.Entry(interesse).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var Interesse_valido = await context.Interesse.FindAsync(id);

                if (Interesse_valido == null)
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
        public async Task<ActionResult<Interesse>> Delete(int id)
        {
            var interesse = await context.Interesse.FindAsync(id);
            if (interesse == null)
            {
                return NotFound();
            }

            context.Interesse.Remove(interesse);
            await context.SaveChangesAsync();

            return interesse;
        }
    }
}