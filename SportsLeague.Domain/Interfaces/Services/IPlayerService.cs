using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Services;

namespace SportsLeague.Domain.Interfaces.Services;

    public interface IPlayerService
    {
        Task<IEnumerable<Player>> GetAllAsync();
        Task<Player> GetByIdAsync(int id);
        Task<bool> CreateAsync(Player entity);
        Task<bool> UpdateAsync(Player entity);
        Task<bool> DeleteAsync(int id);
    }
