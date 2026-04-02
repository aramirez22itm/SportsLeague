using Microsoft.EntityFrameworkCore;
using SportsLeague.Domain.Entities;


namespace SportsLeague.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    // Esta línea le dice a Entity Framework que cree la tabla de Equipos en SQL Server 
    public DbSet<Team> Teams { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Referee> Referees { get; set; }
    public DbSet<Tournament> Tournaments { get; set; }

    public DbSet<Sponsor> Sponsors { get; set; }
    public DbSet<TournamentSponsor> TournamentSponsors { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Regla de negocio: El nombre del equipo debe ser único [cite: 90, 126]
        modelBuilder.Entity<Team>()
            .HasIndex(t => t.Name)
            .IsUnique();

        // Regla de negocio: El nombre del patrocinador debe ser único
        modelBuilder.Entity<Sponsor>()
            .HasIndex(s => s.Name)
            .IsUnique();

        // Configuración para TournamentSponsor
        modelBuilder.Entity<TournamentSponsor>()
            .HasIndex(ts => new { ts.TournamentId, ts.SponsorId })
            .IsUnique(); // Índice compuesto único (Punto 4.4 - Criterio 1)

        modelBuilder.Entity<TournamentSponsor>()
            .Property(ts => ts.ContractAmount)
            .HasPrecision(18, 2); // Configuración para decimales

    }
}