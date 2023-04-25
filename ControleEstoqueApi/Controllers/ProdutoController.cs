using ControleEstoqueApi.Models;
using ControleEstoqueApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace ControleEstoqueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoModel>>> BuscarTodosOsProdutos()
        {
            List<ProdutoModel> produtos = await _produtoRepositorio.BuscarTodosOsProdutos();
            return Ok(produtos);
        }

        [HttpGet("{codigoItem}")]
        public async Task<ActionResult<ProdutoModel>> BuscarPorId(string codigoItem)
        {
            ProdutoModel produto = await _produtoRepositorio.BuscarPorCodigoItem(codigoItem);
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> Cadastar([FromBody] ProdutoModel produtoModel)
        {
            ProdutoModel produto = await _produtoRepositorio.Adicionar(produtoModel);
            return Ok(produto);
        }

        [HttpPut("{codigoItem}")]
        public async Task<ActionResult<ProdutoModel>> Atualizar([FromBody] ProdutoModel produtoModel, string codigoItem)
        {
            produtoModel.Codigo = codigoItem;
            ProdutoModel produto = await _produtoRepositorio.Atualizar(produtoModel, codigoItem);
            return Ok(produto);
        }

        [HttpDelete("{codigoItem}")]
        public async Task<ActionResult<ProdutoModel>> Apagar(string codigoItem)
        {
            bool apagado = await _produtoRepositorio.Apagar(codigoItem);
            return Ok(apagado);
        }
    }
}
