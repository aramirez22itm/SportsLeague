using System;

namespace SportsLeague.Domain.Entities
{
    public class TournamentTeam : AuditBase
    {
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; } = null!;

        public int TeamId { get; set; }
        public Team Team { get; set; } = null!;

        public DateTime RegisteredAt { get; set; }
    }
}
