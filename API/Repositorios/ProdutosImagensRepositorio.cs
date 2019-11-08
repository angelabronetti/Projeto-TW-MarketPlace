using System.Threading.Tasks;
using API.Interfaces;
using API.Models;

namespace API.Repositorios
{
    public class ProdutosImagensRepositorio : IProdutosImagensRepositorio
    {
        TWMarketplaceContext context = new TWMarketplaceContext();
        public async Task<ImgProdutos> Delete(ImgProdutos produtosImagensDel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ImgProdutos> Post(ImgProdutos produtosImagens)
        {
            await context.ImgProdutos.AddAsync(produtosImagens);
            await context.SaveChangesAsync();
            return produtosImagens;
        }

        public async Task<ImgProdutos> Put(ImgProdutos produtosImagens)
        {
            throw new System.NotImplementedException();
        }
    }
}