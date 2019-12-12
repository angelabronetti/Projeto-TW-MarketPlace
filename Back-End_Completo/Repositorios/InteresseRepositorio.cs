using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using Back_End_Completo.Models;
using Microsoft.EntityFrameworkCore;


namespace trabalho.Repositorio
{
    public class InteresseRepositorio : IInteresseRepositorio

    {
        TWMPContext context = new TWMPContext();
        public async Task<List<Interesse>> Get(int id)
        {
            List<Interesse> listaInteresse = await context.Interesse.Where(i => i.TwmpIdProduto == id).ToListAsync();
            return listaInteresse;
        }
        public async Task<List<Interesse>> Get()
        {
             return await context.Interesse.ToListAsync();
        }

        public Task<Interesse> Get(string nome)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Interesse> Id(int id)
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
            interesseRetornado.TwmpInteresseCompra = interesse.TwmpInteresseCompra;
            await context.SaveChangesAsync();
            return interesseRetornado;
        }
    }
}