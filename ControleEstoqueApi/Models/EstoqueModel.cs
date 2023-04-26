  namespace ControleEstoqueApi.Models
{
    public class EstoqueModel
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? CodigoItem { get; set; }
        public int? Quantidade { get; set; }
        public double? PrecoUnitario { get; set; }
        public string? NomeFuncionario { get; set; }
        public DateTime? DataDeEntrada { get; set; }
        public DateTime? DataDeSaida { get; set; }

        public int? FuncionarioId { get; set; }
        public int? ProdutoId { get; set; }

        public virtual ProdutoModel? Produto { get; set; }
        public virtual FuncionarioModel? Funcionario { get; set; }

    }
}
