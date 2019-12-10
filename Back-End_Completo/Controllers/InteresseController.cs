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
    public class InteresseController : ControllerBase
    {
        InteresseRepositorio repositorio = new InteresseRepositorio();
        
        [HttpPut("{id}")]
        public async Task<ActionResult<Interesse>> Put(int id, Interesse interesse)
        {
              if (id != interesse.IdProduto)
            {
                return BadRequest();
            }
            try
            {
            await repositorio.Put(interesse);
            
            }
            catch(DbUpdateConcurrencyException)
            {
                var interesseM = await repositorio.Get(id);
                if (interesseM == null)
                {
                   return NotFound(); 
                }else{
                    throw;
                }  
            }
            return interesse;
        }

         [HttpGet("{id}")]
        public async Task<List<ActionResult<Interesse>>> Get(int id)
        {
           List<Interesse> interesseRetornado = await repositorio.Get(id);
            if ( interesseRetornado == null)
            {
                return NotFound();
            }
            return interesseRetornado;
        }
    }

}