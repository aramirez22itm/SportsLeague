
using SportsLeague.Domain.Entities;

namespace SportsLeague.Domain.Interfaces.Repositories
{
    public interface IPlayerRepository : IGenericRepository<Player>
    {
        Task<bool> ExistsByNameAsync(string name);
    }
}
