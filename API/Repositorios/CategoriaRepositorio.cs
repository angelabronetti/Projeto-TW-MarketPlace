using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        TWMarketplaceContext context = new TWMarketplaceContext();
        public async Task<Categoria> Get(string nome)
        {
            Categoria retorno = await context.Categoria.Where(c => c.CategoriaProduto == nome).FirstOrDefaultAsync();
            return retorno;
        }

        public async Task<Categoria> Delete(Categoria categoriaDel)
        {
            context.Categoria.Remove(categoriaDel);
            await context.SaveChangesAsync();
            return categoriaDel;
        }

        public async Task<List<Categoria>> Get()
        {
            return await context.Categoria.ToListAsync();
        }

        public async Task<Categoria> Post(Categoria categoria)
        {
            await context.Categoria.AddAsync(categoria);
            await context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> Put(Categoria categoria)
        {
            context.Entry(categoria).State = EntityState.Modified; 

            await context.SaveChangesAsync();
            
            return categoria;
        }
    }
}