using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API___Ale.Interfaces
{
    public interface I_interesse
    {
        Task<List<Interesse>> MeusPedidos();
        Task<Interesse> MeusPedidos(int id);
        Task<Interesse> DemonstrarInteresse(int id, Interesse interesse);
        Task<Interesse> ApagarInteresse(int id);
    }
}