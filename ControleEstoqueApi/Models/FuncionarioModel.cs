  namespace ControleEstoqueApi.Models
{
    public class FuncionarioModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int? Senha { get; set; }
        public string? CPF { get; set; }
        public string? Cargo { get; set; }
    }
}
