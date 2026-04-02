namespace SportsLeague.Domain.Entities;

public class TournamentSponsor
{
    public int Id { get; set; } // PK 

    public int TournamentId { get; set; } // FK a Tournament 
    public Tournament Tournament { get; set; } = null!; // Propiedad de navegación [cite: 68]

    public int SponsorId { get; set; } // FK a Sponsor 
    public Sponsor Sponsor { get; set; } = null!; // Propiedad de navegación [cite: 68]

    public decimal ContractAmount { get; set; } // Monto del contrato 
    public DateTime JoinedAt { get; set; } = DateTime.Now; // Fecha de vinculación 
}