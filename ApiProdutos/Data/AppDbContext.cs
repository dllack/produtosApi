using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProdutos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {

        }

        public DbSet<Produto> Produtos { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().Property(p => p.Nome).HasMaxLength(80);

            modelBuilder.Entity<Produto>().Property(p => p.Preco).HasPrecision(10, 2);

            modelBuilder.Entity<Produto>().HasData(
                    new Produto { Id = 1, Nome = "Caderno", Preco = 7.95M, Estoque = 10 },
                    new Produto { Id = 2, Nome = "Borracha", Preco = 2.95M, Estoque = 30 },
                    new Produto { Id = 3, Nome = "Lapis", Preco = 6.95M, Estoque = 15 }
                );
        }
    }
}
