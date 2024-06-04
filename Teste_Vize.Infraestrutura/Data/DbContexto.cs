using Microsoft.EntityFrameworkCore;
using Teste_Vize.Dominio.Modelos;

namespace Teste_Vize.Infraestrutura.Data;

public class DbContexto : DbContext
{
    public DbContexto(DbContextOptions<DbContexto> opcao) : base(opcao)
    {

    }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<AcessoAPI> AcessoAPI { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AcessoAPI>()
            .HasKey(x => x.AcessoId);
        modelBuilder.Entity<AcessoAPI>()
            .Property(x => x.AcessoId)
            .ValueGeneratedOnAdd();
        modelBuilder.Entity<AcessoAPI>().HasData(
            new AcessoAPI { AcessoId = 1, Login = "admin", Senha = "admin"}
            );

        modelBuilder.Entity<Produto>().HasData(
            new Produto { Id = 1, Nome = "Teclado Mecânico", Tipo = TipoProduto.Material, PrecoUnitario = 250.00m },
            new Produto { Id = 2, Nome = "Mouse Gamer", Tipo = TipoProduto.Material, PrecoUnitario = 150.00m },
            new Produto { Id = 3, Nome = "Formatação", Tipo = TipoProduto.Servico, PrecoUnitario = 150.00m },
            new Produto { Id = 4, Nome = "Instalação de Hardware", Tipo = TipoProduto.Servico, PrecoUnitario = 100.00m }
        );
    }
}