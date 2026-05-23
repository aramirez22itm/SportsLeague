using Microsoft.EntityFrameworkCore;
using SportsLeague.Domain.Entities;


namespace SportsLeague.DataAccess.Context;

    public class LeagueDbContext : DbContext
    {
        public LeagueDbContext(DbContextOptions<LeagueDbContext> options) : base(options)
        {
        }

        public DbSet<Team> Teams => Set<Team>();
        public DbSet<Card> Cards => Set<Card>();
        public DbSet<Goal> Goals => Set<Goal>();
        public DbSet<Match> Matches => Set<Match>();
        public DbSet<MatchResult> MatchResults => Set<MatchResult>();
        public DbSet<Player> Players => Set<Player>();
        public DbSet<Referee> Referees => Set<Referee>();
        public DbSet<Tournament> Tournaments => Set<Tournament>();
        public DbSet<TournamentTeam> TournamentTeams => Set<TournamentTeam>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Team>(entity =>
        {
                entity.HasKey(t => t.Id);

                entity.Property(t => t.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(t => t.City)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(t => t.Stadium)
                    .HasMaxLength(150);

                entity.Property(t => t.LogoUrl)
                    .HasMaxLength(500);

                entity.HasIndex(t => t.Name).IsUnique();
        });
    }

}

