using System.Collections.Generic;
using System.Threading.Tasks;
using Back_End_Completo.Models;

namespace API.Interfaces
{
    public interface IInteresseRepositorio
    {
        Task<List<Interesse>> Get();
        Task<List<Interesse>> Get(int id);
        Task<Interesse> Get(string nome);
        Task<Interesse> Id(int id);
        Task<Interesse> Post(Interesse interesse);
        Task<Interesse> Put(int id, Interesse interesse);
       
    }
}