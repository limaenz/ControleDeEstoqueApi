using Azure.Core;
using ControleEstoqueApi.Models;
using ControleEstoqueApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControleEstoqueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioRepositorio _funcionarioRepositorio;

        public FuncionarioController(IFuncionarioRepositorio funcionarioRepositorio)
        {
            _funcionarioRepositorio = funcionarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<FuncionarioModel>>> BuscarTodosUsuarios()
        {
            List<FuncionarioModel> funcionarios = await _funcionarioRepositorio.BuscarTodosOsFuncionarios();
            return Ok(funcionarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FuncionarioModel>> BuscarPorId(int id)
        {
            FuncionarioModel funcionario = await _funcionarioRepositorio.BuscarPorId(id);
            return Ok(funcionario);
        }

        [HttpPost]
        public async Task<ActionResult<FuncionarioModel>> Cadastar([FromBody] FuncionarioModel funcionarioModel)
        {
            FuncionarioModel funcionario = await _funcionarioRepositorio.Adicionar(funcionarioModel);

            if (funcionario == null)
            {
                return BadRequest("Credenciais inválidas.");
            }

            return Ok(funcionario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FuncionarioModel>> Atualizar([FromBody] FuncionarioModel funcionarioModel, int id)
        {
            funcionarioModel.Id = id;
            FuncionarioModel funcionario = await _funcionarioRepositorio.Atualizar(funcionarioModel, id);
            return Ok(funcionario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FuncionarioModel>> Apagar(int id)
        {
            bool apagado = await _funcionarioRepositorio.Apagar(id);
            return Ok(apagado);
        }

        [HttpPost("login")]
        public async Task<ActionResult<FuncionarioModel>> Login([FromBody] FuncionarioModel funcionario)
        {
            var usuario = await _funcionarioRepositorio.Login(funcionario);

            if (usuario == null)
            {
                return BadRequest("Credenciais inválidas.");
            }

            return Ok(usuario);
        }
    }
}
