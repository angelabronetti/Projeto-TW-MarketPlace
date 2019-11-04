using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        TWMarketplaceContext context = new TWMarketplaceContext();

        [HttpGet]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles="adm")]
        public async Task<ActionResult<List<Usuario>>> Get (){
            var usuarios = await context.Usuario.ToListAsync();

            if(usuarios == null){
                return NotFound();
            }

            return usuarios;
        }

        [HttpGet("{id}")]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles="adm")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
            var usuario = await context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }


        //cadastro do usuario
        [HttpPost]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles="adm")]
        public async Task<ActionResult<Usuario>> Post(Usuario usuario)
        {
            try
            {
                await context.AddAsync(usuario);
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return usuario;
        }

        [HttpPut("{id}")]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles="adm")]
        public async Task<IActionResult> Put(long id, Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return BadRequest();
            }

            context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var usuario_valido = await context.Usuario.FindAsync(id);

                if (usuario_valido == null)
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
        [EnableCors("CorsPolicy")]
        [Authorize(Roles="adm")]
        public async Task<ActionResult<Usuario>> Delete(int id)
        {
            var usuario = await context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            context.Usuario.Remove(usuario);
            await context.SaveChangesAsync();

            return usuario;
        }

    }

}