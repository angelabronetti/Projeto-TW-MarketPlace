using System.Collections.Generic;
using System.Threading.Tasks;
using Back_End_Completo.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<ActionResult<ImgProduto>> Post([FromForm]ImgProduto produtoImagens){

            try
            {
                var arquivo = Request.Form.Files[0];
                produtoImagens.TwmpNome = Request.Form["nome"];
                produtoImagens.TwmpCaminhoImg = uploadRepositorio.Upload(arquivo,"ProdutoImg");
                produtoImagens.TwmpIdImgProduto = int.Parse(Request.Form["idproduto"]);
                repositorio.Post(produtoImagens);
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return produtoImagens;
    }
        [HttpGet]
        public async Task<ActionResult<List<ImgProduto>>> Get()
        {
           try{
               return await repositorio.Get();

            }catch(System.Exception ex){
               return BadRequest(new  {mensage = "Erro" + ex.Message});
           }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ImgProduto>> Put(int id, ImgProduto produtosImagens)//Definir sempre o tipo de retorno <categoria>
        {
            ImgProduto produtoImagensRetornado = await repositorio.Id(id); //buscando informação no banco
            if (produtoImagensRetornado == null)//verificando se é nulo
            {
                return NotFound("Produto não encontrada");//mensagem de erro
            }
           try{
               return await repositorio.Put(id, produtosImagens);// após a espera do retorno trás a informação de categoria (altera)
           }
           catch(System.Exception ex)//cria uma exceção
           {
                return BadRequest(new{mensagem = "Erro" + ex.Message});//caso haja erro informa-o
           }
        }

         [HttpDelete("{id}")]
        public async Task<ActionResult<ImgProduto>> Delete(int id)
        {
            ImgProduto produtoImagensDel = await repositorio.Id(id);
            if (produtoImagensDel == null)
            {
                return NotFound();
            }
            await repositorio.Delete(produtoImagensDel);
            return produtoImagensDel;
        }
    }
    }