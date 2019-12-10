using System.Threading.Tasks;
using teste.Models;

namespace teste.Interfaces
{
    public interface IImgProdutoRepositorio
    {
        Task<ImgProduto> Post(ImgProduto produtosImagens);
        Task<ImgProduto> Put(ImgProduto produtosImagens);
        Task<ImgProduto> Delete(ImgProduto produtosImagensDel);
    }
}