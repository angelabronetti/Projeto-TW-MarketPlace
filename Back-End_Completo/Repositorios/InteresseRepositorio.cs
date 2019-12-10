using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositorios
{
    public class InteresseRepositorio : IInteresseRepositorio
    {
        TWMPContext context = new TWMPContext();
        public Task<List<Interesse>> Get()
        {
            throw new System.NotImplementedException();
        }

        public Task<Interesse> Get(string nome)
        {
            throw new System.NotImplementedException();
        }
        public async Task<Interesse> Put(Interesse interesse)
        {
            context.Entry(interesse).State = EntityState.Modified; 

            await context.SaveChangesAsync();
            
            return interesse;
        }
        public async Task<List<Interesse>> Get(int id)
        {
            List<Interesse> listaInteresse = await context.Interesse.Where(i => i.IdProduto == id).ToListAsync();
            return listaInteresse;
        }
    }
}