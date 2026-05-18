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
    public DbSet<TournamentTeam> TournamentTeams => Set<TournamentTeam>();
    public DbSet<Match> Matches => Set<Match>();
    public DbSet<MatchResult> MatchResults => Set<MatchResult>();
    public DbSet<Goal> Goals => Set<Goal>();
    public DbSet<Card> Cards => Set<Card>();

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

        modelBuilder.Entity<TournamentTeam>(entity =>
        {
            entity.HasKey(tt => tt.Id);

            entity.Property(tt => tt.RegisteredAt).IsRequired();
            entity.Property(tt => tt.CreatedAt).IsRequired();
            entity.Property(tt => tt.UpdatedAt).IsRequired(false);

            entity.HasOne(tt => tt.Tournament)
                .WithMany(t => t.TournamentTeams)
                .HasForeignKey(tt => tt.TournamentId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(tt => tt.Team)
                .WithMany(t => t.TournamentTeams)
                .HasForeignKey(tt => tt.TeamId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(tt => new { tt.TournamentId, tt.TeamId }).IsUnique();
        });
        modelBuilder.Entity<Match>(entity =>
        {
            entity.HasKey(m => m.Id);

            entity.Property(m => m.MatchDate).IsRequired();
            entity.Property(m => m.Venue).HasMaxLength(150);
            entity.Property(m => m.Matchday).IsRequired();
            entity.Property(m => m.Status).IsRequired();
            entity.Property(m => m.CreatedAt).IsRequired();
            entity.Property(m => m.UpdatedAt).IsRequired(false);

            entity.HasOne(m => m.Tournament)
                .WithMany(t => t.Matches)
                .HasForeignKey(m => m.TournamentId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(m => m.HomeTeam)
                .WithMany(t => t.HomeMatches)
                .HasForeignKey(m => m.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(m => m.AwayTeam)
                .WithMany(t => t.AwayMatches)
                .HasForeignKey(m => m.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(m => m.Referee)
                .WithMany(r => r.Matches)
                .HasForeignKey(m => m.RefereeId)
                .OnDelete(DeleteBehavior.Restrict);
        });
        modelBuilder.Entity<MatchResult>(entity =>
        {
            entity.HasKey(mr => mr.Id);

            entity.Property(mr => mr.HomeGoals).IsRequired();
            entity.Property(mr => mr.AwayGoals).IsRequired();

            entity.HasOne(mr => mr.Match)
                .WithOne(m => m.MatchResult)
                .HasForeignKey<MatchResult>(mr => mr.MatchId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Goal>(entity =>
        {
            entity.HasKey(g => g.Id);

            entity.Property(g => g.Minute).IsRequired();

            entity.HasOne(g => g.Match)
                .WithMany(m => m.Goals)
                .HasForeignKey(g => g.MatchId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(g => g.Player)
                .WithMany(p => p.Goals)
                .HasForeignKey(g => g.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(c => c.Id);

            entity.Property(c => c.Minute).IsRequired();

            entity.HasOne(c => c.Match)
                .WithMany(m => m.Cards)
                .HasForeignKey(c => c.MatchId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(c => c.Player)
                .WithMany(p => p.Cards)
                .HasForeignKey(c => c.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);
        });

    }

}