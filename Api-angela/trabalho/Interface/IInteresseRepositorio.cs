using System.Collections.Generic;
using System.Threading.Tasks;
using trabalho.Models;

namespace trabalho.Interface
{
    public interface IInteresseRepositorio
    {
        //Definindo todos os métodos que irão ter no repositório
        Task<List<Interesse>> Get();

        Task<Interesse> Get(int id);

        Task<Interesse> Post(Interesse interesse);

        Task<Interesse> Put(int id, Interesse interesse);
    }
}