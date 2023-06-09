using ControleEstoqueApi.Models;
using ControleEstoqueApi.Repositories;
using ControleEstoqueApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Cryptography.Xml;

namespace ControleEstoqueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueRepositorio _estoqueRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;

        public EstoqueController(IEstoqueRepositorio estoqueRepositorio, IProdutoRepositorio produtoRepositorio,
            IFuncionarioRepositorio funcionarioRepositorio)
        {
            _estoqueRepositorio = estoqueRepositorio;
            _produtoRepositorio = produtoRepositorio;
            _funcionarioRepositorio = funcionarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<EstoqueModel>>> BuscarTodosOsEstoques()
        {
            List<EstoqueModel> estoques = await _estoqueRepositorio.BuscarTodosOsEstoque();
            return Ok(estoques);
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<EstoqueModel>> BuscarPorCodigo(string codigo)
        {
            EstoqueModel estoque = await _estoqueRepositorio.BuscarPorCodigoEstoque(codigo);
            return Ok(estoque);
        }

        [HttpPost]
        public async Task<ActionResult<EstoqueModel>> Cadastar([FromBody] EstoqueModel estoqueModel)
        {
            EstoqueModel estoque = await _estoqueRepositorio.Adicionar(estoqueModel);
            ProdutoModel produto = await _produtoRepositorio.BuscarPorCodigoItem(estoqueModel.CodigoItem);
            FuncionarioModel funcionario = await _funcionarioRepositorio.BuscarPorNome(estoqueModel.NomeFuncionario);

            if (estoque is not null)
                return BadRequest("Erro: codigo do estoque já foi cadastrado.");
            else if (produto is null)
                return BadRequest("Erro: codigo do item não encontrado.");
            else if (funcionario is null)
                return BadRequest("Erro: nome do funcionário não encontrado.");

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
