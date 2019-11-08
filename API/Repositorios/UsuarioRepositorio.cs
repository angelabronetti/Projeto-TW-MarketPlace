using System.Collections.Generic;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        TWMarketplaceContext context = new TWMarketplaceContext();
        public async Task<Usuario> Delete(Usuario usuarioDel)
        {
            context.Usuario.Remove(usuarioDel);
            await context.SaveChangesAsync();
            return usuarioDel;
        }

        public async Task<List<Usuario>> Get()
        {
            return await context.Usuario.ToListAsync();
        }

        public async Task<Usuario> Get(int id)
        {
            return await context.Usuario.FindAsync(id);
        }
        public async Task<Usuario> Get(string nome)
        {
            return await context.Usuario.FindAsync(nome);
        }

        public async Task<Usuario> Post(Usuario usuario)
        {
            await context.Usuario.AddAsync(usuario);
            await context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> Put(Usuario usuario)
        {
            context.Entry(usuario).State = EntityState.Modified; 

            await context.SaveChangesAsync();
            
            return usuario;
        }
    }
}