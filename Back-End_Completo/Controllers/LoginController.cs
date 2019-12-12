using System.Linq;
using System.Threading.Tasks;
using Back_End_Completo.Models;
using Back_End_Completo.ViewModel;
// using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers 
{
    
    
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    
   
        public class LoginController : ControllerBase
        {

            TWMPContext context = new TWMPContext();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginView"></param>
        /// <returns></returns>
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
            var user = context.Usuario.FirstOrDefault(u => u.TwmpEmail == loginView.Email && u.TwmpSenha == loginView.Senha);
            return user;
        }
     
    }
}
