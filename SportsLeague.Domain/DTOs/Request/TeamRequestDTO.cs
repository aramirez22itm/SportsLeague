namespace SportsLeague.Domain.DTOs.Request
{
    public class TeamRequestDTO
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public int TeamId { get; set; }
    }
}