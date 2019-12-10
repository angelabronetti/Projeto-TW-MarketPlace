using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using teste.Models;
using teste.Repositorios;

namespace teste.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class ImgProdutoController : ControllerBase
    {
        ImgProdutoRepositorio repositorio = new ImgProdutoRepositorio();
        UploadRepositorio uploadRepositorio = new UploadRepositorio();

        [HttpPost]

        public async Task<ActionResult<ImgProduto>> Post([FromForm]ImgProduto produtosImagens){

            try
            {
                var arquivo = Request.Form.Files[0];
                produtosImagens.Nome = Request.Form["nome"];
                produtosImagens.CaminhoImg = uploadRepositorio.Upload(arquivo,"ProdutoImg");
                produtosImagens.IdImgproduto = int.Parse(Request.Form["idproduto"]);
                repositorio.Post(produtosImagens);
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return produtosImagens;
    }
    }}