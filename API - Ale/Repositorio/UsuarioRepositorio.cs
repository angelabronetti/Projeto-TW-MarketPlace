using System;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio

    {
        TWMarketplaceContext context = new TWMarketplaceContext();
        public async Task<Usuario> Post(Usuario usuario)
        {
            await context.AddAsync(usuario);
            await context.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuario> BuscarPorEmailSenha(string nome, string email, string senha)
        {
                Usuario usuarioProcurado = await context.Usuario.Include(x => x.IdPermissaoNavigation).FirstAsync(x => x.Email == email && x.Senha == senha);

                if (usuarioProcurado == null)
                {
                    return null;
                }
                
                return usuarioProcurado;
            }

        
    }
}