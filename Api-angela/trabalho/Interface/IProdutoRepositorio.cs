using System.Collections.Generic;
using System.Threading.Tasks;
using trabalho.Models;

namespace trabalho.Interface
{
    public interface IProdutoRepositorio
    {
        //Definindo todos os métodos que irão ter no repositório
        Task<List<Produtos>> Get();

        Task<Produtos> Get(string nome);

    }
}