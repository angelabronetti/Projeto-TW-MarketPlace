using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using trabalho.Interface;
using trabalho.Models;

namespace trabalho.Repositorio
{
    public class InteresseRepositorio : IInteresseRepositorio

    {
        TWMarketplaceContext context = new TWMarketplaceContext();
        public async Task<List<Interesse>> Get()
        {
            return await context.Interesse.ToListAsync();
        }
        public async Task<Interesse> Get(int id)
        {
            return await context.Interesse.FindAsync(id);
        }

        public async Task<Interesse> Post(Interesse interesse)
        {
            await context.Interesse.AddAsync(interesse);
            await context.SaveChangesAsync();
            return interesse;
        }

        public async Task<Interesse> Put(int id, Interesse interesse)
        {
            Interesse interesseRetornado = await context.Interesse.FindAsync(id);
            interesseRetornado.StatusCompra = interesse.StatusCompra;
            await context.SaveChangesAsync();
            return interesseRetornado;
         }

    }
}