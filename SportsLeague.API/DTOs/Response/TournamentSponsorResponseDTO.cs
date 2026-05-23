using SportsLeague.Domain.Entities;

namespace SportsLeague.Domain.DTOs.Response
{
    public class TournamentSponsorResponseDTO
    {
        public int Id { get; set; }
        public int TournamentId { get; set; }
        public int SponsorId { get; set; }
        public decimal ContractAmount { get; set; }
        public DateTime JoinedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public static TournamentSponsorResponseDTO FromEntity(TournamentSponsor entity)
        {
            return new TournamentSponsorResponseDTO
            {
                Id = entity.Id,
                TournamentId = entity.TournamentId,
                SponsorId = entity.SponsorId,
                ContractAmount = entity.ContractAmount,
                JoinedAt = entity.JoinedAt,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }
    }
}