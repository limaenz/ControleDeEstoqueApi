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
            return await _dbContext.Funcionarios.FirstOrDefaultAsync(X => X.Id == id);
        }
        public async Task<FuncionarioModel> BuscarPorCPF(string cpf)
        {
            return await _dbContext.Funcionarios.FirstOrDefaultAsync(X => X.CPF == cpf);
        }

        public async Task<List<FuncionarioModel>> BuscarTodosOsFuncionarios()
        {
            return await _dbContext.Funcionarios.ToListAsync();
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
        public async Task<FuncionarioModel> Atualizar(FuncionarioModel funcionario, int id)
        {
            var funcionarioPorId = await BuscarPorId(id);

            if (funcionarioPorId is null)
                throw new Exception($"Usuário para o ID: {id} não foi encontrado.");

            funcionarioPorId.Nome = funcionario.Nome;
            funcionarioPorId.CPF = funcionario.CPF;

            _dbContext.Funcionarios.Update(funcionarioPorId);
            await _dbContext.SaveChangesAsync();

            return funcionarioPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            var funcionarioPorId = await BuscarPorId(id);

            if (funcionarioPorId is null)
                throw new Exception($"Usuário para o ID: {id} não foi encontrado.");

            _dbContext.Funcionarios.Remove(funcionarioPorId);
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
