using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Repositorio;
using API.ViewModel;
// using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers 
{
    
    
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    
   
        public class LoginController : ControllerBase
        {

            TWMarketplaceContext context = new TWMarketplaceContext();

        [HttpPost]
        public async Task<ActionResult<string>> Login(LoginViewModel loginView)
        {
            Autenticar(loginView);

            return GerarToken();
        }


        public string GerarToken(){
            return "";
        }


        public Usuario Autenticar(LoginViewModel loginView){
            var user = context.Usuario.FirstOrDefault(u => u.Email == loginView.Email && u.Senha == loginView.Senha);
            return user;
        }
     
    }
}
