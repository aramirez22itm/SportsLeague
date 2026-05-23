using System;
using System.Collections.Generic;
using SportsLeague.Domain.Enums;

namespace SportsLeague.Domain.Entities
{
    // public enum TournamentStatus
    //{
    //    Planned,
    //    InProgress,
    //    Finished
    //}

    public class Tournament : AuditBase
    {
        public string Name { get; set; } = null!;
        public string Season { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TournamentStatus Status { get; set; }

        public ICollection<TournamentTeam> TournamentTeams { get; set; } = new List<TournamentTeam>();
        public ICollection<Match> Matches { get; set; } = new List<Match>();
    }
}
