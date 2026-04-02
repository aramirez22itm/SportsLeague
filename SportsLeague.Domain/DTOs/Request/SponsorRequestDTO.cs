using SportsLeague.Domain.Enums;

namespace SportsLeague.Domain.DTOs.Request;

public class SponsorRequestDTO
{
    public string Name { get; set; } = null!;
    public string ContactEmail { get; set; } = null!;
    public string? Phone { get; set; }
    public string? WebsiteUrl { get; set; }
    public SponsorCategory Category { get; set; }
}
public class TournamentSponsorRequestDTO
{
    public int TournamentId { get; set; }
    public int SponsorId { get; set; }
    public decimal ContractAmount { get; set; } // Debe ser > 0
}