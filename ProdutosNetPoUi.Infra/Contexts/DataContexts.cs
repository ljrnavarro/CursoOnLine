using System.Reflection;
using ProdutosNetPoUi.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace ProdutosNetPoUi.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Produto> Produto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("Produto");
            modelBuilder.Entity<Produto>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Produto>().HasKey(x => x.Id);
            modelBuilder.Entity<Produto>().Property(x => x.Descricao).HasColumnType("vachar(100)");
            modelBuilder.Entity<Produto>().Property(x => x.Preco).HasColumnType("number");
            modelBuilder.Entity<Produto>().Property(x => x.DataCadastro);
            modelBuilder.Entity<Produto>().Property(x => x.Image).HasColumnType("varchar");
        }
    }
}