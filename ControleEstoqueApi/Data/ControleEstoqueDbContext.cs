using ControleEstoqueApi.Data.Map;
using ControleEstoqueApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoqueApi.Data
{
    public class ControleEstoqueDbContext : DbContext
    {
        public ControleEstoqueDbContext(DbContextOptions<ControleEstoqueDbContext> options)
            : base(options) 
        {
        }

        public DbSet<FuncionarioModel> Funcionarios { get; set; }
        public DbSet<EstoqueModel> Estoque { get; set; }
        public DbSet<ProdutoModel> Produto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new EstoqueMap());

            base.OnModelCreating(modelBuilder); 
        }
    }
}
