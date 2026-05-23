namespace SportsLeague.Domain.DTOs.Request
{
    public class PlayerRequestDTO
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public int TeamId { get; set; }
    }
}