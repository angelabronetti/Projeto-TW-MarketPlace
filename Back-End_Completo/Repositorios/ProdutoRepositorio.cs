using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using Back_End_Completo.Models;
using Microsoft.EntityFrameworkCore;


namespace trabalho.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        TWMPContext context = new TWMPContext();
        public async Task<List<Produto>> BuscaPorCategoria(string nome)
        {
            Categoria categoriaRetornada = await context.Categoria.Where(c => c.TwmpCategoriaProduto == nome).FirstOrDefaultAsync();
            List<Produto> produtoRetornado = await context.Produto.Where(p => p.TwmpIdCategoria == categoriaRetornada.TwmpIdCategoria).ToListAsync();
            return produtoRetornado;
        }

        public async Task<Produto> Delete(Produto produtosDel)
        {
            context.Produto.Remove(produtosDel);
            await context.SaveChangesAsync();
            return produtosDel;
        }

        public async Task<List<Produto>> Get()
        {
            return await context.Produto.Include(cat => cat.TwmpIdCategoriaNavigation).ToListAsync();
        }

        public async Task<Produto> Get(int id)
        {
            return await context.Produto.FindAsync(id);
        }

        public async Task<List<Produto>> Get(string nome)
        {
            return await context.Produto.Where(p => p.TwmpNome.Contains(nome)).ToListAsync();
        }

        public async Task<Produto> Post(Produto produtos)
        {
            await context.Produto.AddAsync(produtos);
            await context.SaveChangesAsync();
            return produtos;
        }

        public async Task<Produto> Put(Produto produtos)
        {
            context.Entry(produtos).State = EntityState.Modified; 

            await context.SaveChangesAsync();
            
            return produtos;
        }
    }
}