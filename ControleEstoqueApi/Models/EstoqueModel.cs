  namespace ControleEstoqueApi.Models
{
    public class EstoqueModel
    {
        public int Id { get; set; }
        public int? Quantidade { get; set; }
        public int? PrecoUnitario { get; set; }
        public DateTime? DataDeEntrada { get; set; }
        public DateTime? DataDeSaida { get; set; }

        public string? CodigoItem { get; set; }
        public string? DescricaoItem { get; set; }
        public string? NomeFuncionario { get; set; }

        public int IdFuncionario { get; set; }
        public int IdProduto { get; set; }

        public virtual ProdutoModel? Produto { get; set; }
        public virtual FuncionarioModel? Funcionario { get; set; }

    }
}
