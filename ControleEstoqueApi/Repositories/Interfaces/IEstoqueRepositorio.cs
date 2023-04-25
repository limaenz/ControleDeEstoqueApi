using ControleEstoqueApi.Models;

namespace ControleEstoqueApi.Repositories.Interfaces
{
    public interface IEstoqueRepositorio
    {
        Task<List<EstoqueModel>> BuscarTodosOsProdutos();
        Task<EstoqueModel> BuscarPorId(int id);
        Task<EstoqueModel> Adicionar(EstoqueModel estoque);
        Task<EstoqueModel> Atualizar(EstoqueModel estoque, int id);
        Task<bool> Apagar(int id);
    }
}
