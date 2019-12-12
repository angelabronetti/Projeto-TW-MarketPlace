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
    public class CategoriaController : ControllerBase
    {
        CategoriaRepositorio repositorio = new CategoriaRepositorio();

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get (){
                try
           {
               return await repositorio.Get();
           }
           catch (System.Exception)
           {
               
               throw;
           }
        }

        [HttpGet("{nome}")]
        public async Task<ActionResult<Categoria>> Get(string nome)
        {
            Categoria categoriaNome = await repositorio.Get(nome.ToLower());
            if ( categoriaNome == null)
            {
                return NotFound();
            }
            return categoriaNome;
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> Post(Categoria categoria)
        {
            try 
            {
                return await repositorio.Post(categoria);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPut("{nome}")]
        public async Task<ActionResult<Categoria>> Put(string nome, Categoria categoria)
        {
             if (nome != categoria.CategoriaProduto)
            {
                return BadRequest();
            }
            try
            {
            await repositorio.Put(categoria);
            
            }
            catch(DbUpdateConcurrencyException)
            {
                var categoriaValida = await repositorio.Get(nome);
                if (categoriaValida == null)
                {
                   return NotFound(); 
                }else{
                    throw;
                }  
            }
            return categoria;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> Delete(string nome)
        {
            Categoria categoriaDel = await repositorio.Get(nome);
            if (categoriaDel == null)
            {
                return NotFound();
            }
            await repositorio.Delete(categoriaDel);
            return categoriaDel;
        }
    }
}