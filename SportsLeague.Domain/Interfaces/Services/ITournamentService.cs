using SportsLeague.Domain.Entities;

namespace SportsLeague.Domain.Interfaces.Services
{
    public interface ITournamentService
    {
        Task<IEnumerable<Tournament>> GetAllAsync();
        Task<Tournament> GetByIdAsync(int id);
        Task<bool> CreateAsync(Tournament entity);
        Task<bool> UpdateAsync(Tournament entity);
        Task<bool> DeleteAsync(int id);
    }
}
