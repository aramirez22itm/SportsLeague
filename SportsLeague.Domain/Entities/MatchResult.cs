using System;

namespace SportsLeague.Domain.Entities
{
    public class MatchResult : AuditBase
    {
        public int MatchId { get; set; }
        public Match Match { get; set; } = null!;

        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
        public string? Observations { get; set; }
    }
}
