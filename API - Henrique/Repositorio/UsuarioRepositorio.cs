using System;
using System.Threading.Tasks;
using API.Models;

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

        
    }
}