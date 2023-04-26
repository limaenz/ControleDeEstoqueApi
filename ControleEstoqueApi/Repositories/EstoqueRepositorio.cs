using ControleEstoqueApi.Data;
using ControleEstoqueApi.Models;
using ControleEstoqueApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.WebEncoders.Testing;
using System.Diagnostics.CodeAnalysis;

namespace ControleEstoqueApi.Repositories
{
    public class EstoqueRepositorio : IEstoqueRepositorio
    {
        private readonly ControleEstoqueDbContext _dbContext;
        public EstoqueRepositorio(ControleEstoqueDbContext controleEstoqueDbContext)
        {
            _dbContext = controleEstoqueDbContext;
        }

        public async Task<EstoqueModel> BuscarPorCodigoEstoque(string codigoEstoque)
        {
            return await _dbContext.Estoque
                .Include(x => x.Funcionario)
                .Include(x => x.Produto)
                .FirstOrDefaultAsync(x => x.Codigo == codigoEstoque);
        }

        public async Task<List<EstoqueModel>> BuscarTodosOsEstoque()
        {
            return await _dbContext.Estoque
                .Include(x => x.Funcionario)
                .Include(x => x.Produto)
                .ToListAsync();
        }

        public async Task<EstoqueModel> Adicionar(EstoqueModel estoque)
        {
            await _dbContext.Estoque.AddAsync(estoque);
            await _dbContext.SaveChangesAsync();

            return estoque;
        }
        public async Task<EstoqueModel> Atualizar(EstoqueModel estoque, string codigoEstoque)
        {
            var estoquePorId = await BuscarPorCodigoEstoque(codigoEstoque);

            if (estoquePorId is null)
                throw new Exception($"Usuário para o ID: {codigoEstoque} não foi encontrado.");

            estoquePorId.Codigo = estoque.Codigo;
            estoquePorId.Quantidade = estoque.Quantidade;
            estoquePorId.PrecoUnitario = estoque.PrecoUnitario;
            estoquePorId.NomeFuncionario = estoque.NomeFuncionario;

            _dbContext.Estoque.Update(estoquePorId);
            await _dbContext.SaveChangesAsync();

            return estoquePorId;
        }

        public async Task<bool> Apagar(string codigoEstoque)
        {
            var estoquePorId = await BuscarPorCodigoEstoque(codigoEstoque);

            if (estoquePorId is null)
                throw new Exception($"Usuário para o ID: {codigoEstoque} não foi encontrado.");

            _dbContext.Estoque.Remove(estoquePorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
