using ControleEstoqueApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleEstoqueApi.Data.Map
{
    public class EstoqueMap : IEntityTypeConfiguration<EstoqueModel>
    {
        public void Configure(EntityTypeBuilder<EstoqueModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Codigo).IsRequired();
            builder.Property(x => x.Quantidade).IsRequired();
            builder.Property(x => x.PrecoUnitario).IsRequired();
            builder.Property(x => x.CodigoItem).IsRequired().HasMaxLength(10);
            builder.Property(x => x.NomeFuncionario).IsRequired().HasMaxLength(50);
            builder.Property(x => x.DataDeEntrada);
            builder.Property(x => x.DataDeSaida);

            builder.Property(x => x.ProdutoId);
            builder.Property(x => x.FuncionarioId);

            builder.HasOne(x => x.Produto);
            builder.HasOne(x => x.Funcionario);
        }
    }
}
