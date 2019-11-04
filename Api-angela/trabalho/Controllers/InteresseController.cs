using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using trabalho.Models;
using trabalho.Repositorio;

namespace trabalho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class InteresseController : ControllerBase
    {    
        InteresseRepositorio repositorio = new InteresseRepositorio();

        [HttpGet]
        public async Task<ActionResult<List<Interesse>>> Get()
        {
           try{
               return await repositorio.Get();
           }catch(System.Exception){
               throw;
           }
        }

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

        [HttpPost]
        public async Task<ActionResult<Interesse>> Post(Interesse interesse)
        {
            try{
                interesse.StatusCompra = true;
               return await repositorio.Post(interesse); //Manda cadastrar nformação no BD através do respositório
            }
            catch(System.Exception ex){ // E se houver erro ele mostra qual foi
               return BadRequest(new{mensagem = "Erro" + ex.Message});//BadRequest Mostra o erro, Mensagem (var) mostra qual foi recebendo o erro da exceção
           }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Interesse>> Put(int id, Interesse interesse)//Definir sempre o tipo de retorno <categoria>
        {
            Interesse interesseRetornado = await repositorio.Get(id); //buscando informação no banco
            if (interesseRetornado == null)//verificando se é nulo
            {
                return NotFound("Interesse em produto não encontrada");//mensagem de erro
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