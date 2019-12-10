using System.Threading.Tasks;
using teste.Interfaces;
using teste.Models;

namespace teste.Repositorios
{
    public class ImgProdutoRepositorio : IImgProdutoRepositorio
    {
        TWMarketplaceContext context = new TWMarketplaceContext();
        public async Task<ImgProduto> Delete(ImgProduto produtosImagensDel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ImgProduto> Post(ImgProduto produtosImagens)
        {
            await context.ImgProduto.AddAsync(produtosImagens);
            await context.SaveChangesAsync();
            return produtosImagens;
        }

        public async Task<ImgProduto> Put(ImgProduto produtosImagens)
        {
            throw new System.NotImplementedException();
        }
    }
}