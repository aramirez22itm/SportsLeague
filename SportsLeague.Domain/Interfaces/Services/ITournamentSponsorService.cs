using SportsLeague.Domain.Entities;

namespace SportsLeague.Domain.Interfaces.Services
{
    public interface ITournamentSponsorService
    {
        Task<IEnumerable<TournamentSponsor>> GetAllAsync();
        Task<TournamentSponsor> GetByIdAsync(int id);
        Task<bool> CreateAsync(TournamentSponsor entity);
        Task<bool> UpdateAsync(TournamentSponsor entity);
        Task<bool> DeleteAsync(int id);
    }
}
