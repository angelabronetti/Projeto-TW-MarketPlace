using System.Collections.Generic;
using System.Threading.Tasks;
using Back_End_Completo.Models;

namespace API.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<List<Produto>> Get();
        Task<Produto> Get(int id);
        Task<List<Produto>> Get(string nome);
        Task<List<Produto>> BuscaPorCategoria(string nome);
        Task<Produto> Post(Produto produtos);
        Task<Produto> Put(Produto produtos);
        Task<Produto> Delete(Produto produtosDel);
    }
}