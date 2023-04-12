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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }
    }
}
