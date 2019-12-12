using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API_HOME.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_HOME.repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        TWMarketplaceContext context = new TWMarketplaceContext();
        public Task<List<Categoria>> Get()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Categoria> Get(string categoria_produto)
        {
            Categoria retorno = await context.Categoria.Where(c => c.CategoriaProduto == categoria_produto).FirstOrDefaultAsync();
            return  retorno;
        }
        
        

    }
}