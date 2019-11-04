using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;
using API___Ale.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API___Ale.Repositorio
{
    public class InteresseRepositorio : I_interesse
    {
        TWMarketplaceContext context = new TWMarketplaceContext();

        public async Task<Interesse> ApagarInteresse (int id){

            var interesse = await context.Interesse.FindAsync(id);
            context.Interesse.Remove(interesse);
            await context.SaveChangesAsync();
            
            return interesse;
        }

        public async Task<Interesse> DemonstrarInteresse(int id, Interesse interesse)
        {
            await context.AddAsync(interesse);
            await context.SaveChangesAsync();

            return interesse;
        }

        public async Task<List<Interesse>> MeusPedidos()
        {
            var interesses = await context.Interesse.Include(x => x.IdUsuarioNavigation).Include(y => y.IdProdutoNavigation).ToListAsync();
            return interesses;
        }

        public async Task<Interesse> MeusPedidos(int id)
        {
            var interesse = await context.Interesse.Include(x => x.IdUsuarioNavigation).Include(y => y.IdProdutoNavigation).FirstOrDefaultAsync(i => i.IdInteresse == id);
            return interesse;
        }
    }
}