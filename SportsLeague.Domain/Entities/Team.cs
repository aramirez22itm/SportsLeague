namespace SportsLeague.Domain.Entities;

public class Team
{
    public int Id { get; set; } // Identificador único 
    public string Name { get; set; } = string.Empty; // Nombre del equipo 
    public string City { get; set; } = string.Empty; // Ciudad de origen 
    public string? Stadium { get; set; } // Nombre del estadio 
    public string? LogoUrl { get; set; } // URL del logo 
    public DateTime FoundedDate { get; set; } // Fecha de fundación 
    public DateTime CreatedAt { get; set; } = DateTime.Now; // Auditoría [cite: 87]
    public DateTime? UpdatedAt { get; set; } // Auditoría [cite: 87]
}