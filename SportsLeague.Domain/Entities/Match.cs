using SportsLeague.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace SportsLeague.Domain.Entities
{
    public class Match : AuditBase
    {
        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; } = null!;

        public int HomeTeamId { get; set; }

        [NotMapped]
        public Team HomeTeam { get; set; } = null!;

        [NotMapped]
        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; } = null!;

        public int RefereeId { get; set; }
        public Referee Referee { get; set; } = null!;

        public DateTime MatchDate { get; set; }
        public string Venue { get; set; } = null!;
        public MatchStatus Status { get; set; }

        public MatchResult MatchResult { get; set; } = null!;
        public ICollection<Goal> Goals { get; set; } = new List<Goal>();
        public ICollection<Card> Cards { get; set; } = new List<Card>();
    }
}
