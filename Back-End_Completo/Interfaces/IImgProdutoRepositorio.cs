using System.Collections.Generic;
using System.Threading.Tasks;
using Back_End_Completo.Models;

namespace teste.Interfaces
{
    public interface IImgProdutoRepositorio
    {
        Task<ImgProduto> Post(ImgProduto produtosImagens);
        Task<ImgProduto> Put(int id, ImgProduto produtosImagens);
        Task<ImgProduto> Delete(ImgProduto produtosImagensDel);
        Task<List<ImgProduto>> Get();
        Task<ImgProduto> Id(int id);
    }
}