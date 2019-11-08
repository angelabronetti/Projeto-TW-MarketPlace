using System.Threading.Tasks;
using API.Models;

namespace API.Interfaces
{
    public interface IProdutosImagensRepositorio
    {
        Task<ImgProdutos> Post(ImgProdutos produtosImagens);
        Task<ImgProdutos> Put(ImgProdutos produtosImagens);
        Task<ImgProdutos> Delete(ImgProdutos produtosImagensDel);
    }
    
}