using System;

namespace SportsLeague.Domain.Entities
{
    public class Referee : AuditBase
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Nationality { get; set; } = null!;
    }
}
