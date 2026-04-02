using SportsLeague.Domain.Enums;

namespace SportsLeague.Domain.DTOs.Response;

public class SponsorResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string ContactEmail { get; set; } = null!;
    public string? Phone { get; set; }
    public string? WebsiteUrl { get; set; }
    public SponsorCategory Category { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class TournamentSponsorResponseDTO
{
    public int Id { get; set; }
    public int TournamentId { get; set; }
    public string TournamentName { get; set; } = null!;
    public int SponsorId { get; set; }
    public string SponsorName { get; set; } = null!;
    public decimal ContractAmount { get; set; }
    public DateTime JoinedAt { get; set; }
}