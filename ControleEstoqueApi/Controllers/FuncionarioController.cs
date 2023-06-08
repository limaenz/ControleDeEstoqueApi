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

        [HttpGet("{cpf}")]
        public async Task<ActionResult<FuncionarioModel>> BuscarPorCPF(string cpf)
        {
            FuncionarioModel funcionario = await _funcionarioRepositorio.BuscarPorCPF(cpf);

            if (funcionario is null)
                return BadRequest("Erro: esse funcionario não foi encontrado.");

            return Ok(funcionario);
        }

        [HttpPost]
        public async Task<ActionResult<FuncionarioModel>> Cadastar([FromBody] FuncionarioModel funcionarioModel)
        {
            FuncionarioModel funcionario = await _funcionarioRepositorio.Adicionar(funcionarioModel);

            if (funcionario is null)
                return BadRequest("Erro: esse funcionario já esta cadastrado.");

            return Ok(funcionario);
        }

        [HttpPut("{cpf}")]
        public async Task<ActionResult<FuncionarioModel>> Atualizar([FromBody] FuncionarioModel funcionarioModel, string cpf)
        {
            FuncionarioModel funcionario = await _funcionarioRepositorio.Atualizar(funcionarioModel, cpf);
            return Ok(funcionario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FuncionarioModel>> Apagar(string cpf)
        {
            bool apagado = await _funcionarioRepositorio.Apagar(cpf);
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
