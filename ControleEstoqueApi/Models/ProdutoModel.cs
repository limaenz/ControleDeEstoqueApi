  namespace ControleEstoqueApi.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Descricao { get; set; }
        public int? Quantidade { get; set; }
    }
}
