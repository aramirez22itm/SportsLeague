using SportsLeague.Domain.Enums;

namespace SportsLeague.Domain.Entities
{
    public class Goal : AuditBase
    {
        public int MatchId { get; set; }
        public Match Match { get; set; } = null!;
        public int PlayerId { get; set; }
        public Player Player { get; set; } = null!;
        public int Minute { get; set; }
        public GoalType Type { get; set; }
    }
}
