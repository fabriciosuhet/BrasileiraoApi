using BrasileiraoApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrasileiraoApi.Infrastructure;

public class BrasileiraoDbContext : DbContext
{
    public BrasileiraoDbContext(DbContextOptions<BrasileiraoDbContext> options) : base(options) {}
    
    public DbSet<Jogador> Jogadores { get; set; }
    public DbSet<Titulo> Titulos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<Titulo>()
            .HasOne(t => t.Jogador)
            .WithMany()
            .HasForeignKey(t => t.JogadorId);
    }
}