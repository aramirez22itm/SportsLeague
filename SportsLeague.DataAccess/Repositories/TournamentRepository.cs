using Microsoft.EntityFrameworkCore;
using SportsLeague.DataAccess.Context;
using SportsLeague.Domain.Entities;
using SportsLeague.Domain.Enums;
using SportsLeague.Domain.Interfaces.Repositories;




namespace SportsLeague.DataAccess.Repositories;

public class TournamentRepository : GenericRepository<Tournament>, ITournamentRepository
{
    private readonly LeagueDbContext _context;

    public TournamentRepository(LeagueDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tournament>> GetByStatusAsync(TournamentStatus status)
    {
        return await _context.Tournaments
            .Where(t => t.Status == status)
            .ToListAsync();
    }

    public async Task<Tournament?> GetByIdWithTeamsAsync(int id)
    {
        return await _context.Tournaments
            .Include(t => t.TournamentTeams)
            .ThenInclude(tt => tt.Team)
            .FirstOrDefaultAsync(t => t.Id == id);
    }
}
