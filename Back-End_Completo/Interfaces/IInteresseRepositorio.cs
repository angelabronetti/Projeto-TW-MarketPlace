using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Interfaces
{
    public interface IInteresseRepositorio
    {
        Task<List<Interesse>> Get();
        Task<Interesse> Get(string nome);
        Task<List<Interesse>> Get(int id);
        Task<Interesse> Put(Interesse interesse);
       
    }
}