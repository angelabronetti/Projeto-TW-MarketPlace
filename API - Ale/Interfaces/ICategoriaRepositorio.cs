using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API_HOME.Interfaces
{
    public interface ICategoriaRepositorio
    {
         Task<List<Categoria>> Get();

        Task<Categoria> Get(string categoria_produto);

        
    }
}