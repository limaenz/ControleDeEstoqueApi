using ControleEstoqueApi.Models;

namespace ControleEstoqueApi.Repositories.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<List<ProdutoModel>> BuscarTodosOsProdutos();
        Task<ProdutoModel> BuscarPorCodigoItem(string codigoItem);
        Task<ProdutoModel> Adicionar(ProdutoModel produto);
        Task<ProdutoModel> Atualizar(ProdutoModel produto, string codigoItem);
        Task<bool> Apagar(string codigoItem);
    }
}
