using Microsoft.EntityFrameworkCore;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces.Repositories;

namespace SportsLeague.DataAccess.Repositories;

public class RefereeRepository : GenericRepository<Referee>, IRefereeRepository
{
    public RefereeRepository(ApplicationDbContext context) : base(context) { }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _context.Set<Player>().AnyAsync(x => x.FirstName == name || x.LastName == name);
    }
}