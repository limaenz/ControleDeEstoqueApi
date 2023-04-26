using ControleEstoqueApi.Models;
using ControleEstoqueApi.Repositories;
using ControleEstoqueApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoqueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueRepositorio _estoqueRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;

        public EstoqueController(IEstoqueRepositorio estoqueRepositorio)
        {
            _estoqueRepositorio = estoqueRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<EstoqueModel>>> BuscarTodosOsEstoques()
        {
            List<EstoqueModel> estoques = await _estoqueRepositorio.BuscarTodosOsEstoque();
            return Ok(estoques);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstoqueModel>> BuscarPorId(string codigoEstoque)
        {
            EstoqueModel estoque = await _estoqueRepositorio.BuscarPorCodigoEstoque(codigoEstoque);
            return Ok(estoque);
        }

        [HttpPost]
        public async Task<ActionResult<EstoqueModel>> Cadastar([FromBody] EstoqueModel estoqueModel)
        {
            estoqueModel.DataDeEntrada = DateTime.Now;

            if (estoqueModel.DataDeSaida == null)
                estoqueModel.DataDeSaida = null;

            EstoqueModel estoque = await _estoqueRepositorio.Adicionar(estoqueModel);
            return Ok(estoque);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EstoqueModel>> Atualizar([FromBody] EstoqueModel estoqueModel, string codigoEstoque)
        {
            estoqueModel.Codigo = codigoEstoque;
            EstoqueModel estoque = await _estoqueRepositorio.Atualizar(estoqueModel, codigoEstoque);
            return Ok(estoque);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EstoqueModel>> Apagar(string codigoEstoque)
        {
            bool apagado = await _estoqueRepositorio.Apagar(codigoEstoque);
            return Ok(apagado);
        }
    }
}
