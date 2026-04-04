using Microsoft.EntityFrameworkCore;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Interfaces.Repositories;

namespace SportsLeague.DataAccess.Repositories;

public class TournamentSponsorRepository : GenericRepository<Tournament>, ITournamentRepository
{
    public TournamentSponsorRepository(ApplicationDbContext context) : base(context) { }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _context.Set<TournamentSponsor>().AnyAsync(x =>
            x.Tournament.Name == name || x.Sponsor.Name == name);
    }

}