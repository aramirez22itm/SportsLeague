using SportsLeague.Domain.Entities;

namespace SportsLeague.Domain.Interfaces.Services
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAllAsync();
        Task<Team> GetByIdAsync(int id);
        Task<bool> CreateAsync(Team entity);
        Task<bool> UpdateAsync(Team entity);
        Task<bool> DeleteAsync(int id);
    }
}