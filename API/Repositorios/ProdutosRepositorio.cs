using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositorios
{
    public class ProdutosRepositorio : IProdutosRepositorio

    {
        TWMarketplaceContext context = new TWMarketplaceContext();
        public async Task<List<Produtos>> BuscaPorCategoria(string nome)
        {
            Categoria categoriaRetornada = await context.Categoria.Where(c => c.CategoriaProduto == nome).FirstOrDefaultAsync();
            List<Produtos> produtoRetornado = await context.Produtos.Where(p => p.IdCategoria == categoriaRetornada.IdCategoria).ToListAsync();
            return produtoRetornado;
        }

        public async Task<Produtos> Delete(Produtos produtosDel)
        {
            context.Produtos.Remove(produtosDel);
            await context.SaveChangesAsync();
            return produtosDel;
        }

        public async Task<List<Produtos>> Get()
        {
            return await context.Produtos.Include(cat => cat.IdCategoriaNavigation).ToListAsync();
        }

        public async Task<Produtos> Get(int id)
        {
            return await context.Produtos.FindAsync(id);
        }

        public async Task<List<Produtos>> Get(string nome)
        {
            return await context.Produtos.Where(p => p.Nome.Contains(nome)).ToListAsync();//usar dois parametros 
        }

        public async Task<Produtos> Post(Produtos produtos)
        {
            await context.Produtos.AddAsync(produtos);
            await context.SaveChangesAsync();
            return produtos;
        }

        public async Task<Produtos> Put(Produtos produtos)
        {
            context.Entry(produtos).State = EntityState.Modified; 

            await context.SaveChangesAsync();
            
            return produtos;
        }
    }
}