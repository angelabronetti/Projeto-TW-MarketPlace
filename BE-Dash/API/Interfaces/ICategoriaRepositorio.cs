using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Task<List<Categoria>> Get();
        Task<Categoria> Get(string nome);
        Task<Categoria> Post( Categoria categoria);
        Task<Categoria> Put(Categoria categoria);
        Task<Categoria> Delete(Categoria categoriaDel);
    }
}