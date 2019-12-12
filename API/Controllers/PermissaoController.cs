using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissaoController : ControllerBase
    {
        TWMarketplaceContext context = new TWMarketplaceContext();

        [HttpGet]
        public async Task<ActionResult<List<Permissao>>> Get (){
            var permissoes = await context.Permissao.Include(x => x.Usuario).ToListAsync();

            if(permissoes == null){
                return NotFound();
            }

            return permissoes;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Permissao>> Get(int id)
        {
            var permissao = await context.Permissao.Include(x => x.Usuario).FirstOrDefaultAsync(i => i.IdPermissao == id);

            if (permissao == null)
            {
                return NotFound();
            }

            return permissao;
        }

        [HttpPost]
        public async Task<ActionResult<Permissao>> Post(Permissao permissao)
        {
            try
            {
                await context.AddAsync(permissao);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return permissao;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, Permissao permissao)
        {
            if (id != permissao.IdPermissao)
            {
                return BadRequest();
            }

            context.Entry(permissao).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var Permissao_valido = await context.Permissao.FindAsync(id);

                if (Permissao_valido == null)
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
        public async Task<ActionResult<Permissao>> Delete(int id)
        {
            var permissao = await context.Permissao.FindAsync(id);
            if (permissao == null)
            {
                return NotFound();
            }

            context.Permissao.Remove(permissao);
            await context.SaveChangesAsync();

            return permissao;
        }
    }
}