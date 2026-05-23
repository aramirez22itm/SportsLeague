using System;
using System.Collections.Generic;

namespace SportsLeague.Domain.Entities
{
    public class Team : AuditBase
    {
        public string Name { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Stadium { get; set; } = null!;
        public string? LogoUrl { get; set; }
        public DateTime FoundedDate { get; set; }

        public ICollection<Player> Players { get; set; } = new List<Player>();
        public ICollection<TournamentTeam> TournamentTeams { get; set; } = new List<TournamentTeam>();
        public ICollection<Match> HomeMatches { get; set; } = new List<Match>();
        public ICollection<Match> AwayMatches { get; set; } = new List<Match>();
    }
}
