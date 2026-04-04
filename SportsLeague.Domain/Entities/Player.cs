namespace SportsLeague.Domain.Entities;

public class Player
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Number { get; set; }
    public int TeamId { get; set; } // Relación con Equipo
    public Team Team { get; set; } = null!;
}
