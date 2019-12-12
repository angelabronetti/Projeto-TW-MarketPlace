using System.Collections.Generic;
using System.Threading.Tasks;
using API_HOME.repositorio;
using Back_End_Completo.Models;
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

        [HttpGet("{categoria_produto}")]
        public async Task<ActionResult<Categoria>> Get(string categoria_produto)/*Puxa apenas pelo categoria_produto */
        {
            var categoria = repositorio.Get(categoria_produto.ToLower());/*Variavel categorias recebe do banco de dados minha categoria por categoria_produto */

            if (categoria == null)
            {/*Se minha categorias for nulo ele da erro. Caso contrario ele retorna por categoria_produto */
                return NotFound();
            }
            return await categoria;
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
             if (nome != categoria.TwmpCategoriaProduto)
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

        [HttpDelete("{nome}")]
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