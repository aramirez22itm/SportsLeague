namespace SportsLeague.Domain.DTOs.Response
{
    public class TeamResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string TeamName { get; set; } // Aquí podemos devolver el nombre del equipo, no solo el ID
    }
}
