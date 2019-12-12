using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using trabalho.Models;
using trabalho.Repositorio;
using trabalho.Utils;

namespace trabalho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class InteresseController : ControllerBase
    {    
        TWMarketplaceContext context = new TWMarketplaceContext();
        EmailUtils emailUtils = new EmailUtils();
        InteresseRepositorio repositorio = new InteresseRepositorio();

        /// <summary>
        /// Busca os interesses e lista 
        /// </summary>
        /// <returns>
        /// retorna os interesses
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<List<Interesse>>> Get()
        {
           try{
               return await repositorio.Get();
           }catch(System.Exception){
               throw;
           }
        }

        /// <summary>
        /// Lista os interesses 
        /// </summary>
        /// <param name="id">
        /// Lista os interesses por id
        /// </param>
        /// <returns>
        /// Retorna os interesses por id
        /// </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Interesse>> Get(int id)
        {
            Interesse interesseRetornado = await repositorio.Get(id); //Manda buscar a informação no BD (repositório) e após a resposta eu faço a verificação
            if (interesseRetornado == null)
            {
                return NotFound();
            }
            return interesseRetornado; // Retorno da variável com a resposta do repositório
        }

        /// <summary>
        ///  Inclui dados na tabela Interesse
        /// </summary>
        /// <param name="interesse">
        /// Objeto interesse
        /// </param>
        /// <returns>
        /// Ao efetuar a inclusão do objeto o  mesmo é retornado.
        /// </returns>
        /// 
        [HttpPost]
        public async Task<ActionResult<Interesse>> Post(Interesse interesse)
        {
            try{
                interesse.StatusCompra = true;

                var interesseRegistrado =await repositorio.Post(interesse); //Manda cadastrar nformação no BD através do respositório

                Usuario usuarioRetornado = context.Usuario.Where(u => u.IdUsuario == interesseRegistrado.IdUsuario).FirstOrDefault();

                string titulo = "Parabéns pela escolha!";
                string corpo = "Seu interesse foi registrado em nosso banco de dados. Aguarde o contato de nosso Administrador para adquirir o produto escolhido!";

                emailUtils.EnvioEmail(usuarioRetornado.Email, titulo,corpo);
               return interesseRegistrado;
            }
            catch(System.Exception ex){ // E se houver erro ele mostra qual foi
               return BadRequest(new{mensagem = "Erro" + ex.Message});//BadRequest Mostra o erro, Mensagem (var) mostra qual foi recebendo o erro da exceção
           }
        }

        /// <summary>
        /// Método para efetuar alterações em um objeto interesse
        /// </summary>
        /// <param name="id">
        /// ID do objeto a modificar passado pela url
        /// </param>
        /// <param name="interesse">
        /// Objeto interesse passado por Json
        /// </param>
        /// <returns>
        /// Retorna os interesses alterados
        /// </returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Interesse>> Put(int id, Interesse interesse)//Definir sempre o tipo de retorno <categoria>
        {
            Interesse interesseRetornado = await repositorio.Get(id); //buscando informação no banco
            if (interesseRetornado == null)//verificando se é nulo
            {
                return NotFound("Interesse em produto não encontrado");//mensagem de erro
            }
           try{
               return await repositorio.Put(id, interesse);// após a espera do retorno trás a informação de categoria (altera)
           }
           catch(System.Exception ex)//cria uma exceção
           {
                return BadRequest(new{mensagem = "Erro" + ex.Message});//caso haja erro informa-o
           }
        }

       
    } 
}


