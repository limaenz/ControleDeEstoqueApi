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

        public async Task<ProdutoModel> BuscarPorCodigoItem(string codigoItem)
        {
            return await _dbContext.Produto.FirstOrDefaultAsync(x => x.Codigo == codigoItem);
        }

        public async Task<List<ProdutoModel>> BuscarTodosOsProdutos()
        {
            return await _dbContext.Produto.ToListAsync();
        }

        public async Task<ProdutoModel> Adicionar(ProdutoModel produtoModel)
        {
            ProdutoModel produto = await _dbContext.Produto.FirstOrDefaultAsync(x => x.Codigo == produtoModel.Codigo);

            if (produto != null)
                return null;
            else
            {
                await _dbContext.Produto.AddAsync(produtoModel);
                await _dbContext.SaveChangesAsync();
                return produtoModel;
            }
        }
        public async Task<ProdutoModel> Atualizar(ProdutoModel produto, string codigoItem)
        {
            var produtoPorId = await BuscarPorCodigoItem(codigoItem);

            if (produtoPorId is null)
                throw new Exception($"Usuário para o ID: {codigoItem} não foi encontrado.");

            produtoPorId.Codigo = produto.Codigo;
            produtoPorId.Descricao = produto.Descricao;
            produtoPorId.Quantidade = produto.Quantidade;

            _dbContext.Produto.Update(produtoPorId);
            await _dbContext.SaveChangesAsync();

            return produtoPorId;
        }

        public async Task<bool> Apagar(string codigoItem)
        {
            var produtoPorId = await BuscarPorCodigoItem(codigoItem);

            if (produtoPorId is null)
                throw new Exception($"Usuário para o ID: {codigoItem} não foi encontrado.");

            _dbContext.Produto.Remove(produtoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
