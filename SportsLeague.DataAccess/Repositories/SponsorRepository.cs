using Microsoft.EntityFrameworkCore;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces.Repositories;

namespace SportsLeague.DataAccess.Repositories;

public class SponsorRepository : GenericRepository<Sponsor>, ISponsorRepository
{
    public SponsorRepository(ApplicationDbContext context) : base(context) { }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _context.Set<Sponsor>().AnyAsync(x => x.Name == name);
    }
}
