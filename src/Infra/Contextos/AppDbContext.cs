using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infra.Contextos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Veiculo> Veiculos { get; init; }
        public DbSet<Onibus> Onibus { get; init; }
        public DbSet<Caminhao> Caminhoes { get; init; }
    }
}