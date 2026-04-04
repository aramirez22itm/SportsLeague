using Microsoft.EntityFrameworkCore;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces.Repositories;

namespace SportsLeague.DataAccess.Repositories;

public class TournamentRepository : GenericRepository<Tournament>, ITournamentRepository
{
    public TournamentRepository(ApplicationDbContext context) : base(context) { }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _context.Set<Tournament>().AnyAsync(x => x.Name == name);
    }

}