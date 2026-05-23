using System;
using System.Collections.Generic;

namespace SportsLeague.Domain.Entities
{
    public enum PlayerPosition
    {
        Goalkeeper,
        Defender,
        Midfielder,
        Forward
    }

    public class Player : AuditBase
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public PlayerPosition Position { get; set; }
        public int Number { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; } = null!;

        public ICollection<Goal> Goals { get; set; } = new List<Goal>();
        public ICollection<Card> Cards { get; set; } = new List<Card>();
    }
}
