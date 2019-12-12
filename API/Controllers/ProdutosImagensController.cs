using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using API.Models;
using API.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class ProdutosImagensController : ControllerBase
    {
        ProdutosRepositorio repositorio = new ProdutosRepositorio();


        [HttpPost, DisableRequestSizeLimit]
        public async Task<ActionResult<ImgProdutos>> Post(ImgProdutos produtosImagens) {

            
    }
    }
}
