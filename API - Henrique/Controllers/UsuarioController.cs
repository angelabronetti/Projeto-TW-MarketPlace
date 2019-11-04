using System.Threading.Tasks;
using API.Models;
using API.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        UsuarioRepositorio Repositorio = new UsuarioRepositorio();
        
        

        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(Usuario usuario)
        {
            try
            {
               return await Repositorio.Post(usuario);

            }
            catch (System.Exception)
            {
                throw;
            }

        }
    }

}