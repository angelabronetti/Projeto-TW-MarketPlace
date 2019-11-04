using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using trabalho.Interface;
using trabalho.Models;

namespace trabalho.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        TWMarketplaceContext context = new TWMarketplaceContext();
          public async Task<List<Produtos>> Get()
        {
            return await context.Produtos.ToListAsync();
        }

        public async Task<Produtos> Get(string nome)
        {
           return await context.Produtos.FindAsync(nome);
        }

    }
}