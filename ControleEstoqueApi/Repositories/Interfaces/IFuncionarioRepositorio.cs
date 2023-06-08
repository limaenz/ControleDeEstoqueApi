using ControleEstoqueApi.Models;

namespace ControleEstoqueApi.Repositories.Interfaces
{
    public interface IFuncionarioRepositorio
    {
        Task<FuncionarioModel> BuscarPorCPF(string cpf);
        Task<FuncionarioModel> BuscarPorNome(string nome);
        Task<FuncionarioModel> Adicionar(FuncionarioModel funcionario);
        Task<FuncionarioModel> Atualizar(FuncionarioModel funcionario, string novoCpf);
        Task<bool> Apagar(string cpf);
        Task<FuncionarioModel> Login(FuncionarioModel funcionario);
    }
}
