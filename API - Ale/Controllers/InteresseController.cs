using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using API___Ale.Repositorio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InteresseController : ControllerBase
    {
        InteresseRepositorio repositorio = new InteresseRepositorio();


        /// <summary>
        /// Faz a busca de uma lista de produtos que o usuario demonstrou interesse
        /// </summary>
        /// <returns>Lista de pedidos</returns>
        [HttpGet]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles="adm, comum")]
        public async Task<ActionResult<List<Interesse>>> MeusPedidos (){

            var interesses = await repositorio.MeusPedidos();

            if(interesses == null){
                return NotFound();
            }

            return interesses;
        }

        /// <summary>
        /// Faz a busca por Id do produto que foi demonstrado interesse
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Pedido</returns>
        [HttpGet("{id}")]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles="adm, comum")]
        public async Task<ActionResult<Interesse>> Get(int id)
        {
            var interesse = await repositorio.MeusPedidos(id);

            if (interesse == null)
            {
                return NotFound();
            }

            return interesse;
        }


        /// <summary>
        /// Demonstra interesse em algum produto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="interesse"></param>
        /// <returns>Não retorna</returns>
        [HttpPost]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles="adm, comum")]
        public async Task<ActionResult<Interesse>> DemonstrarInteresse(int id, Interesse interesse)
        {
            try
            {
                return await repositorio.DemonstrarInteresse(id, interesse);
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        /// <summary>
        /// Cancela um pedido de interesse
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Interesse>> ApagarInteresse(int id)
        {
            var interesse =  await repositorio.ApagarInteresse(id);

            if (interesse == null)
            {
                return NotFound();
            }

            return interesse;
        }
    }
}