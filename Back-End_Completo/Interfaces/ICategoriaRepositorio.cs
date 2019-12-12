using System.Collections.Generic;
using System.Threading.Tasks;
using Back_End_Completo.Models;

namespace API.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Task<List<Categoria>> Get();
        Task<Categoria> Get(string categoria_produto);
        Task<Categoria> Get(int id);
        Task<Categoria> Nome(string nome);
        Task<Categoria> Post( Categoria categoria);
        Task<Categoria> Put(Categoria categoria);
        Task<Categoria> Delete(Categoria categoriaDel);
    }
}