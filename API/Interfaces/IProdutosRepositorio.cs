using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.Interfaces
{
    public interface IProdutosRepositorio
    {
        Task<List<Produtos>> Get();
        Task<Produtos> Get(int id);
        Task<List<Produtos>> Get(string nome);
        Task<List<Produtos>> BuscaPorCategoria(string nome);
        Task<Produtos> Post(Produtos produtos);
        Task<Produtos> Put(Produtos produtos);
        Task<Produtos> Delete(Produtos produtosDel);
    }
}