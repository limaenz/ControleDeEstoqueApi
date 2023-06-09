using Azure.Core;
using ControleEstoqueApi.Data;
using ControleEstoqueApi.Models;
using ControleEstoqueApi.Repositories.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoqueApi.Repositories
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private readonly ControleEstoqueDbContext _dbContext;
        public FuncionarioRepositorio(ControleEstoqueDbContext controleEstoqueDbContext)
        {
            _dbContext = controleEstoqueDbContext;
        }

        public async Task<FuncionarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Funcionarios.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<FuncionarioModel> BuscarPorCPF(string cpf)
        {
            return await _dbContext.Funcionarios.FirstOrDefaultAsync(x => x.CPF == cpf);
        }
        public async Task<FuncionarioModel> BuscarPorNome(string nome)
        {
            return await _dbContext.Funcionarios.FirstOrDefaultAsync(x => x.Nome == nome);
        }

        public async Task<FuncionarioModel> Adicionar(FuncionarioModel funcionario)
        {
            FuncionarioModel usuario = await _dbContext.Funcionarios.FirstOrDefaultAsync(U => U.CPF == funcionario.CPF);
            
            if (usuario != null)
            {
                return null;
            }
            else
            {
                await _dbContext.Funcionarios.AddAsync(funcionario);
                await _dbContext.SaveChangesAsync();
                return funcionario;
            }
        }
        public async Task<FuncionarioModel> Atualizar(FuncionarioModel funcionario, string cpf)
        {
            var funcionarioPorCpf = await BuscarPorCPF(cpf);

            if (funcionarioPorCpf is null)
                throw new Exception($"Usuário para o CPF: {funcionario.CPF} não foi encontrado.");

            if (funcionario.CPF is "")
                throw new Exception($"Usuário para o CPF: {funcionario.CPF} não foi encontrado.");

            funcionarioPorCpf.Nome = funcionario.Nome;
            funcionarioPorCpf.CPF = funcionario.CPF;

            _dbContext.Funcionarios.Update(funcionarioPorCpf);
            await _dbContext.SaveChangesAsync();

            return funcionarioPorCpf;
        }

        public async Task<bool> Apagar(string cpf)
        {
            var funcionarioPorCpf = await BuscarPorCPF(cpf);

            if (funcionarioPorCpf is null)
                throw new Exception($"Usuário para o ID: {cpf} não foi encontrado.");

            _dbContext.Funcionarios.Remove(funcionarioPorCpf);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<FuncionarioModel> Login(FuncionarioModel funcionario)
        {
            var usuario = await _dbContext.Funcionarios.FirstOrDefaultAsync(U => U.CPF == funcionario.CPF);
            var senha = await _dbContext.Funcionarios.FirstOrDefaultAsync(U => U.Senha == funcionario.Senha);

            if (usuario == null || senha == null)
            {
                return null;
            }

            return usuario;
        }
    }
}
