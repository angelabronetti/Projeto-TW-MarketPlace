using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers 
{
    
    
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    
   
        public class LoginController : ControllerBase
        {

            TWMarketplaceContext context = new TWMarketplaceContext();

            private IConfiguration _config;

             public LoginController(IConfiguration config)  
        {  
            _config = config;  
        }
        [AllowAnonymous]
        [HttpPost]
         public IActionResult Login([FromBody]Usuario login)  
        {  
            IActionResult response = Unauthorized();  
            var user = AuthenticateUser(login);  
  
            if (user != null)  
            {  
                var tokenString = GenerateJSONWebToken(user);  
                response = Ok(new { token = tokenString });  
            }  
  
            return response;  
        }
      
         private Usuario AuthenticateUser(Usuario login)  
        {  
            var usuario =  context.Usuario.FirstOrDefault(u => u.Email == login.Email && u.Senha == login.Senha);
  
            if (usuario != null)  
            {  
                usuario = login;  
            }  

            return usuario;  
        }  

         private string GenerateJSONWebToken(Usuario userInfo)  
        {  
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));  
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {  
                new Claim(JwtRegisteredClaimNames.NameId, userInfo.Nome),  
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),  
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())  
            }; 
            
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],  
              _config["Jwt:Issuer"],  
              claims,  
              expires: DateTime.Now.AddMinutes(120),  
              signingCredentials: credentials);  
  
            return new JwtSecurityTokenHandler().WriteToken(token);  
        }  
     
    }
}
