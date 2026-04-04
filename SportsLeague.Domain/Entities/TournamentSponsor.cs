using SportsLeague.Domain.Entities;

public class TournamentSponsor
{
    public int Id { get; private set; }

    public int TournamentId { get; private set; }
    public Tournament Tournament { get; private set; } = null!;

    public int SponsorId { get; private set; }
    public Sponsor Sponsor { get; private set; } = null!;

    public decimal ContractAmount { get; private set; }

    public DateTime JoinedAt { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    protected TournamentSponsor() { }

    public TournamentSponsor(
        int tournamentId,
        int sponsorId,
        decimal contractAmount,
        DateTime joinedAt,
        DateTime createdAt)
    {
        TournamentId = tournamentId;
        SponsorId = sponsorId;
        ContractAmount = contractAmount;
        JoinedAt = joinedAt;
        CreatedAt = createdAt;
    }
}