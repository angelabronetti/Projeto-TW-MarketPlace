using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using Back_End_Completo.Models;
using Microsoft.EntityFrameworkCore;

namespace API_HOME.repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
       TWMPContext context = new TWMPContext();

        public async Task<Categoria> Delete(Categoria categoriaDel)
        {
            context.Categoria.Remove(categoriaDel);
            await context.SaveChangesAsync();
            return categoriaDel;;
        }

        public async Task<List<Categoria>> Get()
        {
            return await context.Categoria.ToListAsync();
        }

        public async Task<Categoria> Get(int id)
        {
            return await context.Categoria.FindAsync(id);
        }

        public async Task<Categoria> Get(string categoria_produto)
        {
            Categoria retorno = await context.Categoria.Where(c => c.TwmpCategoriaProduto == categoria_produto).FirstOrDefaultAsync();
            return  retorno;
        }

        public async Task<Categoria> Nome(string nome)
        {
             Categoria retorno = await context.Categoria.Where(c => c.TwmpCategoriaProduto == nome).FirstOrDefaultAsync();
            return retorno;
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