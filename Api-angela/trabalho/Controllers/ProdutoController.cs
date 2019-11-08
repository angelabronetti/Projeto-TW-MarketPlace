using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using trabalho.Models;
using trabalho.Repositorio;


namespace trabalho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProdutoController : ControllerBase
    {
        ProdutoRepositorio repositorio = new ProdutoRepositorio();
      
        /// <summary>
        /// Busca os produtos no banco de dados 
        /// </summary>
        /// <returns>
        /// Retorna os produtos em forma de lista
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<List<Produtos>>> Get()
        {
           try{
               return await repositorio.Get();

            }catch(System.Exception ex){
               return BadRequest(new  {mensage = "Erro" + ex.Message});
           }
        }
        /// <summary>
        /// Busca os produtos por nome
        /// </summary>
        /// <param name="nome">
        /// Usa o nome como parâmetro para busca 
        /// </param>
        /// <returns>
        /// Retorna em lista os produtos encontrados com os parâmetros
        /// </returns>
        [HttpGet("{nome}")]
        public async Task<ActionResult<Produtos>> Get(string nome)
        {
            Produtos produtoRetornado = await repositorio.Get(nome.ToLower()); //Manda buscar a informação no BD (repositório) e após a resposta eu faço a verificação
            if (produtoRetornado == null)
            {
                return NotFound();
            }
            return produtoRetornado; // Retorno da variável com a resposta do repositório
        }

        

       
    }
}