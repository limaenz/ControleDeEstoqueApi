using ControleEstoqueApi.Models;

namespace ControleEstoqueApi.Repositories.Interfaces
{
    public interface IFuncionarioRepositorio
    {
        Task<List<FuncionarioModel>> BuscarTodosOsFuncionarios();
        Task<FuncionarioModel> BuscarPorId(int id);
        Task<FuncionarioModel> Adicionar(FuncionarioModel funcionario);
        Task<FuncionarioModel> Atualizar(FuncionarioModel funcionario, int id);
        Task<bool> Apagar(int id);
    }
}
