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
    public class ProdutosController : ControllerBase
    {
         TWMarketplaceContext context = new TWMarketplaceContext();
         ProdutosRepositorio repositorio = new ProdutosRepositorio();

        [HttpGet]
        public async Task<ActionResult<List<Produtos>>> Get (){
            
               try
           {
               return await repositorio.Get();
           }
           catch (System.Exception)
           {
               
               throw;
           }
        }

         // GET: api/Categoria/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produtos>> Get(int id)
        {
            Produtos produtosRetornado = await repositorio.Get(id);
            if ( produtosRetornado == null)
            {
                return NotFound();
            }
            return produtosRetornado;
        }
         [HttpGet("categoria/{nome}")]
        public async Task<ActionResult<List<Produtos>>> BuscaPorCategoria(string nome)
        {
            List<Produtos> listaDeProdutos = await repositorio.BuscaPorCategoria(nome.ToLower()); // expressão lambida/ usado para puxar tabelas para otras tabelas

            if(listaDeProdutos == null)
            {
                return NotFound();
            }
            foreach (var item in listaDeProdutos) //usado manualmente para solucionar o problema de repetição de eventos
            {
                item.IdCategoriaNavigation.Produtos = null;
            }
            return listaDeProdutos;

            
        }

        [HttpGet("busca/{nome}")]
        public async Task<ActionResult<List<Produtos>>> Get(string nome)
        {
            List<Produtos> produtosNome = await repositorio.Get(nome.ToLower());
            if ( produtosNome == null)
            {
                return NotFound();
            }
            return produtosNome;
        }

        [HttpPost]
        public async Task<ActionResult<Produtos>> Post(Produtos produto)
        {
            try 
            {
                return await repositorio.Post(produto);
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Produtos>> Put(int id, Produtos produto)
        {
              if (id != produto.IdProduto)
            {
                return BadRequest();
            }
            try
            {
            await repositorio.Put(produto);
            
            }
            catch(DbUpdateConcurrencyException)
            {
                var produtosValido = await repositorio.Get(id);
                if (produtosValido == null)
                {
                   return NotFound(); 
                }else{
                    throw;
                }  
            }
            return produto;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Produtos>> Delete(int id)
        {
            Produtos produtosDel = await repositorio.Get(id);
            if (produtosDel == null)
            {
                return NotFound();
            }
            await repositorio.Delete(produtosDel);
            return produtosDel;
        }
    }
}