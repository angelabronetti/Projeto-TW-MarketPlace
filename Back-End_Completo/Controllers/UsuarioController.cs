using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using API.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        UsuarioRepositorio repositorio = new UsuarioRepositorio();
        

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get (){
            try
           {
               return await repositorio.Get();
           }
           catch (System.Exception)
           {
               
               throw;
           }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> Get(int id)
        {
           Usuario usuarioRetornado = await repositorio.Get(id);
            if ( usuarioRetornado == null)
            {
                return NotFound();
            }
            return usuarioRetornado;
        }

        [HttpGet("{nome}")]
        public async Task<ActionResult<Usuario>> Get(string nome)
        {
           Usuario usuarioRetornado = await repositorio.Get(nome.ToLower());
            if ( usuarioRetornado == null)
            {
                return NotFound();
            }
            return usuarioRetornado;
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario usuario)
        {
            try 
            {
                return await repositorio.Post(usuario);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Put(int id, Usuario usuario)
        {
          
                if (id != usuario.IdUsuario)
            {
                return BadRequest();
            }
            try
            {
            await repositorio.Put(usuario);
            
            }
            catch(DbUpdateConcurrencyException)
            {
                var usuarioValido = await repositorio.Get(id);
                if (usuarioValido == null)
                {
                   return NotFound(); 
                }else{
                    throw;
                }  
            }
            return usuario;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> Delete(int id)
        {
            Usuario usuarioDel = await repositorio.Get(id);
            if (usuarioDel == null)
            {
                return NotFound();
            }
            await repositorio.Delete(usuarioDel);
            return usuarioDel;
        }

    }

}