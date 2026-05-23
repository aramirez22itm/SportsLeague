using SportsLeague.DataAccess.Context;
using SportsLeague.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace SportsLeague.DataAccess.Repositories;

public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
{
    public PlayerRepository(LeagueDbContext context) : base(context)
    {
    }

    public Task<bool> ExistsByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Player>> GetByTeamAsync(int teamId)
    {
        return await _dbSet
            .Where(p => p.TeamId == teamId)
            .ToListAsync();
    }
}
