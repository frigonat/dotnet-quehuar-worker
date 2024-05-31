using dotnet_quehuar_worker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using System.Reflection;

namespace dotnet_quehuar_worker.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Person> Person { get; set; }
    public DbSet<Numerador> Numerador { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);

    }

}
