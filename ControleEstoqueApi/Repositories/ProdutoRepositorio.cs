using ControleEstoqueApi.Data;
using ControleEstoqueApi.Models;
using ControleEstoqueApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.WebEncoders.Testing;
using System.Diagnostics.CodeAnalysis;

namespace ControleEstoqueApi.Repositories
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly ControleEstoqueDbContext _dbContext;
        public ProdutoRepositorio(ControleEstoqueDbContext controleEstoqueDbContext)
        {
            _dbContext = controleEstoqueDbContext;
        }

        public async Task<ProdutoModel> BuscarPorId(int id)
        {
            return await _dbContext.Produto.FirstOrDefaultAsync(X => X.Id == id);
        }

        public async Task<List<ProdutoModel>> BuscarTodosOsProdutos()
        {
            return await _dbContext.Produto.ToListAsync();
        }

        public async Task<ProdutoModel> Adicionar(ProdutoModel produto)
        {
            await _dbContext.Produto.AddAsync(produto);
            await _dbContext.SaveChangesAsync();

            return produto;
        }
        public async Task<ProdutoModel> Atualizar(ProdutoModel produto, int id)
        {
            var produtoPorId = await BuscarPorId(id);

            if (produtoPorId is null)
                throw new Exception($"Usuário para o ID: {id} não foi encontrado.");

            produtoPorId.Codigo = produto.Codigo;
            produtoPorId.Descricao = produto.Descricao;
            produtoPorId.Quantidade = produto.Quantidade;

            _dbContext.Produto.Update(produtoPorId);
            await _dbContext.SaveChangesAsync();

            return produtoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            var produtoPorId = await BuscarPorId(id);

            if (produtoPorId is null)
                throw new Exception($"Usuário para o ID: {id} não foi encontrado.");

            _dbContext.Produto.Remove(produtoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
