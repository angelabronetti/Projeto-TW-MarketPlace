using System.Collections.Generic;
using System.Threading.Tasks;
using Back_End_Completo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trabalho.Repositorio;


namespace trabalho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProdutoController : ControllerBase
    {
        ProdutoRepositorio repositorio = new ProdutoRepositorio();
      

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> Get()
        {
           try{
               return await repositorio.Get();

            }catch(System.Exception ex){
               return BadRequest(new  {mensage = "Erro" + ex.Message});
           }
        }

        [HttpGet("busca/{nome}")]
        public async Task<ActionResult<List<Produto>>> Get(string nome)
        {
            List<Produto> produtosNome = await repositorio.Get(nome.ToLower());
            if ( produtosNome == null)
            {
                return NotFound();
            }
            return produtosNome;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> Get(int id)
        {
            Produto produtosRetornado = await repositorio.Get(id);
            if ( produtosRetornado == null)
            {
                return NotFound();
            }
            return produtosRetornado;
        }
         [HttpGet("categoria/{nome}")]
        public async Task<ActionResult<List<Produto>>> BuscaPorCategoria(string nome)
        {
            List<Produto> listaDeProdutos = await repositorio.BuscaPorCategoria(nome.ToLower()); // expressão lambida/ usado para puxar tabelas para otras tabelas

            if(listaDeProdutos == null)
            {
                return NotFound();
            }
            foreach (var item in listaDeProdutos) //usado manualmente para solucionar o problema de repetição de eventos
            {
                item.TwmpIdCategoriaNavigation.Produto = null;
            }
            return listaDeProdutos;            
        }

         [HttpPut("{id}")]
        public async Task<ActionResult<Produto>> Put(int id, Produto produto)
        {
              if (id != produto.TwmpIdProduto)
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
        public async Task<ActionResult<Produto>> Delete(int id)
        {
            Produto produtosDel = await repositorio.Get(id);
            if (produtosDel == null)
            {
                return NotFound();
            }
            await repositorio.Delete(produtosDel);
            return produtosDel;
        }
       
    }
}