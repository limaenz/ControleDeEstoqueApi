using ControleEstoqueApi.Models;

namespace ControleEstoqueApi.Repositories.Interfaces
{
    public interface IEstoqueRepositorio
    {
        Task<List<EstoqueModel>> BuscarTodosOsEstoque();
        Task<EstoqueModel> BuscarPorCodigoEstoque(string id);
        Task<EstoqueModel> Adicionar(EstoqueModel estoque);
        Task<EstoqueModel> Atualizar(EstoqueModel estoque, string id);
        Task<bool> Apagar(string id);
    }
}
