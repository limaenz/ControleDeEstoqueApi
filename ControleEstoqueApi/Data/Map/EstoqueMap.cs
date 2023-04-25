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
            builder.Property(x => x.Quantidade).IsRequired().HasMaxLength(50);
            builder.Property(x => x.PrecoUnitario).IsRequired().HasMaxLength(50);
            
            builder.HasOne(x => x.Produto);
            builder.HasOne(x => x.Funcionario);
        }
    }
}
