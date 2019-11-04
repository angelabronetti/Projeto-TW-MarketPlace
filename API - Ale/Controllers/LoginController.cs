using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using API.Repositorio;
using API.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        // Definimos um método construtor para poder passar essas configs
        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        UsuarioRepositorio repositorio = new UsuarioRepositorio();

        // Chamamos nosso método para validar nosso usuário da aplicação
        private async Task<Usuario> AuthenticateUser(LoginViewModel login)
        {
            Usuario usuario = await repositorio.BuscarPorEmailSenha(login.Nome, login.Email, login.Senha);

            return usuario;
        }

        // Criamos nosso método que vai gerar nosso Token
        private string GenerateJSONWebToken(Usuario userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Definimos nossas Claims (dados da sessão) para poderem ser capturadas
            // a qualquer momento enquanto o Token for ativo
            var claims = new[] {  
                // new Claim(JwtRegisteredClaimNames.NameId, userInfo.Nome),  
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(ClaimTypes.Role, userInfo.IdPermissaoNavigation.TipoUsuario), //define o tipo de usuario logado
                new Claim("roles", userInfo.IdPermissaoNavigation.TipoUsuario),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Configuramos nosso Token e seu tempo de vida
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);  
        }

        /// <summary>
        /// Autentitacação do login de usuario adm e comum. / Valida se um usuário existe no sistema
        /// </summary>
        /// <param name="login">Objeto do tipo usuario</param>
        /// <returns>acesso ao site</returns>
        /// 
         // Usamos essa anotação para ignorar a autenticação neste método, já que é ele quem fará isso  
        [AllowAnonymous]
        [HttpPost]
        [EnableCors("CorsPolicy")]
        [Authorize(Roles="adm, comum")]
        public async Task<IActionResult> Login([FromBody]LoginViewModel login)
        {
            IActionResult response = Unauthorized();

            Usuario user = await AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }
    }
}