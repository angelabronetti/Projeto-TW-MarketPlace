using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using API_HOME.repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        TWMarketplaceContext context = new TWMarketplaceContext();
        CategoriaRepositorio repositorio = new CategoriaRepositorio();

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get ()
        { /*Puxa por qualquer categoria*/
            var categorias = await context.Categoria.ToListAsync();/*Variavel categorias recebe do banco de dados Categoria minha lista*/

            if(categorias == null){ /*Se minha Categorias for nulo ele da erro. Caso contrario ele retorna minha Categorias*/
                return NotFound();
            }
            return categorias;
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
    }
}