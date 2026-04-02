using SportsLeague.Domain.Enums;

namespace SportsLeague.Domain.Entities;

public class Sponsor
{
    public int Id { get; set; } // PK, autoincremental 
    public string Name { get; set; } = null!; // Nombre del patrocinador 
    public string ContactEmail { get; set; } = null!; // Email de contacto 
    public string? Phone { get; set; } // Teléfono (Opcional) 
    public string? WebsiteUrl { get; set; } // Sitio web (Opcional) 
    public SponsorCategory Category { get; set; } // Enum: categoría 
    public DateTime CreatedAt { get; set; } = DateTime.Now; // Fecha de creación 
    public DateTime? UpdatedAt { get; set; } // Fecha de actualización 
}