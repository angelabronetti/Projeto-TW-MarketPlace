using System.Collections.Generic;
using System.Threading.Tasks;
using Back_End_Completo.Models;
using Microsoft.EntityFrameworkCore;
using teste.Interfaces;


namespace teste.Repositorios
{
    public class ImgProdutoRepositorio : IImgProdutoRepositorio
    {
        TWMPContext context = new TWMPContext();
        public async Task<ImgProduto> Delete(ImgProduto produtoImagensDel)
        {
            context.ImgProduto.Remove(produtoImagensDel);
            await context.SaveChangesAsync();
            return produtoImagensDel;
        }

        public async Task<ImgProduto> Post(ImgProduto produtoImagens)
        {
            await context.ImgProduto.AddAsync(produtoImagens);
            await context.SaveChangesAsync();
            return produtoImagens;
        }

        public async Task<ImgProduto> Put(int id, ImgProduto produtoImagens)
        {
            ImgProduto produtoImagensRetornado = await context.ImgProduto.FindAsync(id);
            produtoImagensRetornado.TwmpCaminhoImg = produtoImagens.TwmpCaminhoImg;
            await context.SaveChangesAsync();
            return produtoImagensRetornado;
        }

        public async Task<List<ImgProduto>> Get()
        {
            return await context.ImgProduto.Include(img => img.TwmpIdProdutoNavigation).ToListAsync();
        }

        public async Task<ImgProduto> Id(int id)
        {
            return await context.ImgProduto.FindAsync(id);
        }
    }
}