using System.Reflection;
using CursoOnline.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace CursoOnline.Domain.Infra.Contexts
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

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Cartao> Cartao { get; set; }
        public DbSet<Matricula> Matricula { get; set; }
        public DbSet<Pagamento> Pagamento { get; set; }
        public DbSet<Curso> Curso { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().ToTable("Aluno");
            modelBuilder.Entity<Aluno>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Aluno>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Aluno>().HasKey(x => x.Id);
            modelBuilder.Entity<Aluno>().Property(x => x.CPF).HasColumnType("vachar(11)");
            modelBuilder.Entity<Aluno>().Property(x => x.Email).HasColumnType("vachar(200)");
            modelBuilder.Entity<Aluno>().Property(x => x.Nascimento);
            modelBuilder.Entity<Aluno>().Property(x => x.RefUser).HasColumnType("vachar(120)");

            modelBuilder.Entity<Curso>().ToTable("Curso");
            modelBuilder.Entity<Curso>().Property(x => x.Id).ValueGeneratedOnAdd();;
            modelBuilder.Entity<Curso>().HasKey(x => x.Id);
            modelBuilder.Entity<Curso>().Property(x => x.Titulo).HasColumnType("varchar(100)");
            modelBuilder.Entity<Curso>().Property(x => x.Descricao).HasColumnType("vachar(300)");
            modelBuilder.Entity<Curso>().Property(x => x.Nivel).HasColumnType("vachar(200)");

            modelBuilder.Entity<Cartao>().ToTable("Cartao");
            modelBuilder.Entity<Cartao>().Property(x => x.Id).ValueGeneratedOnAdd();;
            modelBuilder.Entity<Cartao>().HasKey(x => x.Id);
            modelBuilder.Entity<Cartao>().Property(x => x.Numero);
            modelBuilder.Entity<Cartao>().Property(x => x.Validade).HasColumnType("vachar(10)");
            modelBuilder.Entity<Cartao>().Property(x => x.Bandeira).HasColumnType("vachar(200)");
            modelBuilder.Entity<Cartao>()
                                         .HasOne(p => p.Aluno)
                                         .WithMany(a => a.Cartoes)
                                         .HasForeignKey(p => p.IdAluno)
                                         .IsRequired(true);

            modelBuilder.Entity<Pagamento>().ToTable("Pagamento");
            modelBuilder.Entity<Pagamento>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Pagamento>().HasKey(x => x.Id);
            modelBuilder.Entity<Pagamento>().Property(x => x.Data);
            modelBuilder.Entity<Pagamento>().Property(x => x.Valor);
            modelBuilder.Entity<Pagamento>().HasOne(p => p.Aluno)
                                         .WithMany()
                                         .HasForeignKey(p => p.idAluno);
            modelBuilder.Entity<Pagamento>().HasOne(p => p.Cartao)
                                         .WithMany()
                                         .HasForeignKey(p => p.idCartao);

            modelBuilder.Entity<Matricula>().ToTable("Matricula");
            modelBuilder.Entity<Matricula>().Property(x => x.Id).ValueGeneratedOnAdd();;
            modelBuilder.Entity<Matricula>().HasKey(x => x.Id);
            modelBuilder.Entity<Matricula>().Property(x => x.Data);
            modelBuilder.Entity<Matricula>().HasOne(p => p.Aluno)
                                         .WithMany()
                                         .HasForeignKey(p => p.IdAluno);
            modelBuilder.Entity<Matricula>().HasOne(p => p.Curso)
                                         .WithMany()
                                         .HasForeignKey(p => p.IdCurso);
                                         
        }
    }
}